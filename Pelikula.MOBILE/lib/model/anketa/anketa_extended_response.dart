import 'package:pelikula_mobile/model/anketa/anketa_odgovor_response.dart';
import 'package:pelikula_mobile/model/anketa/anketa_response.dart';
import 'package:pelikula_mobile/model/lov.dart';

class AnketaExtendedResponse extends AnketaResponse {
  AnketaOdgovorResponse? korisnikAnketaOdgovor;

  AnketaExtendedResponse(id, naslov, datum, zakljucenoDatum, korisnik, odgovori,
      {this.korisnikAnketaOdgovor})
      : super(
          id: id,
          naslov: naslov,
          datum: datum,
          zakljucenoDatum: zakljucenoDatum,
          korisnik: korisnik,
          odgovori: odgovori,
        );

  factory AnketaExtendedResponse.fromJson(Map<String, dynamic> json) {
    return AnketaExtendedResponse(
      json['id'] as int,
      json['naslov'] as String,
      DateTime.tryParse(json['datum']),
      json['zakljucenoDatum'] != null
          ? DateTime.tryParse(json['zakljucenoDatum'])
          : null,
      LoV.fromJson(json['korisnik']),
      (json['odgovori'] as List)
          .map((i) => AnketaOdgovorResponse.fromJson(i))
          .toList(),
      korisnikAnketaOdgovor: json['korisnikAnketaOdgovor'] != null
          ? AnketaOdgovorResponse.fromJson(json['korisnikAnketaOdgovor'])
          : null,
    );
  }

  @override
  Map<String, dynamic> toJson() => {
        "id": id,
        "naslov": naslov,
        "datum": datum == null ? null : datum!.toIso8601String(),
        "zakljucenoDatum":
            zakljucenoDatum == null ? null : zakljucenoDatum!.toIso8601String(),
        "korisnik": korisnik!.toJson(),
        "korisnikAnketaOdgovor": korisnikAnketaOdgovor!.toJson(),
      };
}
