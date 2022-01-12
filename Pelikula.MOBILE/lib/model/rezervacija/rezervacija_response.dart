import 'package:pelikula_mobile/model/lov.dart';
import 'package:pelikula_mobile/model/projekcija/projekcija_termin_response.dart';
import 'package:pelikula_mobile/model/rezervacija/sjediste_rezervacija_response.dart';

class RezervacijaResponse {
  int? id;

  int? brojSjedista;
  double? cijena;
  DateTime? datum;
  DateTime? datumProjekcije;
  DateTime? datumProdano;
  DateTime? datumOtkazano;

  LoV? korisnik;
  ProjekcijaTerminResponse? projekcijaTermin;

  List<SjedisteRezervacijaResponse>? sjedista;

  RezervacijaResponse({
    this.id,
    this.brojSjedista,
    this.cijena,
    this.datum,
    this.datumProjekcije,
    this.datumProdano,
    this.datumOtkazano,
    this.korisnik,
    this.projekcijaTermin,
    this.sjedista,
  });

  factory RezervacijaResponse.fromJson(Map<String, dynamic> jsonObj) {
    return RezervacijaResponse(
      id: jsonObj['id'] as int,
      brojSjedista: jsonObj['brojSjedista'] as int,
      cijena: jsonObj['cijena'] as double,
      datum: DateTime.tryParse(jsonObj['datum']),
      datumProjekcije: DateTime.tryParse(jsonObj['datumProjekcije']),
      datumProdano: jsonObj['datumProdano'] != null
          ? DateTime.tryParse(jsonObj['datumProdano'])
          : null,
      datumOtkazano: jsonObj['datumOtkazano'] != null
          ? DateTime.tryParse(jsonObj['datumOtkazano'])
          : null,
      korisnik: LoV.fromJson(jsonObj['korisnik']),
      projekcijaTermin:
          ProjekcijaTerminResponse.fromJson(jsonObj['projekcijaTermin']),
      sjedista: (jsonObj['sjedista'] as List)
          .map((i) => SjedisteRezervacijaResponse.fromJson(i))
          .toList(),
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "cijena": cijena,
        "brojSjedista": brojSjedista,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "datumProjekcije":
            datumProjekcije == null ? null : datumProjekcije!.toIso8601String(),
        "datumProdano":
            datumProdano == null ? null : datumProdano!.toIso8601String(),
        "datumOtdatumOtkazano":
            datumProdano == null ? null : datumProdano!.toIso8601String(),
        "korisnik": korisnik,
        "projekcijaTermin": projekcijaTermin,
        "sjedista": sjedista,
      };
}
