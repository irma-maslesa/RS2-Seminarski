import 'package:pelikula_mobile/model/lov.dart';

class ProjekcijaResponse {
  int? id;
  double? cijena;
  DateTime? datum;
  DateTime? vrijediOd;
  DateTime? vrijediDo;

  LoV? film;
  LoV? sala;
  List<LoV>? termini;

  ProjekcijaResponse({
    this.id,
    this.cijena,
    this.datum,
    this.vrijediDo,
    this.vrijediOd,
    this.film,
    this.sala,
    this.termini,
  });

  factory ProjekcijaResponse.fromJson(Map<String, dynamic> jsonObj) {
    return ProjekcijaResponse(
      id: jsonObj['id'] as int,
      cijena: jsonObj['cijena'] as double,
      datum: DateTime.tryParse(jsonObj['datum']),
      vrijediOd: DateTime.tryParse(jsonObj['vrijediOd']),
      vrijediDo: DateTime.tryParse(jsonObj['vrijediDo']),
      film: jsonObj['film'] != null ? LoV.fromJson(jsonObj['film']) : null,
      sala: jsonObj['sala'] != null ? LoV.fromJson(jsonObj['sala']) : null,
      termini:
          (jsonObj['termini'] as List).map((i) => LoV.fromJson(i)).toList(),
    );
  }

  Map<String, dynamic> tojsonObj() => {
        "id": id,
        "cjena": cijena,
        "datum": datum,
        "vrijediOd": vrijediOd,
        "vrijediDo": vrijediDo,
        "film": film,
        "sala": sala,
        "termini": termini,
      };
}
