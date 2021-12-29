import 'package:pelikula_mobile/model/response/abstract_response.dart';

class PayloadResponse extends AbstractResponse {
  dynamic payload;

  PayloadResponse(responseCode, responseDetail, {this.payload})
      : super(responseCode: responseCode, responseDetail: responseDetail);

  factory PayloadResponse.fromJson(Map<String, dynamic> jsonObj) {
    return PayloadResponse(
      jsonObj['responseCode'] as int,
      jsonObj['responseDetail'] as String,
      payload: jsonObj['payload'],
    );
  }

  @override
  Map<String, dynamic> toJson() => {
        "reresponseCode": responseCode,
        "responseDetail": responseDetail,
        "payload": payload,
      };
}
