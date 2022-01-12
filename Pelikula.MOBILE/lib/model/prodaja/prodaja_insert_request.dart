class ProdajaInsertRequest {
  int? korisnikId;
  int? rezervacijaId;
  DateTime? datum;

  List<dynamic>? prodajaArtikal;

  ProdajaInsertRequest({
    this.korisnikId,
    this.rezervacijaId,
    this.datum,
    this.prodajaArtikal,
  });

  factory ProdajaInsertRequest.fromJson(Map<String, dynamic> json) {
    return ProdajaInsertRequest(
      korisnikId: json['korisnikId'] != null ? json['korisnikId'] as int : null,
      rezervacijaId: json['rezervacijaId'] as int,
      datum: DateTime.tryParse(json['datum']),
      prodajaArtikal: json['prodajaArtikal'] != null
          ? json['prodajaArtikal'] as List
          : null,
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnikId": korisnikId,
        "rezervacijaId": rezervacijaId,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "prodajaArtikal": prodajaArtikal,
      };
}
