import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/projekcija.dart';

class PrikazProjekcije extends StatelessWidget {
  final ProjekcijaDetailedResponse projekcija;

  const PrikazProjekcije(this.projekcija, {Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          projekcija.film!.naslov!,
        ),
      ),
    );
  }
}
