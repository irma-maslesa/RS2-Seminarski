import 'dart:convert';

import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/korisnik/korisnik_registracija_request.dart';
import 'package:pelikula_mobile/model/korisnik/korisnik_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';
import 'package:pelikula_mobile/pages/korisnik/prijava.dart';
import 'package:pelikula_mobile/pages/projekcija/projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Registracija extends StatefulWidget {
  const Registracija({Key? key}) : super(key: key);

  @override
  _RegistracijaState createState() => _RegistracijaState();
}

class _RegistracijaState extends State<Registracija> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController dtpDatumRodjenjaController = TextEditingController();
  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController lozinkaController = TextEditingController();
  FocusNode focusNode = FocusNode();

  dynamic response;
  KorisnikRegistracijaRequest request = KorisnikRegistracijaRequest();

  DateTime _odabraniDatumRodjenja = DateTime.now();

  List<DropdownMenuItem> spolovi = [
    DropdownMenuItem(
        child: Text(
          "Muško",
          style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
        ),
        value: 'M'),
    DropdownMenuItem(
        child: Text(
          "Žensko",
          style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
        ),
        value: 'Ž'),
  ];
  String? _odabraniSpol;

  final _formKey = GlobalKey<FormState>();
  final _obaveznoPolje = "Polje je obavezno";

  Future<void> getData(KorisnikRegistracijaRequest request) async {
    response = await ApiService.registracija(json.encode(request.toJson()));
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

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: _odabraniDatumRodjenja,
        firstDate: DateTime(1900, 1),
        lastDate: DateTime.now());

    if (picked != null && picked != _odabraniDatumRodjenja) {
      setState(() {
        _odabraniDatumRodjenja = picked;
        dtpDatumRodjenjaController.text =
            "${_odabraniDatumRodjenja.toLocal()}".split(' ')[0];
      });
    }
  }

  bool _isObscure = true;

  @override
  Widget build(BuildContext context) {
    const imgLogo = Image(
      image: AssetImage('assets/logo3.png'),
      width: 85,
    );
    const txtPelikula = Text(
      "Pelikula",
      style: TextStyle(fontFamily: 'Molle', fontSize: 40.0),
    );

    final txtIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: imeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtPrezime = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: prezimeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Prezime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtMail = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (!EmailValidator.validate(value)) {
          return "Neispravan format!";
        } else {
          return null;
        }
      },
      controller: emailController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Email",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final dtpDatumRodjenja = InkWell(
      child: IgnorePointer(
        child: TextFormField(
          validator: (value) {
            return value == null || value.isEmpty ? _obaveznoPolje : null;
          },
          controller: dtpDatumRodjenjaController,
          obscureText: false,
          style: style,
          decoration: InputDecoration(
              contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
              hintText: "Datum rođenja",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(32.0))),
        ),
      ),
      onTap: () {
        _selectDate(context);
      },
    );

    final txtKorisnickoIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: korisnickoImeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Korisničko ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtLozinka = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (value.length < 6) {
          return "Minimalna dužina 6!";
        } else if (!value.contains(RegExp(r'[0-9]')) ||
            !value.contains(RegExp(r'[a-zA-Z]'))) {
          return "Obavezno jedno slovo i broj!";
        } else {
          return null;
        }
      },
      controller: lozinkaController,
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

    final btnOdustani = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pushAndRemoveUntil(
            MaterialPageRoute(
              builder: (BuildContext context) => const Prijava(),
            ),
            (route) => false,
          );
        },
        child: Text("Odustani",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: const Color(0xff01A0C7), fontWeight: FontWeight.bold)),
      ),
    );
    final btnRegistrujSe = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          if (_formKey.currentState!.validate()) {
            response = null;
            request.ime = imeController.text;
            request.prezime = prezimeController.text;
            request.email = emailController.text;
            request.datumRodjenja = _odabraniDatumRodjenja;
            request.spol = _odabraniSpol;
            request.korisnickoIme = korisnickoImeController.text;
            request.lozinka = lozinkaController.text;
            ApiService.korisnickoIme = korisnickoImeController.text;
            await getData(request);
            if (response == null) {
              _showDialog('Došlo je do greške, pokušajte opet! ');
            } else if (response is PayloadResponse) {
              var korisnik = KorisnikResponse.fromJson(response.payload);
              ApiService.setParameters(korisnik.id!, korisnik.korisnickoIme!,
                  lozinkaController.text);
              Navigator.of(context).pushAndRemoveUntil(
                MaterialPageRoute(
                  builder: (BuildContext context) => const Projekcije(),
                ),
                (route) => false,
              );
            } else {
              _showDialog((response as ErrorResponse).message as String);
            }
          }
        },
        child: Text("Registruj se",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
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
                  //Logo
                  Row(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: const [
                        Flexible(child: imgLogo),
                        SizedBox(width: 15.0),
                        txtPelikula,
                      ]),
                  const SizedBox(height: 20.0),
                  Form(
                    key: _formKey,
                    autovalidateMode: AutovalidateMode.onUserInteraction,
                    child: Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          //Ime i prezime
                          Row(
                            children: [
                              Flexible(child: txtIme),
                              const SizedBox(
                                width: 5.0,
                              ),
                              Flexible(child: txtPrezime)
                            ],
                          ),
                          const SizedBox(height: 5.0),
                          txtMail,
                          const SizedBox(height: 5.0),
                          //Datum rodjenja i spol
                          Row(
                            children: [
                              Flexible(child: dtpDatumRodjenja),
                              const SizedBox(
                                width: 5.0,
                              ),
                              Flexible(child: ddSpol())
                            ],
                          ),
                          const SizedBox(height: 5.0),
                          //Korisnicko ime i lozinka
                          Row(
                            children: [
                              Flexible(child: txtKorisnickoIme),
                              const SizedBox(
                                width: 5.0,
                              ),
                              Flexible(child: txtLozinka)
                            ],
                          ),
                          const SizedBox(height: 15.0),
                          //Buttoni
                          Row(
                              crossAxisAlignment: CrossAxisAlignment.center,
                              mainAxisAlignment: MainAxisAlignment.center,
                              children: [
                                btnOdustani,
                                const SizedBox(width: 15.0),
                                Expanded(child: btnRegistrujSe)
                              ]),
                        ]),
                  ),
                ]),
          ),
        ),
      ),
    );
  }

  Widget ddSpol() {
    return DropdownButtonFormField<dynamic>(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      hint: Text(
        'Spol',
        style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
      ),
      isExpanded: true,
      items: spolovi,
      onChanged: (newVal) {
        setState(() {
          _odabraniSpol = newVal;
        });
      },
      value: _odabraniSpol,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
  }
}
