import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/list_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/projekcija/lista_projekcija.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Preporuke extends StatefulWidget {
  const Preporuke({Key? key}) : super(key: key);

  @override
  _PreporukeState createState() => _PreporukeState();
}

class _PreporukeState extends State<Preporuke> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Preporuke"),
      ),
      drawer: const MyDrawer(),
      body: Column(children: [Expanded(child: body())]),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getPreporuke(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: Text("Učitavanje..."),
          );
        } else if (snapshot.hasError) {
          return const Center(
            child: Text("Greška pri učitavanju."),
          );
        } else if (snapshot.data is ListPayloadResponse &&
            snapshot.data.payload.length > 0) {
          return ListaProjekcija(snapshot.data.payload, true);
        } else if (snapshot.data is ListPayloadResponse &&
            snapshot.data.payload.length == 0) {
          return Center(child: const Text("Nema preporučenih projekcija"));
        } else if (snapshot.data is ErrorResponse) {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        } else {
          return const Center(
            child: Text("Došlo je do greške!"),
          );
        }
      },
    );
  }

  Future<dynamic> getPreporuke() async {
    dynamic response = await ApiService.get(
      "Projekcija/preporucene/${ApiService.korisnikId}",
    );

    return response;
  }
}
