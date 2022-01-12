import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/helper/sorting_params.dart';
import 'package:pelikula_mobile/model/prodaja/prodaja_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/kupovina/prikaz_kupovine.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Kupovine extends StatefulWidget {
  const Kupovine({Key? key}) : super(key: key);

  @override
  _KupovineState createState() => _KupovineState();
}

class _KupovineState extends State<Kupovine> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Kupovine")),
      drawer: const MyDrawer(),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getKupovine(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Učitavanje..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else if (snapshot.data is PagedPayloadResponse) {
          return ListView(
            children: (snapshot.data.payload
                    .map((e) => ProdajaResponse.fromJson(e))
                    .toList()
                    .cast<ProdajaResponse>() as List)
                .map((e) => prodajaWidget(e))
                .toList()
                .cast<Widget>(),
          );
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

  Future<dynamic> getKupovine() async {
    List<SortingParams> sortingParams = [
      SortingParams(sortOrder: "DESC", columnName: "datum")
    ];
    String sorting = json.encode(sortingParams);
    var response = await ApiService.getPaged(
        "Prodaja/klijent/${ApiService.korisnikId}", {"sorting": sorting});
    return response;
  }

  Widget prodajaWidget(ProdajaResponse prodaja) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w500, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);
    TextStyle styleDatumAutor = const TextStyle(
        fontSize: 10.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(
              MaterialPageRoute(builder: (context) => PrikazKupovine(prodaja)));
        },
        child:
            Column(crossAxisAlignment: CrossAxisAlignment.stretch, children: [
          Text(
            prodaja.rezervacija!.projekcijaTermin!.projekcija!.film!.naziv!,
            style: styleNaslov,
          ),
          const SizedBox(height: 5.0),
          Text(
            DateFormat('dd/MM/yyyy, HH:mm')
                .format(prodaja.rezervacija!.projekcijaTermin!.termin!),
            style: styleTekst,
          ),
          const SizedBox(height: 5.0),
          Row(children: [
            Expanded(
              child: Text(
                "Broj sjedišta: ${prodaja.rezervacija!.brojSjedista}",
                style: styleTekst,
              ),
            ),
            const SizedBox(height: 10.0),
            Expanded(
              child: Text(
                "Cijena: ${prodaja.ukupnaCijena!.toStringAsFixed(2)}KM",
                style: styleTekst,
                textAlign: TextAlign.end,
              ),
            ),
          ]),
          const SizedBox(height: 10.0),
          Text(
            DateFormat('dd/MM/yyyy').format(prodaja.datum!),
            style: styleDatumAutor,
            textAlign: TextAlign.end,
          ),
        ]),
      ),
    );
  }
}
