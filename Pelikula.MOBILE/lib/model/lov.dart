class LoV {
  int? id;
  String? naziv;

  LoV({this.id, this.naziv});

  factory LoV.fromJson(Map<String, dynamic> json) {
    return LoV(
      id: json['id'],
      naziv: json['naziv'].toString(),
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "naziv": naziv,
      };
}
