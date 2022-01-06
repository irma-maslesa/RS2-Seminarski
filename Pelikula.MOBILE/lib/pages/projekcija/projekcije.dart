import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/projekcija/prikaz_projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Projekcije extends StatefulWidget {
  const Projekcije({Key? key}) : super(key: key);

  @override
  _ProjekcijeState createState() => _ProjekcijeState();
}

class _ProjekcijeState extends State<Projekcije> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  TextEditingController nazivController = TextEditingController();
  String? _naziv;

  List<DropdownMenuItem> zanrovi = [
    DropdownMenuItem(
        child: Text(
          "Muško",
          style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
        ),
        value: 1),
    DropdownMenuItem(
        child: Text(
          "Žensko",
          style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
        ),
        value: 2),
  ];
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
        title: const Text("Projekcije"),
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
            child: Text("Učitavanje..."),
          );
        } else if (snapshot.hasError) {
          return const Center(
            child: Text("Greška pri učitavanju."),
          );
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length > 0) {
          return ListView(
            children: (snapshot.data.payload
                    .map((e) => ProjekcijaDetailedResponse.fromJson(e))
                    .toList()
                    .cast<ProjekcijaDetailedResponse>() as List)
                .map((e) => projekcijaWidget(e))
                .toList()
                .cast<Widget>(),
          );
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length == 0) {
          return const Center(
            child: Text("Nema rezultata"),
          );
        } else if (snapshot.data is ErrorResponse) {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        } else {
          return const Center(
            child: Text("Došlo je do greške!"),
          );
        }
      },
    );
  }

  Future<dynamic> getProjekcije(String? naziv, int? zanrId) async {
    Map<String, dynamic> params = {};

    if (naziv != null && naziv.trim().isNotEmpty) {
      params["naziv"] = naziv;
    }

    if (zanrId != null && zanrId != 0) {
      params["zanrId"] = zanrId.toString();
    }

    dynamic response = params.isEmpty
        ? await ApiService.get("Projekcija/aktivne/details", null)
        : await ApiService.get("Projekcija/aktivne/details", params);

    return response;
  }

  Widget projekcijaWidget(ProjekcijaDetailedResponse projekcija) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w700, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => PrikazProjekcije(projekcija)));
        },
        child: Row(
          children: [
            Padding(
              padding: const EdgeInsets.all(5),
              child: projekcija.film!.plakatThumb != null &&
                      projekcija.film!.plakatThumb!.isNotEmpty
                  ? Image(
                      image: MemoryImage(
                          Uint8List.fromList(projekcija.film!.plakatThumb!)),
                      width: 135,
                    )
                  : const Image(
                      image: AssetImage('assets/no-image.png'),
                      width: 135,
                    ),
            ),
            const SizedBox(
              width: 30,
            ),
            Column(
              children: [
                Text(projekcija.film!.naslov!, style: styleNaslov),
                Text("Cijena: ${projekcija.cijena.toString()} KM",
                    style: styleTekst),
                Text(
                    "Vrijedi do: ${DateFormat('dd/MM/yyyy').format(projekcija.vrijediDo!)}",
                    style: styleTekst)
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget ddZanr() {
    return FutureBuilder<dynamic>(
      future: getZanrove(_odabraniZanr),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: Text("Učitavanje..."),
          );
        } else if (snapshot.hasError) {
          return const Center(
            child: Text("Greška pri učitavanju."),
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
              'Žanr',
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
            child: Text("Došlo je do greške!"),
          );
        }
      },
    );
  }

  Future<dynamic> getZanrove(int? odabraniZanr) async {
    dynamic response = await ApiService.get("Zanr/lov", null);

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
              "Svi žanrovi",
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
