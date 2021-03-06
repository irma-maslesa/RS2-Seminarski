import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/projekcija/lista_projekcija.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Projekcije extends StatefulWidget {
  final bool aktivno;

  const Projekcije(this.aktivno, {Key? key}) : super(key: key);

  @override
  _ProjekcijeState createState() => _ProjekcijeState();
}

class _ProjekcijeState extends State<Projekcije> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  TextEditingController nazivController = TextEditingController();
  String? _naziv;

  List<DropdownMenuItem> zanrovi = [];
  int? _odabraniZanr = 0;

  @override
  Widget build(BuildContext context) {
    final txtNaziv = TextFormField(
      autofocus: false,
      controller: nazivController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
        contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        hintText: "Naziv filma",
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        suffixIcon: IconButton(
          onPressed: () {
            _naziv = nazivController.text == "" ? null : nazivController.text;

            setState(() {
              getProjekcije(_naziv, _odabraniZanr);
            });
          },
          icon: const Icon(Icons.search),
        ),
      ),
    );

    return Scaffold(
      appBar: AppBar(
        title: widget.aktivno ? const Text("Projekcije") : const Text("Najave"),
      ),
      drawer: const MyDrawer(),
      body: Column(children: [
        Padding(
            padding: const EdgeInsets.fromLTRB(10, 5, 10, 5), child: txtNaziv),
        Padding(
            padding: const EdgeInsets.fromLTRB(10, 0, 10, 5), child: ddZanr()),
        Expanded(child: body())
      ]),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getProjekcije(_naziv, _odabraniZanr),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: Text("U??itavanje..."),
          );
        } else if (snapshot.hasError) {
          return const Center(
            child: Text("Gre??ka pri u??itavanju."),
          );
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length > 0) {
          return ListaProjekcija(snapshot.data.payload, widget.aktivno);
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length == 0) {
          return Center(
            child: widget.aktivno
                ? const Text("Nema projekcija")
                : const Text("Nema najavljenih projekcija"),
          );
        } else if (snapshot.data is ErrorResponse) {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        } else {
          return const Center(
            child: Text("Do??lo je do gre??ke!"),
          );
        }
      },
    );
  }

  Future<dynamic> getProjekcije(String? naziv, int? zanrId) async {
    Map<String, dynamic> params = {};

    var path = widget.aktivno
        ? "Projekcija/aktivne/details"
        : "Projekcija/coming-soon/details";

    if (naziv != null && naziv.trim().isNotEmpty) {
      params["naziv"] = naziv;
    }

    if (zanrId != null && zanrId != 0) {
      params["zanrId"] = zanrId.toString();
    }

    dynamic response = params.isEmpty
        ? await ApiService.getPaged(path, null)
        : await ApiService.getPaged(path, params);

    return response;
  }

  Widget ddZanr() {
    return FutureBuilder<dynamic>(
      future: getZanrove(_odabraniZanr),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: Text("U??itavanje..."),
          );
        } else if (snapshot.hasError) {
          return const Center(
            child: Text("Gre??ka pri u??itavanju."),
          );
        } else if (snapshot.data is PagedPayloadResponse) {
          return DropdownButtonFormField(
            onChanged: (dynamic newVal) {
              setState(() {
                _odabraniZanr = newVal;
                getProjekcije(_naziv, _odabraniZanr);
              });
            },
            hint: Text(
              '??anr',
              style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
            ),
            isExpanded: true,
            items: zanrovi,
            value: _odabraniZanr,
            decoration: InputDecoration(
              contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
              border:
                  OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
            ),
          );
        } else if (snapshot.data is ErrorResponse) {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        } else {
          return const Center(
            child: Text("Do??lo je do gre??ke!"),
          );
        }
      },
    );
  }

  Future<dynamic> getZanrove(int? odabraniZanr) async {
    dynamic response = await ApiService.getPaged("Zanr/lov", null);

    if (response is PagedPayloadResponse) {
      zanrovi = (response.payload
              .map((e) => LoV.fromJson(e))
              .toList()
              .cast<LoV>() as List)
          .map((e) {
        return DropdownMenuItem(
            child: Text(
              e.naziv,
              style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
            ),
            value: e.id);
      }).toList();

      zanrovi = [
        DropdownMenuItem(
            child: Text(
              "Svi ??anrovi",
              style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
            ),
            value: 0),
        ...zanrovi
      ];

      if (odabraniZanr != null && odabraniZanr != 0) {
        _odabraniZanr = odabraniZanr;
      }
    }

    return response;
  }
}
