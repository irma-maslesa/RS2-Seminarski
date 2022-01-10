import 'package:flutter/material.dart';
import 'package:pelikula_mobile/model/lov.dart';

class Sjediste extends StatefulWidget {
  final LoV sjediste;
  final bool disabled;
  Function(int, bool) odaberiSjediste;

  bool selected;
  Sjediste(this.sjediste, this.selected, this.disabled, this.odaberiSjediste,
      {Key? key})
      : super(key: key);

  @override
  _SjedisteState createState() => _SjedisteState();
}

class _SjedisteState extends State<Sjediste> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Material(
        elevation: 5.0,
        borderRadius: BorderRadius.circular(10.0),
        color: widget.disabled
            ? const Color(0xff97AFBA)
            : widget.selected
                ? const Color(0xffe36b9d)
                : const Color(0xff01A0C7),
        child: MaterialButton(
          onPressed: widget.disabled
              ? null
              : () async {
                  setState(() {
                    if (widget.odaberiSjediste(
                        widget.sjediste.id!, widget.selected)) {
                      widget.selected = !widget.selected;
                    }
                  });
                },
          child: Text(widget.sjediste.naziv!,
              textAlign: TextAlign.center,
              style: style.copyWith(
                  color: Colors.white, fontWeight: FontWeight.bold)),
        ),
      ),
    );
  }
}
