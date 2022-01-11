import 'dart:core';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_response.dart';
import 'package:pelikula_mobile/pages/rezervacija/prikaz_sjedista.dart';
import 'package:pelikula_mobile/pages/rezervacija/rezervacija.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class PrikazRezervacije extends StatefulWidget {
  final RezervacijaResponse rezervacija;

  const PrikazRezervacije(this.rezervacija, {Key? key}) : super(key: key);

  @override
  _PrikazRezervacijeState createState() => _PrikazRezervacijeState();
}

class _PrikazRezervacijeState extends State<PrikazRezervacije> {
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
                Navigator.of(context).pushAndRemoveUntil(
                  MaterialPageRoute(
                    builder: (BuildContext context) => const Rezervacije(),
                  ),
                  (route) => false,
                );
              },
            ),
          ],
        );
      },
    );
  }

  Future<void> _showDialogDaNe(String text) async {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Text(text),
          actions: <Widget>[
            TextButton(
              child: const Text('Ne'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: const Text('Da'),
              onPressed: () async {
                await sendRequest(widget.rezervacija.id!);

                if (response == null) {
                  _showDialog('Došlo je do greške, pokušajte opet! ');
                } else if (response is PayloadResponse) {
                  _showDialog('Rezervacija uspješno otkazana!', false);
                } else {
                  _showDialog((response as ErrorResponse).message as String);
                }
              },
            ),
          ],
        );
      },
    );
  }

  dynamic response;

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController terminController = TextEditingController();
  TextEditingController brojSjedistaController = TextEditingController();

  Future<void> sendRequest(int id) async {
    response = await ApiService.otkaziRzervaciju(id);
  }

  @override
  Widget build(BuildContext context) {
    terminController.text = DateFormat('dd/MM/yyyy, HH:mm')
        .format(widget.rezervacija.projekcijaTermin!.termin!);
    brojSjedistaController.text = widget.rezervacija.brojSjedista.toString();

    return Scaffold(
      appBar: AppBar(
        title: Text(
          widget.rezervacija.projekcijaTermin!.projekcija!.film!.naziv!,
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

    final btnOtkazi = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          _showDialogDaNe("Jeste li sigurni da želite otkazati rezervaciju?");
        },
        child: Text("Otkaži rezervaciju",
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
        const SizedBox(height: 15.0),
        Expanded(
          child: PrikazSjedista(
              widget.rezervacija.projekcijaTermin!.projekcija!.id,
              widget.rezervacija.projekcijaTermin!.id,
              widget.rezervacija.sjedista!.map((e) => e.sjediste!.id!).toList(),
              widget.rezervacija.brojSjedista,
              true, (id, ukloni) {
            return false;
          }),
        ),
        //Buttoni
        widget.rezervacija.datumOtkazano != null
            ? Text(
                "Rezervacija je otakazana ${DateFormat('dd/MM/yyyy, HH:mm').format(widget.rezervacija.datumOtkazano!)}!",
                textAlign: TextAlign.center,
              )
            : widget.rezervacija.datumProdano != null
                ? Text(
                    "Rezervacija je prodana ${DateFormat('dd/MM/yyyy, HH:mm').format(widget.rezervacija.datumProdano!)}!",
                    textAlign: TextAlign.center,
                  )
                : widget.rezervacija.projekcijaTermin!.termin!
                        .isBefore(DateTime.now().add(const Duration(days: 1)))
                    ? const Text(
                        "Rezervaciju je moguće otkazati najkasnije 24h prije projekcije!",
                        textAlign: TextAlign.center,
                      )
                    : Row(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [Expanded(child: btnOtkazi)]),
      ],
    );
  }
}
