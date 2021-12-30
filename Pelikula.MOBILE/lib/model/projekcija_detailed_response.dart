import 'package:pelikula_mobile/model/film_response.dart';
import 'package:pelikula_mobile/model/lov.dart';

class ProjekcijaDetailedResponse {
  int? id;
  double? cijena;
  DateTime? datum;
  DateTime? vrijediOd;
  DateTime? vrijediDo;

  FilmResponse? film;
  LoV? sala;
  List<LoV>? termini;

  ProjekcijaDetailedResponse({
    this.id,
    this.cijena,
    this.datum,
    this.vrijediDo,
    this.vrijediOd,
    this.film,
    this.sala,
    this.termini,
  });

  factory ProjekcijaDetailedResponse.fromJson(Map<String, dynamic> jsonObj) {
    return ProjekcijaDetailedResponse(
      id: jsonObj['id'] as int,
      cijena: jsonObj['cijena'] as double,
      datum: DateTime.tryParse(jsonObj['datum']),
      vrijediOd: DateTime.tryParse(jsonObj['vrijediOd']),
      vrijediDo: DateTime.tryParse(jsonObj['vrijediDo']),
      film: FilmResponse.fromJson(jsonObj['film']),
      sala: LoV.fromJson(jsonObj['sala']),
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
