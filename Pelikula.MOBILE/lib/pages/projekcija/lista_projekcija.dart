import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/pages/projekcija/prikaz_projekcije.dart';

class ListaProjekcija extends StatefulWidget {
  final List<dynamic> projekcije;
  final bool aktivno;

  const ListaProjekcija(this.projekcije, this.aktivno, {Key? key})
      : super(key: key);

  @override
  _ListaProjekcijaState createState() => _ListaProjekcijaState();
}

class _ListaProjekcijaState extends State<ListaProjekcija> {
  @override
  Widget build(BuildContext context) {
    return ListView(
      children: (widget.projekcije
              .map((e) => ProjekcijaDetailedResponse.fromJson(e))
              .toList()
              .cast<ProjekcijaDetailedResponse>())
          .map((e) => projekcijaWidget(e))
          .toList()
          .cast<Widget>(),
    );
  }

  Widget projekcijaWidget(ProjekcijaDetailedResponse projekcija) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w700, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) =>
                  PrikazProjekcije(projekcija, widget.aktivno)));
        },
        child: Row(
          children: [
            Padding(
              padding: const EdgeInsets.all(5),
              child: projekcija.film!.plakatThumb != null &&
                      projekcija.film!.plakatThumb!.isNotEmpty
                  ? Image(
                      image: MemoryImage(
                          Uint8List.fromList(projekcija.film!.plakatThumb!)),
                      width: 135,
                    )
                  : const Image(
                      image: AssetImage('assets/no-image.png'),
                      width: 135,
                    ),
            ),
            const SizedBox(
              width: 20,
            ),
            Expanded(
              child: Column(children: [
                Text(
                  projekcija.film!.naslov!,
                  style: styleNaslov,
                  textAlign: TextAlign.center,
                ),
                Text("Cijena: ${projekcija.cijena.toString()} KM",
                    style: styleTekst),
                widget.aktivno
                    ? Text(
                        "Vrijedi do: ${DateFormat('dd/MM/yyyy').format(projekcija.vrijediDo!)}",
                        style: styleTekst)
                    : Text(
                        "Vrijedi od: ${DateFormat('dd/MM/yyyy').format(projekcija.vrijediOd!)}",
                        style: styleTekst)
              ]),
            )
          ],
        ),
      ),
    );
  }
}
