import 'package:pelikula_mobile/model/projekcija/projekcija_response.dart';

class ProjekcijaTerminResponse {
  int? id;
  DateTime? termin;

  ProjekcijaResponse? projekcija;

  ProjekcijaTerminResponse({
    this.id,
    this.termin,
    this.projekcija,
  });

  factory ProjekcijaTerminResponse.fromJson(Map<String, dynamic> jsonObj) {
    return ProjekcijaTerminResponse(
      id: jsonObj['id'] as int,
      termin: DateTime.tryParse(jsonObj['termin']),
      projekcija: ProjekcijaResponse.fromJson(jsonObj['projekcija']),
    );
  }

  Map<String, dynamic> tojsonObj() => {
        "id": id,
        "termin": termin,
        "projekcija": projekcija,
      };
}
