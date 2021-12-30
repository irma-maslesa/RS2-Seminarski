import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/anketa_odgovor_response.dart';
import 'package:pelikula_mobile/model/lov.dart';

class AnketaResponse {
  int? id;
  String? naslov;
  DateTime? datum;
  DateTime? zakljucenoDatum;

  LoV? korisnik;
  List<AnketaOdgovorResponse>? odgovori;

  AnketaResponse({
    this.id,
    this.naslov,
    this.datum,
    this.zakljucenoDatum,
    this.korisnik,
    this.odgovori,
  });

  factory AnketaResponse.fromJson(Map<String, dynamic> json) {
    return AnketaResponse(
      id: json['id'] as int,
      naslov: json['naslov'] as String,
      datum: DateTime.tryParse(json['datum']),
      zakljucenoDatum: DateTime.tryParse(json['zakljucenoDatum']),
      korisnik: LoV.fromJson(json['korisnik']),
      odgovori: (json['odgovori'] as List)
          .map((i) => AnketaOdgovorResponse.fromJson(i))
          .toList(),
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "naslov": naslov,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "zakljucenoDatum":
            zakljucenoDatum == null ? null : zakljucenoDatum!.toIso8601String(),
        "korisnik": korisnik!.toJson(),
      };
}
