import 'dart:convert';

import 'package:pelikula_mobile/model/korisnik/tip_korisnika_response.dart';

class KorisnikResponse {
  int? id;
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;
  String? spol;
  DateTime? datumRodjenja;
  List<int>? slika;
  List<int>? slikaThumb;
  String? lozinkaHash;
  String? lozinkaSalt;
  String? lozinka;

  TipKorisnikaResponse? tipKorisnika;

  KorisnikResponse(
      {this.id,
      this.korisnickoIme,
      this.ime,
      this.prezime,
      this.email,
      this.spol,
      this.datumRodjenja,
      this.slika,
      this.slikaThumb,
      this.lozinkaHash,
      this.lozinkaSalt,
      this.lozinka,
      this.tipKorisnika});

  factory KorisnikResponse.fromJson(Map<String, dynamic> json) {
    return KorisnikResponse(
        id: json['id'] as int,
        korisnickoIme: json['korisnickoIme'] as String,
        ime: json['ime'] as String,
        prezime: json['prezime'] as String,
        email: json['prezime'] as String,
        spol: json['spol'] as String,
        datumRodjenja: DateTime.tryParse(json['datumRodjenja']),
        slika: json['slika'] != null
            ? base64.decode(json['slika'] as String)
            : null,
        slikaThumb: json['slikaThumb'] != null
            ? base64.decode(json['slikaThumb'] as String)
            : null,
        lozinkaHash: json['lozinkaHash'] as String,
        lozinkaSalt: json['lozinkaSalt'] as String,
        lozinka: json['lozinka'] != null ? json['lozinka'] as String : null,
        tipKorisnika: TipKorisnikaResponse.fromJson(json['tipKorisnika']));
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "spol": spol,
        "datumRodjenja":
            datumRodjenja == null ? null : datumRodjenja!.toIso8601String(),
        "slika": slika,
        "slikaThumb": slikaThumb,
        "lozinkaHash": lozinkaHash,
        "lozinkaSalt": lozinkaSalt,
        "lozinka": lozinka,
        "tipKorisnika": tipKorisnika!.toJson(),
      };
}
