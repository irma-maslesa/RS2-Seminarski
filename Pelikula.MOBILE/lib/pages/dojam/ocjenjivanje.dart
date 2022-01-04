import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:pelikula_mobile/model/dojam/dojam_response.dart';
import 'package:pelikula_mobile/model/dojam/dojam_upsert_request.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Ocjenjivanje extends StatefulWidget {
  final int projekcijaId;
  final String filmNaslov;

  const Ocjenjivanje(this.projekcijaId, this.filmNaslov, {Key? key})
      : super(key: key);

  @override
  _OcjenjivanjeState createState() => _OcjenjivanjeState();
}

class _OcjenjivanjeState extends State<Ocjenjivanje> {
  DojamUpsertRequest request = DojamUpsertRequest();
  dynamic response;
  int? dojamId;

  double rating = 0;
  TextStyle styleNaslov = const TextStyle(
      fontSize: 50.0, fontWeight: FontWeight.w700, color: Colors.black);
  TextStyle styleTekst = const TextStyle(
      fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);

  TextEditingController tekstController = TextEditingController();

  Future<void> sendCreateDojamRequest(DojamUpsertRequest request) async {
    response = await ApiService.post("Dojam", json.encode(request.toJson()));
  }

  Future<void> sendUpdateDojamRequest(DojamUpsertRequest request) async {
    response =
        await ApiService.put("Dojam", dojamId!, json.encode(request.toJson()));
  }

  Future<void> getData() async {
    response = await ApiService.getDojam(widget.projekcijaId);

    return response;
  }

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
        title: const Text("Ostavi dojam"),
      ),
      body: body(),
      floatingActionButton: Material(
        elevation: 5.0,
        borderRadius: BorderRadius.circular(30.0),
        color: const Color(0xff01A0C7),
        child: MaterialButton(
          padding: const EdgeInsets.fromLTRB(40.0, 15.0, 40.0, 15.0),
          onPressed: () async {
            request.projekcijaId = widget.projekcijaId;
            request.korisnikId = ApiService.korisnikId;
            print(rating);
            request.ocjena = rating.round();
            request.tekst = tekstController.text.trim().isNotEmpty
                ? tekstController.text
                : null;

            dojamId == null
                ? await sendCreateDojamRequest(request)
                : await sendUpdateDojamRequest(request);

            if (response == null) {
              _showDialog('Došlo je do greške, pokušajte opet! ');
            } else if (response is PayloadResponse) {
              dojamId == null
                  ? await _showDialog('Vaša ocjena je pohranjena!')
                  : await _showDialog('Vaša ocjena je uređena!');
              Navigator.of(context).pop();
            } else {
              _showDialog((response as ErrorResponse).message as String);
            }
          },
          child: Text("Ocijeni",
              textAlign: TextAlign.center,
              style: styleTekst.copyWith(
                  color: Colors.white, fontWeight: FontWeight.bold)),
        ),
      ),
    );
  }

  Widget body() {
    return FutureBuilder(
        future: getData(),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: Text("Učitavanje..."));
          } else if (snapshot.hasError) {
            return const Center(child: Text("Greška pri učitavanju."));
          } else if (snapshot.data is PayloadResponse) {
            if ((response as PayloadResponse).payload != null) {
              var dojam =
                  DojamResponse.fromJson((response as PayloadResponse).payload);
              rating = dojam.ocjena!.toDouble();
              if (dojam.tekst != null) {
                tekstController.text = dojam.tekst!;
              }

              dojamId = dojam.id;
            }
            return Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    widget.filmNaslov,
                    style: styleNaslov,
                  ),
                  const SizedBox(height: 15),
                  RatingBar(
                      initialRating: rating,
                      direction: Axis.horizontal,
                      allowHalfRating: false,
                      itemCount: 5,
                      ratingWidget: RatingWidget(
                        full: const Icon(Icons.star, color: Color(0xff01A0C7)),
                        half: const Icon(Icons.star_half,
                            color: Color(0xff01A0C7)),
                        empty: const Icon(Icons.star_outline,
                            color: Color(0xff01A0C7)),
                      ),
                      onRatingUpdate: (value) {
                        rating = value;
                      }),
                  const SizedBox(
                    height: 30.0,
                  ),
                  Expanded(
                    child: Padding(
                      padding: const EdgeInsets.fromLTRB(20, 10, 20, 10),
                      child: TextField(
                        maxLines: null,
                        controller: tekstController,
                        obscureText: false,
                        style: styleTekst,
                        decoration: InputDecoration(
                            contentPadding: const EdgeInsets.fromLTRB(
                                20.0, 30.0, 20.0, 30.0),
                            hintText: "Dojam",
                            border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(32.0))),
                      ),
                    ),
                  ),
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
}
