import 'package:pelikula_mobile/model/lov.dart';

class FilmGlumacResponse {
  int? id;
  LoV? filmskaLicnost;

  FilmGlumacResponse({this.id, this.filmskaLicnost});

  factory FilmGlumacResponse.fromJson(Map<String, dynamic> jsonObj) {
    return FilmGlumacResponse(
      id: jsonObj['id'] as int,
      filmskaLicnost: LoV.fromJson(jsonObj['filmskaLicnost']),
    );
  }

  Map<String, dynamic> tojsonObj() => {
        "id": id,
        "filmskaLicnost": filmskaLicnost,
      };
}
