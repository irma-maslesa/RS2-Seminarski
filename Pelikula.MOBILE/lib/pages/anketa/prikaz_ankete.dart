import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/anketa/anketa_extended_response.dart';
import 'package:pelikula_mobile/model/anketa/anketa_odgovor_korisnik_insert_request.dart';
import 'package:pelikula_mobile/model/anketa/anketa_odgovor_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/pages/anketa/anketa.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class PrikazAnkete extends StatelessWidget {
  final AnketaExtendedResponse anketa;
  final bool detalji;

  const PrikazAnkete(this.anketa, this.detalji, {Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var ukupnoOdg =
        anketa.odgovori!.fold(0, (int sum, e) => sum + e.ukupnoIzabrano!);

    if (detalji) {
      anketa.odgovori!.sort((b, a) => (a.ukupnoIzabrano! / ukupnoOdg)
          .compareTo(b.ukupnoIzabrano! / ukupnoOdg));
    }
    dynamic response;
    AnketaOdgovorKorisnikInsertRequest request =
        AnketaOdgovorKorisnikInsertRequest();

    TextStyle styleNaslov =
        const TextStyle(fontSize: 30.0, fontWeight: FontWeight.w500);
    TextStyle styleTekst = const TextStyle(
        fontSize: 25.0, fontWeight: FontWeight.w300, color: Colors.black);
    TextStyle styleDatum =
        const TextStyle(fontSize: 15.0, fontWeight: FontWeight.w300);

    Future<void> _showDialog(String text) async {
      return showDialog<void>(
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
                      builder: (BuildContext context) => const Ankete(),
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

    Widget _getPercentage(AnketaOdgovorResponse odgovor) {
      return detalji
          ? Text(
              "${(odgovor.ukupnoIzabrano! / ukupnoOdg * 100).toStringAsFixed(2)}%",
              style: styleTekst,
              textAlign: TextAlign.center,
            )
          : const SizedBox();
    }

    Future<void> getData(AnketaOdgovorKorisnikInsertRequest request) async {
      response = await ApiService.post(
          "Anketa/korisnik-odgovor", json.encode(request.toJson()));
    }

    Widget odgovorWidget(AnketaOdgovorResponse odgovor) {
      return Card(
        color: detalji && odgovor.id == anketa.korisnikAnketaOdgovor!.id
            ? const Color(0xff01A0C7)
            : Colors.white,
        child: TextButton(
          onPressed: () async {
            if (!detalji) {
              request.anketaOdgovorId = odgovor.id;
              request.korisnikId = ApiService.korisnikId;
              await getData(request);
              if (response == null) {
                _showDialog('Došlo je do greške, pokušajte opet! ');
              } else if (response is PayloadResponse) {
                _showDialog('Vaš odgovor je pohranjen!');
              } else {
                _showDialog((response as ErrorResponse).message as String);
              }
            }
          },
          child: Row(children: [
            Expanded(
              child: Text(
                odgovor.odgovor!,
                style: styleTekst,
                textAlign: TextAlign.center,
              ),
            ),
            _getPercentage(odgovor)
          ]),
        ),
      );
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text("Anketa"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Text(
              anketa.naslov!,
              style: styleNaslov,
              textAlign: TextAlign.center,
            ),
            const SizedBox(height: 60.0),
            Expanded(
              child: ListView(
                  children: anketa.odgovori!
                      .map((e) => odgovorWidget(e))
                      .toList()
                      .cast<Widget>()),
            ),
            const SizedBox(height: 60.0),
            Text(
              "Datum objave: ${DateFormat('dd/MM/yyyy').format(anketa.datum!)}",
              style: styleDatum,
              textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }
}
