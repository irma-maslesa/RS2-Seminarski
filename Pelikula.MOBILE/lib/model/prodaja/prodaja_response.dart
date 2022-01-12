import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_response.dart';

class ProdajaResponse {
  int? id;
  String? brojRacuna;
  DateTime? datum;

  double? ukupnaCijena;

  LoV? korisnik;
  RezervacijaResponse? rezervacija;

  List<dynamic>? prodajaArtikal;

  ProdajaResponse({
    this.id,
    this.brojRacuna,
    this.datum,
    this.ukupnaCijena,
    this.korisnik,
    this.rezervacija,
    this.prodajaArtikal,
  });

  factory ProdajaResponse.fromJson(Map<String, dynamic> json) {
    return ProdajaResponse(
      id: json['id'] as int,
      brojRacuna: json['brojRacuna'] as String,
      datum: DateTime.tryParse(json['datum']),
      ukupnaCijena: json['ukupnaCijena'] as double,
      korisnik:
          json['korisnik'] != null ? LoV.fromJson(json['korisnik']) : null,
      rezervacija: json['rezervacija'] != null
          ? RezervacijaResponse.fromJson(json['rezervacija'])
          : null,
      prodajaArtikal: json['prodajaArtikal'] != null
          ? json['prodajaArtikal'] as List
          : null,
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "brojRacuna": brojRacuna,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "ukupnaCijena": ukupnaCijena,
        "korisnik": korisnik == null ? null : korisnik,
        "rezervacija": rezervacija,
        "prodajaArtikal": prodajaArtikal,
      };
}
