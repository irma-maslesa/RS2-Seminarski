class SortingParams {
  String? sortOrder;
  String? columnName;

  SortingParams({this.sortOrder, this.columnName});

  factory SortingParams.fromJson(Map<String, dynamic> jsonObj) {
    return SortingParams(
      sortOrder: jsonObj['sortOrder'] as String,
      columnName: jsonObj['columnName'] as String,
    );
  }

  Map<String, dynamic> toJson() =>
      {"sortOrder": sortOrder, "columnName": columnName};
}

enum SortOrders { ASC, DESC }
