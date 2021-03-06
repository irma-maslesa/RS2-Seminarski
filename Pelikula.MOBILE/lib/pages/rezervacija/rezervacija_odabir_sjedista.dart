import 'dart:convert';
import 'dart:core';

import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/list_payload_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_upsert_request.dart';
import 'package:pelikula_mobile/pages/kupovina/kupovina_placanje.dart';
import 'package:pelikula_mobile/pages/projekcija/projekcije.dart';
import 'package:pelikula_mobile/pages/rezervacija/prikaz_sjedista.dart';
import 'package:pelikula_mobile/pages/rezervacija/sjediste.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class RezervacijaOdabirSjedista extends StatefulWidget {
  final RezervacijaUpsertRequest request;
  final ProjekcijaDetailedResponse projekcija;
  final String terminNaziv;

  final bool isRezervacija;

  const RezervacijaOdabirSjedista(
      this.request, this.projekcija, this.isRezervacija, this.terminNaziv,
      {Key? key})
      : super(key: key);

  @override
  _RezervacijaOdabirSjedistaState createState() =>
      _RezervacijaOdabirSjedistaState();
}

class _RezervacijaOdabirSjedistaState extends State<RezervacijaOdabirSjedista> {
  dynamic response;

  Future<void> _showDialog(String text, [dismissable = true]) async {
    return showDialog<void>(
      barrierDismissible: dismissable,
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Text(text),
          actions: <Widget>[
            TextButton(
              child: const Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  Future<void> sendRequest(RezervacijaUpsertRequest request) async {
    response =
        await ApiService.post("Rezervacija", json.encode(request.toJson()));
  }

  bool odaberiSjediste(id, ukloni) {
    if (!ukloni) {
      if (widget.request.sjedistaIds!.length == widget.request.brojSjedista) {
        _showDialog("Ve?? je odabran nazna??eni broj sjedi??ta!");
        return false;
      }
      setState(() {
        widget.request.sjedistaIds!.add(id);
      });
      return true;
    } else {
      setState(() {
        widget.request.sjedistaIds!.remove(id);
      });
      return true;
    }
  }

  var widgetList = [];

  RezervacijaUpsertRequest request = RezervacijaUpsertRequest();
  List<LoV> sjedista = [];
  List<LoV> zauzetaSjedista = [];
  int? _odabraniTermin;

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController brojSjedistaController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          widget.isRezervacija
              ? "${widget.projekcija.film!.naslov!} - Rezervacija"
              : "${widget.projekcija.film!.naslov!} - Kupovina",
        ),
      ),
      body: Center(
        child: Container(
          color: Colors.white,
          child: Padding(
            padding: const EdgeInsets.all(36.0),
            child: body(),
          ),
        ),
      ),
    );
  }

  Widget body() {
    final btnOdustani = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pop();
          Navigator.of(context).pop();
        },
        child: Text("Odustani",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: const Color(0xff01A0C7), fontWeight: FontWeight.bold)),
      ),
    );
    final btnZavrsi = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          if (widget.request.sjedistaIds!.length !=
              widget.request.brojSjedista) {
            _showDialog(
                "Odaberite ta??an broj sjedi??ta!\n\n\nOdabrano sjedi??ta: ${widget.request.sjedistaIds!.length}/${widget.request.brojSjedista}");
          } else {
            await sendRequest(widget.request);

            if (response == null) {
              _showDialog('Do??lo je do gre??ke, poku??ajte opet! ');
            } else if (response is PayloadResponse) {
              await _showDialog("Uspje??no kreirana rezervacija!", false);

              Navigator.of(context).pushAndRemoveUntil(
                MaterialPageRoute(
                  builder: (BuildContext context) => const Projekcije(true),
                ),
                (route) => false,
              );
            } else {
              _showDialog((response as ErrorResponse).message as String);
            }
          }
        },
        child: Text("Kreiraj rezervaciju",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    final btnDalje = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          if (widget.request.sjedistaIds!.length !=
              widget.request.brojSjedista) {
            _showDialog(
                "Odaberite ta??an broj sjedi??ta!\n\n\nOdabrano sjedi??ta: ${widget.request.sjedistaIds!.length}/${widget.request.brojSjedista}");
          } else {
            print(request.sjedistaIds);
            Navigator.of(context).push(MaterialPageRoute(
                builder: (context) => KupovinaPlacanje(
                    widget.request, widget.projekcija, widget.terminNaziv)));
          }
        },
        child: Text("Dalje",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    return FutureBuilder(
        future: getSjedista(_odabraniTermin),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("U??itavanje..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("Gre??ka pri u??itavanju."));
          } else if (snapshot.data is ListPayloadResponse) {
            return Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Expanded(
                    child: PrikazSjedista(
                        widget.projekcija.id,
                        widget.request.projekcijaTerminId,
                        widget.request.sjedistaIds!,
                        widget.request.brojSjedista,
                        false,
                        odaberiSjediste),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.stretch,
                    children: [
                      Text(
                        "Odabrana sjedi??ta: ${widget.request.sjedistaIds!.length}/${widget.request.brojSjedista}",
                        style: style,
                        textAlign: TextAlign.center,
                      ),
                      Text(
                        "Cijena: ${(widget.projekcija.cijena! * widget.request.brojSjedista!).toStringAsFixed(2)} KM",
                        style: style,
                        textAlign: TextAlign.center,
                      )
                    ],
                  ),
                  const SizedBox(height: 20.0),
                  Row(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        btnOdustani,
                        const SizedBox(width: 15.0),
                        widget.isRezervacija
                            ? Expanded(child: btnZavrsi)
                            : Expanded(child: btnDalje)
                      ]),
                ]);
          } else {
            return Center(
              child: Text((snapshot.data as ErrorResponse).message as String),
            );
          }
        });
  }

  Future<dynamic> getSjedista(odabraniTermin) async {
    widgetList = [];
    dynamic response =
        await ApiService.get("Sala/${widget.projekcija.id}/sjedista");
    dynamic responseZauzeta = await ApiService.get(
        "Sala/${widget.request.projekcijaTerminId}/zauzeta-sjedista");

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
                      widget.request.sjedistaIds!.contains(e.id),
                      zauzetaSjedista.map((o) => o.id).contains(e.id),
                      false,
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
    }

    return response;
  }
}
