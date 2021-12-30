class AnketaOdgovorResponse {
  int? id;
  String? odgovor;
  int? redniBroj;
  int? ukupnoIzabrano;

  AnketaOdgovorResponse({
    this.id,
    this.odgovor,
    this.redniBroj,
    this.ukupnoIzabrano,
  });

  factory AnketaOdgovorResponse.fromJson(Map<String, dynamic> json) {
    return AnketaOdgovorResponse(
      id: json['id'] as int,
      odgovor: json['odgovor'] as String,
      redniBroj: json['redniBroj'] as int,
      ukupnoIzabrano: json['ukupnoIzabrano'] as int,
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "ododgovor": odgovor,
        "reredniBroj": redniBroj,
        "ukupnoIzabrano": ukupnoIzabrano,
      };
}
