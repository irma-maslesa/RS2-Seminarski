import 'dart:core';

import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:flutter_credit_card/flutter_credit_card.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_detailed_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_upsert_request.dart';
import 'package:pelikula_mobile/pages/rezervacija/prikaz_sjedista.dart';

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
  TextStyle style = const TextStyle(fontSize: 18.0);
  TextEditingController terminController = TextEditingController();
  TextEditingController brojSjedistaController = TextEditingController();
  TextEditingController cijenaController = TextEditingController();

  String brojKartice = "";
  String datumIsteka = "";
  String vlasnik = "";
  String cvvKod = "";
  bool isCvvFocused = true;

  final GlobalKey<FormState> formKey = GlobalKey<FormState>();

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
            print('valid!');
          } else {
            print('invalid!');
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

    return Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
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
          Expanded(
            child: ListView(children: [
              Row(
                children: [
                  Expanded(
                    child: CreditCardWidget(
                      cardBgColor: const Color(0xff01A0C7),
                      cardNumber: brojKartice,
                      showBackView: false,
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
                      cardHolderDecoration: InputDecoration(
                        labelText: 'Vlasnik',
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
