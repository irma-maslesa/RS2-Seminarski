class AbstractResponse {
  int? responseCode;
  String? responseDetail;

  AbstractResponse({this.responseCode, this.responseDetail});

  factory AbstractResponse.fromJson(Map<String, dynamic> json) {
    return AbstractResponse(
      responseCode: int.parse(['responseCode'] as String),
      responseDetail: json['responseDetail'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        "reresponseCode": responseCode,
        "responseDetail": responseDetail,
      };
}
