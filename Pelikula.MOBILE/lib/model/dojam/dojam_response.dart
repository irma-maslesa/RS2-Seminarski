import 'package:pelikula_mobile/model/lov.dart';

class DojamResponse {
  int? id;
  int? ocjena;
  String? tekst;
  DateTime? datum;

  LoV? korisnik;
  LoV? projekcija;

  DojamResponse({
    this.id,
    this.ocjena,
    this.datum,
    this.tekst,
    this.korisnik,
    this.projekcija,
  });

  factory DojamResponse.fromJson(Map<String, dynamic> json) {
    return DojamResponse(
      id: json['id'] as int,
      ocjena: json['ocjena'] as int,
      tekst: json['tekst'] as String?,
      datum: DateTime.tryParse(json['datum']),
      korisnik: LoV.fromJson(json['korisnik']),
      projekcija: LoV.fromJson(json['projekcija']),
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "ocjena": ocjena,
        "tekst": tekst,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "korisnik": korisnik!.toJson(),
        "projekcija": projekcija!.toJson(),
      };
}
