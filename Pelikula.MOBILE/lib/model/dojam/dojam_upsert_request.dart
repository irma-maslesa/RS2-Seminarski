class DojamUpsertRequest {
  int? ocjena;
  String? tekst;

  int? korisnikId;
  int? projekcijaId;

  DojamUpsertRequest({
    this.ocjena,
    this.tekst,
    this.korisnikId,
    this.projekcijaId,
  });

  factory DojamUpsertRequest.fromJson(Map<String, dynamic> json) {
    return DojamUpsertRequest(
      ocjena: json['ocjena'] as int,
      tekst: json['tekst'] as String?,
      korisnikId: json['korisnikId'] as int,
      projekcijaId: json['projekcijaId'] as int,
    );
  }

  Map<String, dynamic> toJson() => {
        "ocjena": ocjena,
        "tekst": tekst,
        "korisnikId": korisnikId,
        "projekcijaId": projekcijaId,
      };
}
