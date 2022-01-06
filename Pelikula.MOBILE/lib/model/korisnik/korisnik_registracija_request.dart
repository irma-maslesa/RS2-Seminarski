import 'dart:convert';

class KorisnikRegistracijaRequest {
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;
  String? spol;
  DateTime? datumRodjenja;
  String? lozinka;

  KorisnikRegistracijaRequest(
      {this.korisnickoIme,
      this.ime,
      this.prezime,
      this.email,
      this.spol,
      this.datumRodjenja,
      this.lozinka});

  factory KorisnikRegistracijaRequest.fromJson(Map<String, dynamic> json) {
    return KorisnikRegistracijaRequest(
      korisnickoIme: json['korisnickoIme'] as String,
      ime: json['ime'] as String,
      prezime: json['prezime'] as String,
      email: json['prezime'] as String,
      spol: json['spol'] as String,
      datumRodjenja: DateTime.tryParse(json['datumRodjenja']),
      lozinka: json['lozinka'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "spol": spol,
        "datumRodjenja":
            datumRodjenja == null ? null : datumRodjenja!.toIso8601String(),
        "lozinka": lozinka,
      };
}
