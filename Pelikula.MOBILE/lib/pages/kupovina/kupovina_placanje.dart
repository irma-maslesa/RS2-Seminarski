import 'dart:convert';
import 'dart:core';

import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_credit_card/flutter_credit_card.dart';
import 'package:pelikula_mobile/model/prodaja/prodaja_insert_request.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_upsert_request.dart';
import 'package:pelikula_mobile/pages/projekcija/projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class KupovinaPlacanje extends StatefulWidget {
  final RezervacijaUpsertRequest rezervacijaRequest;
  final ProjekcijaDetailedResponse projekcija;
  final String terminNaziv;

  const KupovinaPlacanje(
      this.rezervacijaRequest, this.projekcija, this.terminNaziv,
      {Key? key})
      : super(key: key);

  @override
  _KupovinaPlacanjeState createState() => _KupovinaPlacanjeState();
}

class _KupovinaPlacanjeState extends State<KupovinaPlacanje> {
  ProdajaInsertRequest request = ProdajaInsertRequest();
  dynamic rezervacijaResponse;
  dynamic response;

  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController terminController = TextEditingController();
  TextEditingController brojSjedistaController = TextEditingController();
  TextEditingController cijenaController = TextEditingController();

  String brojKartice = "";
  String datumIsteka = "";
  String vlasnik = "";
  String cvvKod = "";
  bool isCvvFocused = false;

  final GlobalKey<FormState> formKey = GlobalKey<FormState>();

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
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  Future<void> sendRezervacijaRequest(RezervacijaUpsertRequest request) async {
    rezervacijaResponse = await ApiService.post(
        "Rezervacija", json.encode(widget.rezervacijaRequest.toJson()));
  }

  Future<void> sendRequest(ProdajaInsertRequest request) async {
    response = await ApiService.post("Prodaja", json.encode(request.toJson()));
  }

  @override
  Widget build(BuildContext context) {
    terminController.text = widget.terminNaziv;
    brojSjedistaController.text =
        widget.rezervacijaRequest.brojSjedista.toString();
    cijenaController.text =
        "${(widget.rezervacijaRequest.brojSjedista! * widget.projekcija.cijena!).toStringAsFixed(2)} KM";

    return Scaffold(
      appBar: AppBar(
        title: Text("${widget.projekcija.film!.naslov!} - Kupovina"),
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

    final btnOdustani = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pop();
          Navigator.of(context).pop();
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
          if (formKey.currentState!.validate()) {
            await sendRezervacijaRequest(widget.rezervacijaRequest);

            if (rezervacijaResponse == null) {
              _showDialog('Došlo je do greške, pokušajte opet!');
            } else if (rezervacijaResponse is PayloadResponse) {
              var rezervacija =
                  RezervacijaResponse.fromJson(rezervacijaResponse.payload);

              request.rezervacijaId = rezervacija.id;
              request.datum = rezervacija.datum;

              await sendRequest(request);

              if (response == null) {
                _showDialog('Došlo je do greške, pokušajte opet!');
              } else if (response is PayloadResponse) {
                await _showDialog("Uspješno kupljeno!", false);

                Navigator.of(context).pushAndRemoveUntil(
                  MaterialPageRoute(
                    builder: (BuildContext context) => const Projekcije(true),
                  ),
                  (route) => false,
                );
              } else {
                _showDialog((response as ErrorResponse).message as String);
              }
            } else {
              _showDialog(
                  (rezervacijaResponse as ErrorResponse).message as String);
            }
          }
        },
        child: Text("Kupi",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    void onCreditCardModelChange(CreditCardModel? creditCardModel) {
      setState(() {
        brojKartice = creditCardModel!.cardNumber;
        datumIsteka = creditCardModel.expiryDate;
        vlasnik = creditCardModel.cardHolderName;
        cvvKod = creditCardModel.cvvCode;
        isCvvFocused = creditCardModel.isCvvFocused;
      });
    }

    return Column(children: [
      Expanded(
        child: ListView(children: [
          Row(children: [
            Expanded(
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
                  ]),
            )
          ]),
          const SizedBox(height: 15.0),
          Row(
            children: [
              Expanded(
                child: CreditCardWidget(
                  cardBgColor: const Color(0xff01A0C7),
                  cardNumber: brojKartice,
                  showBackView: isCvvFocused,
                  cvvCode: cvvKod,
                  cardHolderName: vlasnik,
                  expiryDate: datumIsteka,
                  onCreditCardWidgetChange: (ccb) {},
                ),
              ),
            ],
          ),
          Row(
            children: [
              Expanded(
                child: CreditCardForm(
                  formKey: formKey,
                  themeColor: Color(0xff01A0C7),
                  onCreditCardModelChange: onCreditCardModelChange,
                  cvvCode: cvvKod,
                  cvvValidationMessage: "Unesite validan CVV",
                  cardHolderName: vlasnik,
                  cardNumber: brojKartice,
                  numberValidationMessage: "Unesite validan broj kartice",
                  expiryDate: datumIsteka,
                  dateValidationMessage: "Unesite validan datum",
                  isHolderNameVisible: false,
                  cardNumberDecoration: InputDecoration(
                    labelText: 'Broj kartice',
                    hintText: 'XXXX XXXX XXXX XXXX',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(32.0),
                    ),
                  ),
                  expiryDateDecoration: InputDecoration(
                    labelText: 'Datum isteka',
                    hintText: 'MM/GG',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(32.0),
                    ),
                  ),
                  cvvCodeDecoration: InputDecoration(
                    labelText: 'CVV',
                    hintText: 'XXXX',
                    contentPadding:
                        const EdgeInsets.fromLTRB(10.0, 5.0, 10.0, 5.0),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(32.0),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ]),
      ),
      const SizedBox(height: 15.0),
      Row(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Expanded(child: btnOdustani),
            const SizedBox(width: 15.0),
            Expanded(child: btnDalje),
          ]),
    ]);
  }
}
