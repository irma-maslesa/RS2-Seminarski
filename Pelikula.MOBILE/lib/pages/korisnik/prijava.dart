// ignore_for_file: file_names

import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/korisnik/korisnik_response.dart';
import 'package:pelikula_mobile/model/helper/korisnik_tip.dart';
import 'package:pelikula_mobile/pages/korisnik/registracija.dart';
import 'package:pelikula_mobile/pages/projekcija/projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Prijava extends StatefulWidget {
  const Prijava({Key? key}) : super(key: key);

  @override
  _PrijavaState createState() => _PrijavaState();
}

class _PrijavaState extends State<Prijava> {
  TextStyle style = const TextStyle(fontSize: 20.0);

  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController lozinkaController = TextEditingController();
  FocusNode focusNode = FocusNode();
  KorisnikResponse? response;

  Future<void> getData() async {
    response = await ApiService.prijava();
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

  bool _isObscure = true;

  @override
  Widget build(BuildContext context) {
    const imgLogo = Image(image: AssetImage('assets/logo3.png'));
    const txtPelikula = Text(
      "Pelikula",
      style: TextStyle(
          fontFamily: 'Molle', fontSize: 40.0, fontWeight: FontWeight.w300),
    );

    final txtKorisnickoIme = TextField(
      controller: korisnickoImeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Korisničko ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtLozinka = TextField(
      controller: lozinkaController,
      focusNode: focusNode,
      obscureText: _isObscure,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          suffixIcon: IconButton(
              icon: Icon(
                _isObscure ? Icons.visibility : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscure = !_isObscure;
                });
              }),
          hintText: "Lozinka",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final btnPrijaviSe = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        minWidth: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          response = null;
          ApiService.korisnickoIme = korisnickoImeController.text;
          ApiService.lozinka = lozinkaController.text;
          await getData();
          if (response != null) {
            if (response!.tipKorisnika!.naziv != KorisnikTip.klijent) {
              korisnickoImeController.text = '';
              lozinkaController.text = '';
              _showDialog('Pristup aplikaciji nije moguć!');
            } else {
              ApiService.korisnikId = response!.id;
              Navigator.of(context).pushAndRemoveUntil(
                MaterialPageRoute(
                  builder: (BuildContext context) => const Projekcije(),
                ),
                (route) => false,
              );
            }
          } else {
            lozinkaController.text = '';
            FocusScope.of(context).requestFocus(focusNode);
            _showDialog('Neispravno korisničko ime ili lozinka!');
          }
        },
        child: Text("Prijavi se",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    const txtNemasRacun = Text(
      "Nemaš račun?",
      style: TextStyle(fontSize: 20.0, fontWeight: FontWeight.w300),
    );

    final txtRegistrujSe = InkWell(
      child: const Text(
        "Registruj se!",
        style: TextStyle(fontSize: 20.0, fontWeight: FontWeight.w500),
      ),
      onTap: () async {
        Navigator.of(context).pushAndRemoveUntil(
          MaterialPageRoute(
            builder: (BuildContext context) => const Registracija(),
          ),
          (route) => false,
        );
      },
    );

    return Scaffold(
      body: Center(
        child: Container(
          color: Colors.white,
          child: Padding(
            padding: const EdgeInsets.all(36.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                imgLogo,
                txtPelikula,
                const SizedBox(height: 15.0),
                txtKorisnickoIme,
                const SizedBox(height: 10.0),
                txtLozinka,
                const SizedBox(height: 15.0),
                btnPrijaviSe,
                const SizedBox(height: 15.0),
                Row(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    txtNemasRacun,
                    const SizedBox(width: 5.0),
                    txtRegistrujSe
                  ],
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}
