import 'dart:core';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/prodaja/prodaja_response.dart';
import 'package:pelikula_mobile/pages/rezervacija/prikaz_sjedista.dart';
import 'package:pelikula_mobile/services/api_service.dart';
import 'package:qr_flutter/qr_flutter.dart';

class PrikazKupovine extends StatefulWidget {
  final ProdajaResponse kupovina;

  const PrikazKupovine(this.kupovina, {Key? key}) : super(key: key);

  @override
  _PrikazKupovineState createState() => _PrikazKupovineState();
}

class _PrikazKupovineState extends State<PrikazKupovine> {
  Future<void> _showQRDialog(String tekst, [dismissable = true]) async {
    return showDialog<void>(
      barrierDismissible: dismissable,
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Container(
            width: 300.0,
            height: 315.0,
            child: Column(children: [
              Text(
                "Pokažite kod radniku kina na ulasku u salu.",
                style: style.copyWith(fontWeight: FontWeight.bold),
                textAlign: TextAlign.center,
              ),
              const SizedBox(
                height: 5,
              ),
              Expanded(
                child: QrImage(
                  data: tekst,
                  version: 8,
                ),
              ),
            ]),
          ),
        );
      },
    );
  }

  dynamic response;

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController terminController = TextEditingController();
  TextEditingController brojSjedistaController = TextEditingController();
  TextEditingController cijenaController = TextEditingController();

  Future<void> sendRequest(int id) async {
    response = await ApiService.otkaziRzervaciju(id);
  }

  @override
  Widget build(BuildContext context) {
    terminController.text = DateFormat('dd/MM/yyyy, HH:mm')
        .format(widget.kupovina.rezervacija!.projekcijaTermin!.termin!);
    brojSjedistaController.text =
        widget.kupovina.rezervacija!.brojSjedista.toString();
    cijenaController.text =
        "${(widget.kupovina.ukupnaCijena!).toStringAsFixed(2)} KM";

    return Scaffold(
      appBar: AppBar(
        title: Text(
          widget
              .kupovina.rezervacija!.projekcijaTermin!.projekcija!.film!.naziv!,
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
    String qrData =
        widget.kupovina.rezervacija!.projekcijaTermin!.projekcija!.film!.naziv!;
    qrData +=
        "\n${DateFormat('dd/MM/yyyy, HH:mm').format(widget.kupovina.rezervacija!.projekcijaTermin!.termin!)} ";
    qrData +=
        "- ${widget.kupovina.rezervacija!.projekcijaTermin!.projekcija!.sala!.naziv}\n";
    qrData +=
        "Sjedišta: ${widget.kupovina.rezervacija!.sjedista!.map((e) => e.sjediste!.naziv!).join(", ")}\n";
    qrData += "Korisnik: ${ApiService.korisnickoIme}";

    final txtTermin = TextFormField(
      enabled: false,
      focusNode: FocusNode(),
      enableInteractiveSelection: false,
      controller: terminController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Broj karti",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtBrojSjedista = TextFormField(
      enabled: false,
      focusNode: FocusNode(),
      enableInteractiveSelection: false,
      controller: brojSjedistaController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Broj karti",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtCijena = TextFormField(
      enabled: false,
      focusNode: FocusNode(),
      enableInteractiveSelection: false,
      controller: cijenaController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Cijena",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final btnQRC = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          _showQRDialog(qrData);
        },
        child: Text("Prikaži QR",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: const Color(0xff01A0C7), fontWeight: FontWeight.bold)),
      ),
    );

    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Padding(
                    padding: const EdgeInsets.fromLTRB(20, 0, 0, 0),
                    child: Text(
                      "Termin",
                      style: style,
                      textAlign: TextAlign.left,
                    ),
                  ),
                  txtTermin,
                ],
              ),
            ),
            const SizedBox(width: 10.0),
            Expanded(
              child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(15, 0, 0, 0),
                      child: Text(
                        "Broj karti",
                        style: style,
                        textAlign: TextAlign.left,
                      ),
                    ),
                    txtBrojSjedista,
                  ]),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Padding(
                    padding: const EdgeInsets.fromLTRB(20, 0, 0, 0),
                    child: Text(
                      "Cijena",
                      style: style,
                      textAlign: TextAlign.left,
                    ),
                  ),
                  txtCijena,
                ],
              ),
            ),
          ],
        ),
        const SizedBox(height: 15.0),
        Expanded(
          child: PrikazSjedista(
              widget.kupovina.rezervacija!.projekcijaTermin!.projekcija!.id,
              widget.kupovina.rezervacija!.projekcijaTermin!.id,
              widget.kupovina.rezervacija!.sjedista!
                  .map((e) => e.sjediste!.id!)
                  .toList(),
              widget.kupovina.rezervacija!.brojSjedista,
              true, (id, ukloni) {
            return false;
          }),
        ),
        //Buttoni
        widget.kupovina.rezervacija!.projekcijaTermin!.termin!
                .add(Duration(minutes: 90))
                .isAfter(DateTime.now())
            ? Row(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: [Expanded(child: btnQRC)])
            : SizedBox(),
      ],
    );
  }
}
