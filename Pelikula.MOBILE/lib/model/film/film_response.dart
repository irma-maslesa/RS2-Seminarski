import 'dart:convert';

import 'package:pelikula_mobile/model/film/film_glumac_response.dart';
import 'package:pelikula_mobile/model/lov.dart';

class FilmResponse {
  int? id;
  String? naslov;
  int? trajanje;
  int? godinaSnimanja;
  String? sadrzaj;
  String? videoLink;
  String? imdbLink;
  List<int>? plakat;
  List<int>? plakatThumb;

  LoV? reditelj;
  LoV? zanr;
  List<FilmGlumacResponse>? glumci;

  FilmResponse(
      {this.id,
      this.naslov,
      this.trajanje,
      this.godinaSnimanja,
      this.sadrzaj,
      this.videoLink,
      this.imdbLink,
      this.plakat,
      this.plakatThumb,
      this.reditelj,
      this.zanr,
      this.glumci});

  factory FilmResponse.fromJson(Map<String?, dynamic> jsonObj) {
    return FilmResponse(
      id: jsonObj['id'] as int,
      naslov: jsonObj['naslov'] as String,
      trajanje: jsonObj['trajanje'] as int,
      godinaSnimanja: jsonObj['godinaSnimanja'] as int,
      sadrzaj: jsonObj['sadrzaj'] as String,
      videoLink: jsonObj['videoLink'] as String,
      imdbLink: jsonObj['imdbLink'] as String,
      plakat: jsonObj['plakat'] != null
          ? base64.decode(jsonObj['plakat'] as String)
          : null,
      plakatThumb: jsonObj['plakatThumb'] != null
          ? base64.decode(jsonObj['plakatThumb'] as String)
          : null,
      reditelj: LoV.fromJson(jsonObj['reditelj']),
      zanr: LoV.fromJson(jsonObj['zanr']),
      glumci: (jsonObj['glumci'] as List)
          .map((i) => FilmGlumacResponse.fromJson(i))
          .toList(),
    );
  }

  Map<String?, dynamic> tojsonObj() => {
        "id": id,
        "naslov": naslov,
        "trajanje": trajanje,
        "godinaSnimanja": godinaSnimanja,
        "sadrzaj": sadrzaj,
        "videoLink": videoLink,
        "imdbLink": imdbLink,
        "plakat": plakat,
        "plakatThumb": plakatThumb,
        "reditelj": reditelj,
        "zanr": zanr,
        "glumci": glumci,
      };
}
