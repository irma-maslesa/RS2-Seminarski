import 'dart:ffi';
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:pelikula_mobile/model/projekcija.dart';
import 'package:pelikula_mobile/pages/prikaz.dart';
import 'package:pelikula_mobile/services/api_service.dart';
import 'package:intl/intl.dart';

class Projekcije extends StatefulWidget {
  const Projekcije({Key? key}) : super(key: key);

  @override
  _ProjekcijeState createState() => _ProjekcijeState();
}

class _ProjekcijeState extends State<Projekcije> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Projekcije"),
      ),
      body: body(),
    );
  }

  Widget body() {
    return FutureBuilder<List<ProjekcijaDetailedResponse>>(
      future: getProjekcije(),
      builder: (BuildContext context,
          AsyncSnapshot<List<ProjekcijaDetailedResponse>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(
            child: Text("Učitavanje..."),
          );
        } else if (snapshot.hasError) {
          print("Greška ${snapshot.error}");
          return const Center(
            child: Text("Greška pri učitavanju."),
          );
        } else {
          return ListView(
            children: snapshot.data!.map((e) => projekcijaWidget(e)).toList(),
          );
        }
      },
    );
  }

  Future<List<ProjekcijaDetailedResponse>> getProjekcije() async {
    var response = await ApiService.get("Projekcija/aktivne/details", null);
    print(response);
    if (response != null) {
      return response
          .map((e) => ProjekcijaDetailedResponse.fromJson(e))
          .toList();
    }
    return [];
  }

  Widget projekcijaWidget(ProjekcijaDetailedResponse projekcija) {
    TextStyle styleNaslov = const TextStyle(
        fontFamily: 'Rajdhani',
        fontSize: 30.0,
        fontWeight: FontWeight.w700,
        color: Colors.black);
    TextStyle styleTekst = const TextStyle(
        fontFamily: 'Rajdhani',
        fontSize: 20.0,
        fontWeight: FontWeight.w300,
        color: Colors.black);

    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.of(context).push(
              MaterialPageRoute(builder: (context) => Prikaz(projekcija)));
        },
        child: Row(
          children: [
            Padding(
              padding: const EdgeInsets.all(5),
              child: projekcija.film!.plakatThumb != null &&
                      projekcija.film!.plakatThumb!.isNotEmpty
                  ? Image(
                      image: MemoryImage(
                          Uint8List.fromList(projekcija.film!.plakatThumb!)),
                      width: 135,
                    )
                  : const Image(
                      image: AssetImage('assets/no-image.png'),
                      width: 135,
                    ),
            ),
            const SizedBox(
              width: 30,
            ),
            Column(
              children: [
                Text(projekcija.film!.naslov!, style: styleNaslov),
                Text("Cijena: ${projekcija.cijena.toString()} KM",
                    style: styleTekst),
                Text(
                    "Vrijedi do: ${DateFormat('dd/MM/yyyy').format(projekcija.vrijediDo!)}",
                    style: styleTekst)
              ],
            )
          ],
        ),
      ),
    );
  }
}
