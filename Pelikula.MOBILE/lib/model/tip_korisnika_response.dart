class TipKorisnikaResponse {
  int? id;
  String? naziv;

  TipKorisnikaResponse({this.id, this.naziv});

  factory TipKorisnikaResponse.fromJson(Map<String, dynamic> json) {
    return TipKorisnikaResponse(
      id: json['id'] as int,
      naziv: json['naziv'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "naziv": naziv,
      };
}
