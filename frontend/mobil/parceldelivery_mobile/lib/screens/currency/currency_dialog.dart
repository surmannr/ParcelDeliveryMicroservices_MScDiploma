import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/currency/currency_bloc.dart';
import 'package:parceldelivery_mobile/models/currency.dart';

class CurrencyDialog extends StatefulWidget {
  CurrencyDialog({required this.entity, super.key});

  final Currency entity;

  @override
  State<CurrencyDialog> createState() => _CurrencyDialogState();
}

class _CurrencyDialogState extends State<CurrencyDialog> {
  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    super.initState();
    name = widget.entity.name;
  }

  String name = "";

  void _tryAdd() {
    final isValid = _formKey.currentState?.validate();
    FocusScope.of(context).unfocus();

    if (isValid != null && isValid) {
      _formKey.currentState?.save();
      final Currency currency = Currency(id: 0, name: name);
      BlocProvider.of<CurrencyBloc>(context).add(
        CurrencyEvent.add(currency),
      );
      Navigator.pop(context);
    }
  }

  void _tryUpd() {
    final isValid = _formKey.currentState?.validate();
    FocusScope.of(context).unfocus();

    if (isValid != null && isValid) {
      _formKey.currentState?.save();
      final Currency currency = Currency(id: widget.entity.id, name: name);
      BlocProvider.of<CurrencyBloc>(context).add(
        CurrencyEvent.update(currency),
      );
      Navigator.pop(context);
    }
  }

  void _tryDel() {
    BlocProvider.of<CurrencyBloc>(context).add(
      CurrencyEvent.delete(widget.entity),
    );
    Navigator.pop(context);
  }

  @override
  Widget build(BuildContext context) {
    return SimpleDialog(
      title: widget.entity.id == 0
          ? const Text(
              "Új valuta hozzáadása",
              style: TextStyle(
                fontSize: 25,
              ),
              textAlign: TextAlign.start,
            )
          : Text(
              "${widget.entity.name} módosítása",
              style: const TextStyle(
                fontSize: 25,
              ),
              textAlign: TextAlign.start,
            ),
      children: [
        Form(
          key: _formKey,
          child: Padding(
            padding: const EdgeInsets.all(15.0),
            child: Column(
              children: [
                TextFormField(
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return "A valuta nevét kitölteni kötelező!";
                    }
                    return null;
                  },
                  keyboardType: TextInputType.text,
                  onSaved: (value) {
                    name = value!;
                  },
                  initialValue: name,
                ),
                const SizedBox(
                  height: 20,
                ),
                widget.entity.id != 0
                    ? Column(
                        children: [
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                              onPressed: _tryUpd,
                              clipBehavior: Clip.hardEdge,
                              child: const Text('Módosítás'),
                            ),
                          ),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                              onPressed: _tryDel,
                              clipBehavior: Clip.hardEdge,
                              child: const Text('Törlés'),
                            ),
                          ),
                        ],
                      )
                    : SizedBox(
                        width: double.infinity,
                        child: ElevatedButton(
                          onPressed: _tryAdd,
                          clipBehavior: Clip.hardEdge,
                          child: const Text('Hozzáadás'),
                        ),
                      ),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
