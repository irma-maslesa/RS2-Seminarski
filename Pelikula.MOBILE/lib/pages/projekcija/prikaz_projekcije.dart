import 'dart:typed_data';

import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:url_launcher/url_launcher.dart';

class PrikazProjekcije extends StatefulWidget {
  final ProjekcijaDetailedResponse projekcija;

  const PrikazProjekcije(this.projekcija, {Key? key}) : super(key: key);

  @override
  State<PrikazProjekcije> createState() => _PrikazProjekcijeState();
}

class _PrikazProjekcijeState extends State<PrikazProjekcije> {
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
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          widget.projekcija.film!.naslov!,
        ),
      ),
      body: bodyWidget(),
    );
  }

  Widget bodyWidget() {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 50.0, fontWeight: FontWeight.w700, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);
    TextStyle styleLink = const TextStyle(
        fontSize: 15.0, fontWeight: FontWeight.w300, color: Colors.blue);

    const sizedBoxWidth = SizedBox(width: 15);
    const sizedBoxWHeight = SizedBox(height: 15);

    return Padding(
      padding: const EdgeInsets.fromLTRB(15, 10, 15, 10),
      child: Column(children: [
        //Slika, linkovi, naslov
        Row(children: [
          widget.projekcija.film!.plakatThumb != null &&
                  widget.projekcija.film!.plakatThumb!.isNotEmpty
              ? Image(
                  image: MemoryImage(
                      Uint8List.fromList(widget.projekcija.film!.plakatThumb!)),
                  width: 135,
                )
              : const Image(
                  image: AssetImage('assets/no-image.png'),
                  width: 135,
                ),
          sizedBoxWidth,
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    RichText(
                      text: TextSpan(
                          text: "Trailer",
                          style: styleLink,
                          recognizer: TapGestureRecognizer()
                            ..onTap = () async {
                              if (await canLaunch(
                                  widget.projekcija.film!.videoLink!)) {
                                launch(widget.projekcija.film!.videoLink!);
                              } else {
                                _showDialog("Link trenutno nije dostupan!");
                              }
                            }),
                    ),
                    const SizedBox(width: 10.0),
                    RichText(
                      text: TextSpan(
                          text: "IMDB",
                          style: styleLink,
                          recognizer: TapGestureRecognizer()
                            ..onTap = () async {
                              if (await canLaunch(
                                  widget.projekcija.film!.imdbLink!)) {
                                launch(widget.projekcija.film!.imdbLink!);
                              } else {
                                _showDialog("Link trenutno nije dostupan!");
                              }
                            }),
                    ),
                  ],
                ),
                Text(widget.projekcija.film!.naslov!,
                    style: styleNaslov, textAlign: TextAlign.center),
              ],
            ),
          ),
        ]),
        sizedBoxWHeight,
        //Cards
        Row(children: [
          Expanded(
            child: Card(
              child: Padding(
                padding: const EdgeInsets.all(5),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text("Trajanje: ${widget.projekcija.film!.trajanje} min"),
                    Text("Žanr: ${widget.projekcija.film!.zanr!.naziv}"),
                    Text("Režiser: ${widget.projekcija.film!.reditelj!.naziv}"),
                    Text(
                        "Godina snimanja: ${widget.projekcija.film!.godinaSnimanja}")
                  ],
                ),
              ),
            ),
          ),
          Expanded(
            child: Card(
              child: Padding(
                padding: const EdgeInsets.all(5),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text("Cijena: ${widget.projekcija.cijena} KM"),
                    Text("Sala: ${widget.projekcija.sala!.naziv}"),
                    Text(
                        "Vrijedi do: ${DateFormat('dd/MM/yyyy').format(widget.projekcija.vrijediDo!)}"),
                  ],
                ),
              ),
            ),
          ),
        ]),
        sizedBoxWHeight,
        //Sadrzaj
        Expanded(
          child: ListView(children: [
            Text(
              widget.projekcija.film!.sadrzaj!,
              style: styleTekst,
              textAlign: TextAlign.justify,
            )
          ]),
        ),
        sizedBoxWHeight,
        //Buttoni
        Row(children: [
          Expanded(
            child: Material(
              elevation: 5.0,
              borderRadius: BorderRadius.circular(30.0),
              color: const Color(0xff01A0C7),
              child: MaterialButton(
                minWidth: MediaQuery.of(context).size.width,
                padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                onPressed: () {},
                child: Text("Rezerviši",
                    textAlign: TextAlign.center,
                    style: styleTekst.copyWith(
                        color: Colors.white, fontWeight: FontWeight.bold)),
              ),
            ),
          ),
          const SizedBox(width: 5),
          Expanded(
            child: Material(
              elevation: 5.0,
              borderRadius: BorderRadius.circular(30.0),
              color: const Color(0xff01A0C7),
              child: MaterialButton(
                minWidth: MediaQuery.of(context).size.width,
                padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                onPressed: () {},
                child: Text("Kupi",
                    textAlign: TextAlign.center,
                    style: styleTekst.copyWith(
                        color: Colors.white, fontWeight: FontWeight.bold)),
              ),
            ),
          ),
          const SizedBox(width: 5),
          Expanded(
            child: Material(
              elevation: 5.0,
              borderRadius: BorderRadius.circular(30.0),
              color: const Color(0xff01A0C7),
              child: MaterialButton(
                minWidth: MediaQuery.of(context).size.width,
                padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                onPressed: () {},
                child: Text("Ocijeni",
                    textAlign: TextAlign.center,
                    style: styleTekst.copyWith(
                        color: Colors.white, fontWeight: FontWeight.bold)),
              ),
            ),
          )
        ]),
      ]),
    );
  }
}
