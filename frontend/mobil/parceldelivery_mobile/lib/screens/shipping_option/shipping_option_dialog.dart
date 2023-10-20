import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_option/shipping_option_bloc.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

class ShippingOptionDialog extends StatefulWidget {
  const ShippingOptionDialog({required this.entity, super.key});

  final ShippingOption entity;

  @override
  State<ShippingOptionDialog> createState() => _ShippingOptionDialogState();
}

class _ShippingOptionDialogState extends State<ShippingOptionDialog> {
  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    super.initState();
    name = widget.entity.name;
    price = widget.entity.price;
  }

  String name = "";
  int price = 0;

  void _tryAdd() {
    final isValid = _formKey.currentState?.validate();
    FocusScope.of(context).unfocus();

    if (isValid != null && isValid) {
      _formKey.currentState?.save();
      final ShippingOption shippingOption =
          ShippingOption(id: 0, name: name, price: price);
      BlocProvider.of<ShippingOptionBloc>(context).add(
        ShippingOptionEvent.add(shippingOption),
      );
      Navigator.pop(context);
    }
  }

  void _tryUpd() {
    final isValid = _formKey.currentState?.validate();
    FocusScope.of(context).unfocus();

    if (isValid != null && isValid) {
      _formKey.currentState?.save();
      final ShippingOption shippingOption =
          ShippingOption(id: widget.entity.id, name: name, price: price);
      BlocProvider.of<ShippingOptionBloc>(context).add(
        ShippingOptionEvent.update(shippingOption),
      );
      Navigator.pop(context);
    }
  }

  void _tryDel() {
    BlocProvider.of<ShippingOptionBloc>(context).add(
      ShippingOptionEvent.delete(widget.entity),
    );
    Navigator.pop(context);
  }

  @override
  Widget build(BuildContext context) {
    return SimpleDialog(
      title: widget.entity.id == 0
          ? const Text(
              "Új szállítási opció hozzáadása",
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
                  decoration:
                      const InputDecoration(labelText: "Szállítási opció neve"),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return "A szállítási opció nevét kitölteni kötelező!";
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
                TextFormField(
                  decoration:
                      const InputDecoration(labelText: "Szállítási opció ára"),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return "A szállítási opció árát kitölteni kötelező!";
                    }
                    return null;
                  },
                  inputFormatters: <TextInputFormatter>[
                    FilteringTextInputFormatter.digitsOnly
                  ],
                  keyboardType: TextInputType.number,
                  onSaved: (value) {
                    price = int.parse(value!);
                  },
                  initialValue: price.toString(),
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
