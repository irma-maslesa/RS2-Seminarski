import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:pelikula_mobile/model/korisnik_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/model/response/payload_response.dart';

class ApiService {
  static String? korisnickoIme;
  static String? lozinka;
  String ruta;
  static const String _baseRoute = "http://192.168.0.15:5001/api/";

  ApiService({required this.ruta});

  void setParameters(String korisnickoIme, String lozinka) {
    ApiService.korisnickoIme = korisnickoIme;
    ApiService.lozinka = lozinka;
  }

  static Future<KorisnikResponse?> prijava() async {
    String baseUrl = _baseRoute + "Korisnik/autentifikacija";

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      return KorisnikResponse.fromJson(json.decode(response.body)['payload']);
    }

    return null;
  }

  static Future<dynamic> registracija(String body) async {
    String baseUrl = _baseRoute + "Korisnik/registracija";

    final response = await http.post(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8'
      },
      body: body,
    );

    if (response.statusCode == 200) {
      return PayloadResponse.fromJson(json.decode(response.body));
    } else if (response.statusCode == 400) {
      return ErrorResponse.fromJson(json.decode(response.body));
    } else {
      return null;
    }
  }

  static Future<dynamic> get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = _baseRoute + route;

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
      return PagedPayloadResponse.fromJson(json.decode(response.body));
    }

    return ErrorResponse.fromJson(json.decode(response.body));
  }

  static Future<dynamic> getById(String route, dynamic id) async {
    String baseUrl = _baseRoute + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body)['payload'];
    }

    return null;
  }

  static Future<dynamic> post(String route, String body) async {
    String baseUrl = _baseRoute + route;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.post(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    if (response.statusCode == 201) {
      return json.decode(response.body)['payload'];
    }

    return null;
  }

  static Future<dynamic> put(String route, dynamic id, String body) async {
    String baseUrl = _baseRoute + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.put(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    if (response.statusCode == 201) {
      return json.decode(response.body)['payload'];
    }

    return null;
  }

  static Future<String?> delete(String route, dynamic id) async {
    String baseUrl = _baseRoute + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$korisnickoIme:$lozinka'));

    final response = await http.delete(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body)['payload'];
    }

    return null;
  }
}
