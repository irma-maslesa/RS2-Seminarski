import 'package:pelikula_mobile/model/response/abstract_response.dart';

class PagedPayloadResponse extends AbstractResponse {
  int? recordsPerPage;
  int? page;
  int? numberOfPages;
  int? numberOfRecords;
  dynamic payload;

  PagedPayloadResponse(responseCode, responseDetail,
      {this.recordsPerPage,
      this.page,
      this.numberOfPages,
      this.numberOfRecords,
      this.payload});

  factory PagedPayloadResponse.fromJson(Map<String, dynamic> json) {
    return PagedPayloadResponse(
      json['responseCode'] as int,
      json['responseDetail'] as String,
      recordsPerPage: json['recordsPerPage'] as int,
      page: json['page'] as int,
      numberOfPages: json['numberOfPages'] as int,
      numberOfRecords: json['numberOfRecords'] as int,
      payload: json['payload'],
    );
  }

  @override
  Map<String, dynamic> toJson() => {
        "reresponseCode": responseCode,
        "responseDetail": responseDetail,
        "rerecordsPerPage": recordsPerPage,
        "papage": page,
        "numberOfPages": numberOfPages,
        "numberOfRecords": numberOfRecords,
        "payload": payload,
      };
}
