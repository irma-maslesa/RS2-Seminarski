import 'dart:core';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_response.dart';

class PrikazRezervacije extends StatefulWidget {
  final RezervacijaResponse rezervacija;

  const PrikazRezervacije(this.rezervacija, {Key? key}) : super(key: key);

  @override
  _PrikazRezervacijeState createState() => _PrikazRezervacijeState();
}

class _PrikazRezervacijeState extends State<PrikazRezervacije> {
  Future<void> _showDialog(String text) async {
    return showDialog<void>(
      barrierDismissible: false,
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          content: Text(text),
          actions: <Widget>[
            TextButton(
              child: const Text('OK'),
              onPressed: () {
                Navigator.of(context).pop();
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController terminController = TextEditingController();
  TextEditingController brojSjedistaController = TextEditingController();

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

    final btnOdustani = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pop();
        },
        child: Text("Odustani",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: const Color(0xff01A0C7), fontWeight: FontWeight.bold)),
      ),
    );
    final btnDalje = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {},
        child: Text("Dalje",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
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
        //Buttoni
        Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              btnOdustani,
              const SizedBox(width: 15.0),
              Expanded(child: btnDalje)
            ]),
      ],
    );
  }
}
