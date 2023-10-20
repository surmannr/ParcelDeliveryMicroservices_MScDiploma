import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/payment_option/payment_option_bloc.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';

class PaymentOptionDialog extends StatefulWidget {
  const PaymentOptionDialog({required this.entity, super.key});

  final PaymentOption entity;

  @override
  State<PaymentOptionDialog> createState() => _PaymentOptionDialogState();
}

class _PaymentOptionDialogState extends State<PaymentOptionDialog> {
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
      final PaymentOption paymentOption = PaymentOption(id: 0, name: name);
      BlocProvider.of<PaymentOptionBloc>(context).add(
        PaymentOptionEvent.add(paymentOption),
      );
      Navigator.pop(context);
    }
  }

  void _tryUpd() {
    final isValid = _formKey.currentState?.validate();
    FocusScope.of(context).unfocus();

    if (isValid != null && isValid) {
      _formKey.currentState?.save();
      final PaymentOption paymentOption =
          PaymentOption(id: widget.entity.id, name: name);
      BlocProvider.of<PaymentOptionBloc>(context).add(
        PaymentOptionEvent.update(paymentOption),
      );
      Navigator.pop(context);
    }
  }

  void _tryDel() {
    BlocProvider.of<PaymentOptionBloc>(context).add(
      PaymentOptionEvent.delete(widget.entity),
    );
    Navigator.pop(context);
  }

  @override
  Widget build(BuildContext context) {
    return SimpleDialog(
      title: widget.entity.id == 0
          ? const Text(
              "Új fizetési opció hozzáadása",
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
                      const InputDecoration(labelText: "Fizetési opció neve"),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return "A fizetési opció nevét kitölteni kötelező!";
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
