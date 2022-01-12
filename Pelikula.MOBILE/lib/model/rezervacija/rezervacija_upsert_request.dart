class RezervacijaUpsertRequest {
  int? brojSjedista;
  DateTime? datum;
  DateTime? datumProdano;
  DateTime? datumOtkazano;

  int? korisnikId;
  int? projekcijaTerminId;

  List<int>? sjedistaIds;

  RezervacijaUpsertRequest({
    this.brojSjedista,
    this.datum,
    this.datumProdano,
    this.datumOtkazano,
    this.korisnikId,
    this.projekcijaTerminId,
    this.sjedistaIds,
  });

  factory RezervacijaUpsertRequest.fromJson(Map<String, dynamic> jsonObj) {
    return RezervacijaUpsertRequest(
      brojSjedista: jsonObj['brojSjedista'] as int,
      datum: DateTime.tryParse(jsonObj['datum']),
      datumProdano: DateTime.tryParse(jsonObj['datumProdano']),
      datumOtkazano: DateTime.tryParse(jsonObj['datumOtkazano']),
      korisnikId: jsonObj['korisnikId'] as int,
      projekcijaTerminId: jsonObj['projekcijaTerminId'] as int,
      sjedistaIds:
          (jsonObj['sjedistaIds'] as List).map((e) => int.parse(e)).toList(),
    );
  }

  Map<String, dynamic> toJson() => {
        "brojSjedista": brojSjedista,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "datumProdano":
            datumProdano == null ? null : datumProdano!.toIso8601String(),
        "datumOtdatumOtkazano":
            datumProdano == null ? null : datumProdano!.toIso8601String(),
        "korisnikId": korisnikId,
        "projekcijaTerminId": projekcijaTerminId,
        "sjedistaIds": sjedistaIds,
      };
}
