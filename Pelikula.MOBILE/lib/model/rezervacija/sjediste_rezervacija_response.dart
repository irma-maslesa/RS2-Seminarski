import '../lov.dart';

class SjedisteRezervacijaResponse {
  int? id;
  LoV? sjediste;

  SjedisteRezervacijaResponse({
    this.id,
    this.sjediste,
  });

  factory SjedisteRezervacijaResponse.fromJson(Map<String, dynamic> jsonObj) {
    return SjedisteRezervacijaResponse(
        id: jsonObj['id'] as int, sjediste: LoV.fromJson(jsonObj['sjediste']));
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "sjediste": sjediste,
      };
}
