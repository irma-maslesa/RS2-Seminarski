import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/obavijest/obavijest_response.dart';

class PrikazObavijesti extends StatelessWidget {
  final ObavijestResponse obavijest;

  const PrikazObavijesti(this.obavijest, {Key? key}) : super(key: key);

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
              obavijest.naslov!,
              style: styleNaslov,
              textAlign: TextAlign.center,
            ),
            const SizedBox(height: 20.0),
            Text(
              obavijest.tekst!,
              style: styleTekst,
              textAlign: TextAlign.center,
            ),
            const SizedBox(height: 60.0),
            Text(
              "Datum objave: ${DateFormat('dd/MM/yyyy').format(obavijest.datum!)}",
              style: styleDatumAutor,
              textAlign: TextAlign.center,
            ),
            Text(
              "Autor: ${obavijest.korisnik!.naziv!.split("(")[0]}",
              style: styleDatumAutor,
              textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }
}
