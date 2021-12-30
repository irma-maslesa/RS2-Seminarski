class AnketaOdgovorKorisnikInsertRequest {
  int? anketaOdgovorId;
  int? korisnikId;

  AnketaOdgovorKorisnikInsertRequest({this.anketaOdgovorId, this.korisnikId});

  factory AnketaOdgovorKorisnikInsertRequest.fromJson(
      Map<String, dynamic> json) {
    return AnketaOdgovorKorisnikInsertRequest(
      anketaOdgovorId: json['anketaOdgovorId'] as int,
      korisnikId: json['korisnikId'] as int,
    );
  }

  Map<String, dynamic> toJson() => {
        "anketaOdgovorId": anketaOdgovorId,
        "korisnikId": korisnikId,
      };
}
