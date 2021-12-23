import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/projekcija.dart';

class Prikaz extends StatelessWidget {
  final ProjekcijaDetailedResponse projekcija;

  const Prikaz(this.projekcija, {Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(projekcija.film!.naslov!),
      ),
    );
  }
}
