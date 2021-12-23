import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;

class ApiService {
  static String? korisnickoIme;
  static String? lozinka;
  String ruta;

  ApiService({required this.ruta});

  void setParameters(String korisnickoIme, String lozinka) {
    ApiService.korisnickoIme = korisnickoIme;
    ApiService.lozinka = lozinka;
  }

  static Future<List<dynamic>?> get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = "http://192.168.0.15:5001/api/" + route;

    if (object != null) {
      baseUrl = baseUrl + '?' + queryString;
    }

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      return json.decode(response.body)['payload'] as List;
    }

    return null;
  }
}
