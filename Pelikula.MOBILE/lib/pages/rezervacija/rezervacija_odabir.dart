import 'dart:core';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/list_payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_upsert_request.dart';
import 'package:pelikula_mobile/pages/rezervacija/rezervacija_odabir_sjedista.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class RezervacijaOdabir extends StatefulWidget {
  final ProjekcijaDetailedResponse projekcija;

  const RezervacijaOdabir(this.projekcija, {Key? key}) : super(key: key);

  @override
  _RezervacijaOdabirState createState() => _RezervacijaOdabirState();
}

class _RezervacijaOdabirState extends State<RezervacijaOdabir> {
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

  RezervacijaUpsertRequest request = RezervacijaUpsertRequest();
  List<DropdownMenuItem> termini = [];
  int? _odabraniTermin;

  final _formKey = GlobalKey<FormState>();
  final _obaveznoPolje = "Polje je obavezno";

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController brojSjedistaController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          widget.projekcija.film!.naslov!,
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
    final txtBrojSjedista = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (value == "0") {
          return "Minimalna vrijednost je 1";
        } else {
          return null;
        }
      },
      keyboardType: TextInputType.number,
      inputFormatters: [
        FilteringTextInputFormatter.digitsOnly,
      ],
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
        onPressed: () async {
          if (_formKey.currentState!.validate()) {
            request.brojSjedista = int.parse(brojSjedistaController.text);
            request.datum = DateTime.now();
            request.korisnikId = ApiService.korisnikId;
            request.projekcijaTerminId = _odabraniTermin;

            Navigator.of(context).push(MaterialPageRoute(
                builder: (context) =>
                    RezervacijaOdabirSjedista(request, widget.projekcija)));
          }
        },
        child: Text("Dalje",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    return FutureBuilder(
        future: getAktivniTermini(_odabraniTermin),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("Učitavanje..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("Greška pri učitavanju."));
          } else if (snapshot.data is ListPayloadResponse) {
            return Form(
              key: _formKey,
              autovalidateMode: AutovalidateMode.onUserInteraction,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  ddTermin(),
                  const SizedBox(height: 10.0),
                  txtBrojSjedista, const SizedBox(height: 15.0),
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
              ),
            );
          } else {
            return Center(
              child: Text((snapshot.data as ErrorResponse).message as String),
            );
          }
        });
  }

  Future<dynamic> getAktivniTermini(odabraniTermin) async {
    dynamic response = await ApiService.get(
        "Projekcija/${widget.projekcija.id}/aktivni-termini/${ApiService.korisnikId}");

    if (response is ListPayloadResponse) {
      termini = (response.payload
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

      if (termini.isEmpty) {
        _showDialog("Nema aktivnih termina za koje nemate rezervaciju");
      }
    }

    return response;
  }

  Widget ddTermin() {
    return DropdownButtonFormField<dynamic>(
      validator: (value) {
        return value == null ? _obaveznoPolje : null;
      },
      onChanged: (dynamic newVal) {
        request.sjedistaIds = [];
        _odabraniTermin = newVal;
      },
      hint: Text(
        'Termin',
        style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
      ),
      isExpanded: true,
      items: termini,
      decoration: InputDecoration(
        contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)),
      ),
    );
  }
}
