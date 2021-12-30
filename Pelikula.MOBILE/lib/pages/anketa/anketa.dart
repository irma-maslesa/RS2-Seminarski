import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/anketa/anketa_extended_response.dart';
import 'package:pelikula_mobile/model/helper/sorting_params.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/anketa/prikaz_ankete.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Ankete extends StatefulWidget {
  const Ankete({Key? key}) : super(key: key);

  @override
  _AnketeState createState() => _AnketeState();
}

class _AnketeState extends State<Ankete> {
  TextStyle styleNaslov = const TextStyle(
      fontSize: 30.0, fontWeight: FontWeight.w500, color: Colors.black);
  TextStyle styleTekst = const TextStyle(
      fontSize: 25.0, fontWeight: FontWeight.w300, color: Colors.black);
  TextStyle styleDatum = const TextStyle(
      fontSize: 10.0, fontWeight: FontWeight.w300, color: Colors.black);

  var _odgovorene;
  var _neodgovorene;

  List<Widget> _neodgovoreneAnkete() {
    return _neodgovorene.length > 0
        ? _neodgovorene
            .map((e) => anketaWidget(e, aktivno: true))
            .toList()
            .cast<Widget>()
        : [
            Center(
              child: Padding(
                padding: const EdgeInsets.all(15),
                child: Text("Trenutno nema novih anketa!", style: styleTekst),
              ),
            )
          ];
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Ankete")),
      drawer: const MyDrawer(),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getAnkete(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Učitavanje..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else if (snapshot.data is PagedPayloadResponse) {
          _odgovorene = (snapshot.data.payload
                  .map((e) => AnketaExtendedResponse.fromJson(e))
                  .toList()
                  .cast<AnketaExtendedResponse>() as List)
              .toList()
              .where((e) => e.korisnikAnketaOdgovor != null);
          _neodgovorene = (snapshot.data.payload
                  .map((e) => AnketaExtendedResponse.fromJson(e))
                  .toList()
                  .cast<AnketaExtendedResponse>() as List)
              .toList()
              .where((e) => e.korisnikAnketaOdgovor == null);
          return Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Card(
                    child: ExpansionTile(
                        initiallyExpanded: true,
                        title: Text('Neodgovorene ankete', style: styleNaslov),
                        children: _neodgovoreneAnkete())),
                Card(
                    child: ExpansionTile(
                        initiallyExpanded: true,
                        title: Text('Odgovorene ankete', style: styleNaslov),
                        children: [
                      Column(
                          children: _odgovorene
                              .map((e) => anketaWidget(e))
                              .toList()
                              .cast<Widget>())
                    ]))
              ]);
        } else {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        }
      },
    );
  }

  Future<dynamic> getAnkete() async {
    List<SortingParams> sortingParams = [
      SortingParams(sortOrder: "DESC", columnName: "datum")
    ];
    String sorting = json.encode(sortingParams);
    var response = await ApiService.get(
        "Anketa/korisnik/${ApiService.korisnikId}", {"sorting": sorting});
    return response;
  }

  Widget anketaWidget(AnketaExtendedResponse anketa, {bool aktivno = false}) {
    return SizedBox(
        width: double.infinity,
        child: Card(
          child: TextButton(
              onPressed: () {
                if (aktivno) {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => PrikazAnkete(anketa, false)));
                } else {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => PrikazAnkete(anketa, true)));
                }
              },
              child: Column(
                children: [
                  Text(
                    anketa.naslov!,
                    style: styleTekst,
                    textAlign: TextAlign.center,
                  ),
                  const SizedBox(height: 10.0),
                  Text(DateFormat('dd/MM/yyyy').format(anketa.datum!),
                      style: styleDatum)
                ],
              )),
        ));
  }
}
