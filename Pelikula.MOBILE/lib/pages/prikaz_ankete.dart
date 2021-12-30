import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/anketa_response.dart';

class PrikazAnkete extends StatelessWidget {
  final AnketaResponse anketa;

  const PrikazAnkete(this.anketa, {Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    TextStyle styleNaslov =
        const TextStyle(fontSize: 30.0, fontWeight: FontWeight.w500);
    TextStyle styleTekst =
        const TextStyle(fontSize: 25.0, fontWeight: FontWeight.w300);
    TextStyle styleDatumAutor =
        const TextStyle(fontSize: 15.0, fontWeight: FontWeight.w300);

    return Scaffold(
      appBar: AppBar(
        title: const Text("Obavijest"),
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
            Text(
              "Datum objave: ${DateFormat('dd/MM/yyyy').format(anketa.datum!)}",
              style: styleDatumAutor,
              textAlign: TextAlign.center,
            ),
            Text(
              "Autor: ${anketa.korisnik!.naziv!.split("(")[0]}",
              style: styleDatumAutor,
              textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }
}
