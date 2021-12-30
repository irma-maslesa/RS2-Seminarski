import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:pelikula_mobile/model/anketa_response.dart';
import 'package:pelikula_mobile/model/helper/sorting_params.dart';
import 'package:pelikula_mobile/model/anketa_response.dart';
import 'package:pelikula_mobile/model/response/error_response.dart';
import 'package:pelikula_mobile/model/response/paged_payload_response.dart';
import 'package:pelikula_mobile/pages/prikaz_ankete.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Ankete extends StatefulWidget {
  const Ankete({Key? key}) : super(key: key);

  @override
  _AnketeState createState() => _AnketeState();
}

class _AnketeState extends State<Ankete> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Ankete")),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<dynamic>(
      future: getAnkete(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Učitavanje..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else if (snapshot.data is PagedPayloadResponse) {
          return ListView(
            children: (snapshot.data.payload
                    .map((e) => AnketaResponse.fromJson(e))
                    .toList()
                    .cast<AnketaResponse>() as List)
                .map((e) => anketaWidget(e))
                .toList()
                .cast<Widget>(),
          );
        } else {
          return Center(
            child: Text((snapshot.data as ErrorResponse).message as String),
          );
        }
      },
    );
  }

  Future<dynamic> getAnkete() async {
    List<SortingParams> sortingParams = [
      SortingParams(sortOrder: "DESC", columnName: "datum")
    ];
    String sorting = json.encode(sortingParams);
    var response = await ApiService.get("Anketa/aktivne", {"sorting": sorting});
    return response;
  }

  Widget anketaWidget(AnketaResponse anketa) {
    TextStyle styleNaslov = const TextStyle(
        fontSize: 30.0, fontWeight: FontWeight.w500, color: Colors.black);
    TextStyle styleDatum = const TextStyle(
        fontSize: 10.0, fontWeight: FontWeight.w300, color: Colors.black);

    return Card(
      child: TextButton(
          onPressed: () {
            Navigator.of(context).push(
                MaterialPageRoute(builder: (context) => PrikazAnkete(anketa)));
          },
          child: Column(
            children: [
              Text(
                anketa.naslov!,
                style: styleNaslov,
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 10.0),
              Text(DateFormat('dd/MM/yyyy').format(anketa.datum!),
                  style: styleDatum)
            ],
          )),
    );
  }
}
