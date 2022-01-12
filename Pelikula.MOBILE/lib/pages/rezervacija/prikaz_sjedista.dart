import 'dart:convert';
import 'dart:core';

import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/list_payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_upsert_request.dart';
import 'package:pelikula_mobile/pages/rezervacija/sjediste.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class PrikazSjedista extends StatefulWidget {
  final int? projekcijaId;
  final int? projekcijaTerminId;
  final int? brojSjedista;
  final List<int> odabranaSjedista;

  final Function(int, bool) odaberiSjediste;

  final bool prikaz;

  const PrikazSjedista(
      this.projekcijaId,
      this.projekcijaTerminId,
      this.odabranaSjedista,
      this.brojSjedista,
      this.prikaz,
      this.odaberiSjediste,
      {Key? key})
      : super(key: key);

  @override
  _PrikazSjedistaState createState() => _PrikazSjedistaState();
}

class _PrikazSjedistaState extends State<PrikazSjedista> {
  dynamic response;

  Future<void> sendRequest(RezervacijaUpsertRequest request) async {
    response =
        await ApiService.post("Rezervacija", json.encode(request.toJson()));
  }

  bool odaberiSjediste(id, ukloni) {
    return widget.odaberiSjediste(id, ukloni);
  }

  var widgetList = [];

  RezervacijaUpsertRequest request = RezervacijaUpsertRequest();
  List<LoV> sjedista = [];
  List<LoV> zauzetaSjedista = [];

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController brojSjedistaController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
        future: getSjedista(),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("Učitavanje..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("Greška pri učitavanju."));
          } else if (snapshot.data is ListPayloadResponse) {
            return ListView(children: [
              Column(
                children: widgetList.toList().cast<Widget>(),
              ),
            ]);
          } else {
            return Center(
              child: Text((snapshot.data as ErrorResponse).message as String),
            );
          }
        });
  }

  Future<dynamic> getSjedista() async {
    widgetList = [];
    dynamic response =
        await ApiService.get("Sala/${widget.projekcijaId}/sjedista");
    dynamic responseZauzeta = await ApiService.get(
        "Sala/${widget.projekcijaTerminId}/zauzeta-sjedista");

    if (responseZauzeta is ListPayloadResponse) {
      zauzetaSjedista = responseZauzeta.payload
          .map((e) => LoV.fromJson(e))
          .toList()
          .cast<LoV>()
          .toList();
    }

    if (response is ListPayloadResponse) {
      sjedista = response.payload
          .map((e) => LoV.fromJson(e))
          .toList()
          .cast<LoV>()
          .toList();

      var groupedSjedista =
          groupBy(sjedista, (LoV e) => e.naziv!.substring(0, 1));

      groupedSjedista.forEach((key, value) {
        widgetList.add(
          Row(
            textDirection: TextDirection.rtl,
            children: value
                .map((e) => Sjediste(
                      e,
                      widget.odabranaSjedista.contains(e.id),
                      zauzetaSjedista.map((o) => o.id).contains(e.id),
                      widget.prikaz,
                      odaberiSjediste,
                    ))
                .toList()
                .cast<Widget>(),
          ),
        );
        widgetList.add(const SizedBox(height: 5.0));
      });

      widgetList.add(const SizedBox(height: 10.0));
      widgetList.add(Row(children: [
        Expanded(
          child: Material(
            elevation: 5.0,
            borderRadius: BorderRadius.circular(10.0),
            color: const Color(0xff97AFBA),
            child: MaterialButton(
              padding: const EdgeInsets.all(5.0),
              onPressed: null,
              child: Text("E     K     R     A     N",
                  textAlign: TextAlign.center,
                  style: style.copyWith(
                      color: Colors.white, fontWeight: FontWeight.bold)),
            ),
          ),
        )
      ]));
      widgetList.add(const SizedBox(height: 30.0));
      widgetList.add(
        Row(children: [
          createLegendTile("Slobodno", 0xff01A0C7),
          createLegendTile("Zauzeto", 0xff97AFBA),
          createLegendTile("Odabrano", 0xffe36b9d),
        ]),
      );
    }

    return response;
  }

  Widget createLegendTile(String tekst, int boja) {
    return Expanded(
      child: Row(children: [
        Container(
          height: 20.0,
          width: 20.0,
          child: Material(
            elevation: 5.0,
            borderRadius: BorderRadius.circular(3.0),
            color: Color(boja),
            child: const MaterialButton(
              onPressed: null,
              child: Text(""),
            ),
          ),
        ),
        const SizedBox(width: 5.0),
        Text(tekst)
      ]),
    );
  }
}
