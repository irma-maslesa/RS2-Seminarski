import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/projekcija.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  TextStyle style = const TextStyle(
      fontFamily: 'Rajdhani', fontSize: 30.0, fontWeight: FontWeight.w300);

  ListTile createTile(String text, String route) {
    return ListTile(
      title: Center(child: Text(text, style: style)),
      onTap: () async {
        Navigator.of(context).popAndPushNamed(route);
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    const imgLogo = Image(
      image: AssetImage('assets/logo3.png'),
      width: 85,
    );
    const txtPelikula = Text(
      "Pelikula",
      style: TextStyle(fontFamily: 'Molle', fontSize: 40.0),
    );

    DrawerHeader drawerHeader = DrawerHeader(
      decoration: const BoxDecoration(color: Colors.blue),
      child: Center(
        child: Padding(
          padding: const EdgeInsets.fromLTRB(5, 0, 5, 0),
          child: Row(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: const [
                imgLogo,
                SizedBox(width: 15.0),
                txtPelikula,
              ]),
        ),
      ),
    );
    const sizedBox = SizedBox(height: 15);

    return Scaffold(
      appBar: AppBar(),
      drawer: Drawer(
        child: ListView(
          children: [
            drawerHeader,
            sizedBox,
            createTile("Preporučeno", ""),
            sizedBox,
            createTile("Projekcije", "/projekcije"),
            sizedBox,
            createTile("Rezervacije", ""),
            sizedBox,
            createTile("Kupovine", ""),
            sizedBox,
            createTile("Obavijesti", ""),
            sizedBox,
            createTile("Ankete", ""),
            sizedBox,
            createTile("Profil", ""),
            sizedBox,
            createTile("Odjava", ""),
          ],
        ),
      ),
    );
  }
}
