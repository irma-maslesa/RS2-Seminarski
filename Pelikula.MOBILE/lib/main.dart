import 'package:flutter/material.dart';
import 'package:pelikula_mobile/pages/korisnik/prijava.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        appBarTheme: const AppBarTheme(
            titleTextStyle: TextStyle(
          fontSize: 20.0,
          fontWeight: FontWeight.w700,
        )),
        fontFamily: 'Rajdhani',
      ),
      home: const Prijava(),
      routes: const {
        /* '/kupovina': (context) => Kupovina(),
        '/dojam': (context) => Dojam(),
        '/preporuceno': (context) => Preporuceno(),
        '/rezervacije': (context) => Rezervacije(),
        '/kupovine': (context) => Kupovine(),*/
      },
    );
  }
}
