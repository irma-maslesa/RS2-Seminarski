import 'package:pelikula_mobile/model/response/abstract_response.dart';

class ListPayloadResponse extends AbstractResponse {
  dynamic payload;

  ListPayloadResponse(responseCode, responseDetail, {this.payload})
      : super(responseCode: responseCode, responseDetail: responseDetail);

  Type typeOf<N>() => N;

  factory ListPayloadResponse.fromJson(Map<String, dynamic> jsonObj) {
    return ListPayloadResponse(
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
