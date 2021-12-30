import 'package:flutter/material.dart';
import 'package:pelikula_mobile/pages/obavijest.dart';
import 'package:pelikula_mobile/pages/projekcije.dart';
import 'package:pelikula_mobile/services/api_service.dart';

class MyDrawer extends StatelessWidget {
  const MyDrawer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    TextStyle style =
        const TextStyle(fontSize: 30.0, fontWeight: FontWeight.w300);

    const imgLogo = Image(
      image: AssetImage('assets/logo3.png'),
      width: 85,
    );
    const txtPelikula = Text(
      "Pelikula",
      style: TextStyle(fontFamily: 'Molle', fontSize: 40.0),
    );

    Future<void> _showDialog(String text) async {
      return showDialog<void>(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            content: Text(text),
            actions: <Widget>[
              TextButton(
                child: const Text('Ne'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
              TextButton(
                child: const Text('Da'),
                onPressed: () {
                  ApiService.korisnickoIme = null;
                  ApiService.lozinka = null;
                  Navigator.of(context).pushReplacementNamed("/prijava");
                },
              ),
            ],
          );
        },
      );
    }

    ListTile createTile(String text, dynamic page) {
      return ListTile(
        title: Center(child: Text(text, style: style)),
        onTap: () async {
          Navigator.of(context).pushAndRemoveUntil(
            MaterialPageRoute(
              builder: (BuildContext context) => page,
            ),
            (route) => false,
          );
        },
      );
    }

    ListTile tileOdjava = ListTile(
      title: Center(child: Text("Odjava", style: style)),
      onTap: () async {
        _showDialog("Jeste li sigurni da se želite odjaviti?");
      },
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

    return Drawer(
      child: ListView(
        children: [
          drawerHeader,
          sizedBox,
          createTile("Preporučeno", const Scaffold()),
          sizedBox,
          createTile("Projekcije", const Projekcije()),
          sizedBox,
          createTile("Rezervacije", const Scaffold()),
          sizedBox,
          createTile("Kupovine", const Scaffold()),
          sizedBox,
          createTile("Obavijesti", const Obavijesti()),
          sizedBox,
          createTile("Ankete", const Scaffold()),
          sizedBox,
          createTile("Profil", const Scaffold()),
          sizedBox,
          tileOdjava
        ],
      ),
    );
  }
}
