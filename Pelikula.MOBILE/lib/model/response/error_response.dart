import 'package:pelikula_mobile/model/response/abstract_response.dart';

class ErrorResponse extends AbstractResponse {
  String? message;

  ErrorResponse(responseCode, responseDetail, {this.message})
      : super(responseCode: responseCode, responseDetail: responseDetail);

  factory ErrorResponse.fromJson(Map<String, dynamic> json) {
    return ErrorResponse(
      int.parse(json['responseCode'] as String),
      json['responseDetail'] as String,
      message: json['message'] as String,
    );
  }

  @override
  Map<String, dynamic> toJson() => {
        "reresponseCode": responseCode,
        "responseDetail": responseDetail,
        "message": message,
      };
}
