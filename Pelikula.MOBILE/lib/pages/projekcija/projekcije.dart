import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:http/http.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/projekcija/prikaz_projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';
import 'package:intl/intl.dart';

class Projekcije extends StatefulWidget {
  const Projekcije({Key? key}) : super(key: key);

  @override
  _ProjekcijeState createState() => _ProjekcijeState();
}

class _ProjekcijeState extends State<Projekcije> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  TextEditingController nazivController = TextEditingController();
  String? _naziv;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Projekcije"),
      ),
      drawer: const MyDrawer(),
      body: body(),
    );
  }

  Widget body() {
    final txtNaziv = TextFormField(
      controller: nazivController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
        contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        hintText: "Naziv filma",
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
        suffixIcon: IconButton(
          onPressed: () {
            if (nazivController.text.trim().length > 2) {
              _naziv = nazivController.text;
            } else {
              _naziv = null;
            }
            setState(() {
              getProjekcije(_naziv);
            });
          },
          icon: const Icon(Icons.search),
        ),
      ),
    );

    return FutureBuilder<dynamic>(
      future: getProjekcije(_naziv),
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
          return Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Padding(padding: const EdgeInsets.all(10), child: txtNaziv),
                Expanded(
                  child: ListView(
                    children: (snapshot.data.payload
                            .map((e) => ProjekcijaDetailedResponse.fromJson(e))
                            .toList()
                            .cast<ProjekcijaDetailedResponse>() as List)
                        .map((e) => projekcijaWidget(e))
                        .toList()
                        .cast<Widget>(),
                  ),
                )
              ]);
        } else {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        }
      },
    );
  }

  Future<dynamic> getProjekcije(String? naziv) async {
    Map<String, dynamic> params = {};

    if (naziv != null && naziv.trim().isNotEmpty) {
      params["naziv"] = naziv;
    }

    dynamic response;

    if (params.isEmpty) {
      response = await ApiService.get("Projekcija/aktivne/details", null);
    } else {
      response = await ApiService.get("Projekcija/aktivne/details", params);
    }

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
}
