class FilterParams {
  String? filterValue;
  String? filterOption;
  String? columnName;

  FilterParams({this.filterValue, this.filterOption, this.columnName});

  factory FilterParams.fromJson(Map<String, dynamic> jsonObj) {
    return FilterParams(
      filterValue: jsonObj['filterValue'] as String,
      filterOption: jsonObj['filterOption'] as String,
      columnName: jsonObj['columnName'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        "filterValue": filterValue,
        "filterOption": filterOption,
        "columnName": columnName,
      };
}

enum FilterOptions {
  startswith,
  endswith,
  contains,
  doesnotcontain,
  isempty,
  isnotempty,
  isgreaterthan,
  isgreaterthanorequalto,
  islessthan,
  islessthanorequalto,
  isequalto,
  isnotequalto,
}

extension ParseToString on FilterOptions {
  String toShortString() {
    return toString().split('.').last;
  }
}
