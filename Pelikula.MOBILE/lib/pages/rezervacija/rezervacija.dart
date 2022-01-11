import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/helper/filter_params.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/model/rezervacija/rezervacija_response.dart';
import 'package:pelikula_mobile/pages/helper/drawer.dart';
import 'package:pelikula_mobile/pages/rezervacija/prikaz_rezervacije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Rezervacije extends StatefulWidget {
  const Rezervacije({Key? key}) : super(key: key);

  @override
  _RezervacijeState createState() => _RezervacijeState();
}

class _RezervacijeState extends State<Rezervacije> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Rezervacije")),
      drawer: const MyDrawer(),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getRezervacije(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Učitavanje..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else if (snapshot.data is PagedPayloadResponse) {
          return ListView(
            children: (snapshot.data.payload
                    .map((e) => RezervacijaResponse.fromJson(e))
                    .toList()
                    .cast<RezervacijaResponse>() as List)
                .map((e) => rezervacijaWidget(e))
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

  Future<dynamic> getRezervacije() async {
    List<FilterParams> filterParams = [
      FilterParams(
        columnName: "korisnikId",
        filterValue: ApiService.korisnikId.toString(),
        filterOption: FilterOptions.isequalto.toShortString(),
      )
    ];
    String filter = json.encode(filterParams);
    var response = await ApiService.getPaged("Rezervacija", {"filter": filter});
    return response;
  }

  Widget rezervacijaWidget(RezervacijaResponse rezervacija) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w500, color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontSize: 20.0, fontWeight: FontWeight.w300, color: Colors.black);
    TextStyle styleDatumAutor = const TextStyle(
        fontSize: 10.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => PrikazRezervacije(rezervacija)));
        },
        child:
            Column(crossAxisAlignment: CrossAxisAlignment.stretch, children: [
          Text(
            rezervacija.projekcijaTermin!.projekcija!.film!.naziv!,
            style: styleNaslov,
          ),
          const SizedBox(height: 5.0),
          Text(
            DateFormat('dd/MM/yyyy, HH:mm')
                .format(rezervacija.datumProjekcije!),
            style: styleTekst,
          ),
          const SizedBox(height: 5.0),
          Row(children: [
            Expanded(
              child: Text(
                "Broj sjedišta: ${rezervacija.brojSjedista}",
                style: styleTekst,
              ),
            ),
            const SizedBox(height: 10.0),
            Expanded(
              child: Text(
                "Cijena: ${rezervacija.cijena!.toStringAsFixed(2)}KM",
                style: styleTekst,
                textAlign: TextAlign.end,
              ),
            ),
          ]),
          const SizedBox(height: 10.0),
          Row(
            children: [
              Expanded(
                  child: CheckboxListTile(
                contentPadding: EdgeInsets.zero,
                title: const Text("Otkazano"),
                value: rezervacija.datumOtkazano != null ? true : false,
                controlAffinity: ListTileControlAffinity.leading,
                onChanged: null,
              )),
              Expanded(
                  child: CheckboxListTile(
                contentPadding: EdgeInsets.zero,
                title: const Text("Prodano"),
                value: rezervacija.datumProdano != null ? true : false,
                controlAffinity: ListTileControlAffinity.leading,
                onChanged: null,
              )),
            ],
          ),
          Text(
            DateFormat('dd/MM/yyyy').format(rezervacija.datum!),
            style: styleDatumAutor,
            textAlign: TextAlign.end,
          ),
        ]),
      ),
    );
  }
}
