import 'package:pelikula_mobile/model/lov.dart';

class ObavijestResponse {
  int? id;
  String? naslov;
  String? tekst;
  DateTime? datum;

  LoV? korisnik;

  ObavijestResponse({
    this.id,
    this.naslov,
    this.tekst,
    this.datum,
    this.korisnik,
  });

  factory ObavijestResponse.fromJson(Map<String, dynamic> json) {
    return ObavijestResponse(
        id: json['id'] as int,
        naslov: json['naslov'] as String,
        tekst: json['tekst'] as String,
        datum: DateTime.tryParse(json['datum']),
        korisnik: LoV.fromJson(json['korisnik']));
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "naslov": naslov,
        "tekst": tekst,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "korisnik": korisnik!.toJson(),
      };
}
