import 'package:flutter/material.dart';
import 'package:pelikula_mobile/pages/Rezervacija.dart';
import 'package:pelikula_mobile/pages/home.dart';
import 'package:pelikula_mobile/pages/loading.dart';
import 'package:pelikula_mobile/pages/prijava.dart';
import 'package:pelikula_mobile/pages/prikaz.dart';
import 'package:pelikula_mobile/pages/projekcije.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: const Prijava(),
      routes: {
        '/loading': (context) => Loading(),
        '/home': (context) => const Home(),
        '/projekcije': (context) => const Projekcije(),
        //'/prikaz': (context) => Prikaz(),
        '/rezervacija': (context) => Rezervacija(),
        /* '/kupovina': (context) => Kupovina(),
        '/dojam': (context) => Dojam(),
        '/preporuceno': (context) => Preporuceno(),
        '/rezervacije': (context) => Rezervacije(),
        '/kupovine': (context) => Kupovine(),
        '/obavijesti': (context) => Obavijesti(),
        '/ankete': (context) => Ankete(), */
      },
    );
  }
}
