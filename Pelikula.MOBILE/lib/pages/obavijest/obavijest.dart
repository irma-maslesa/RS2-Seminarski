import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/helper/sorting_params.dart';
import 'package:pelikula_mobile/model/obavijest/obavijest_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/obavijest/prikaz_obavijesti.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Obavijesti extends StatefulWidget {
  const Obavijesti({Key? key}) : super(key: key);

  @override
  _ObavijestiState createState() => _ObavijestiState();
}

class _ObavijestiState extends State<Obavijesti> {
  _getTekstObavijesti(String tekst) {
    return tekst.length > 50 ? tekst.substring(0, 50) + "..." : tekst;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Obavijesti")),
      drawer: const MyDrawer(),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getObavijesti(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Učitavanje..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length > 0) {
          return ListView(
            children: (snapshot.data.payload
                    .map((e) => ObavijestResponse.fromJson(e))
                    .toList()
                    .cast<ObavijestResponse>() as List)
                .map((e) => obavijestWidget(e))
                .toList()
                .cast<Widget>(),
          );
        } else if (snapshot.data is PagedPayloadResponse &&
            snapshot.data.payload.length == 0) {
          return const Center(
            child: Text("Trenutno nema obavijesti."),
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

  Future<dynamic> getObavijesti() async {
    List<SortingParams> sortingParams = [
      SortingParams(sortOrder: "DESC", columnName: "datum")
    ];
    String sorting = json.encode(sortingParams);
    var response = await ApiService.getPaged("Obavijest", {"sorting": sorting});
    return response;
  }

  Widget obavijestWidget(ObavijestResponse obavijest) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w500, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);
    TextStyle styleDatumAutor = const TextStyle(
        fontSize: 10.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
          onPressed: () {
            Navigator.of(context).push(MaterialPageRoute(
                builder: (context) => PrikazObavijesti(obavijest)));
          },
          child: Column(
            children: [
              Text(
                obavijest.naslov!,
                style: styleNaslov,
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 20.0),
              Text(
                _getTekstObavijesti(obavijest.tekst!),
                style: styleTekst,
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 10.0),
              Text("Autor: ${obavijest.korisnik!.naziv!.split("(")[0]}",
                  style: styleDatumAutor),
              Text(DateFormat('dd/MM/yyyy').format(obavijest.datum!),
                  style: styleDatumAutor)
            ],
          )),
    );
  }
}
