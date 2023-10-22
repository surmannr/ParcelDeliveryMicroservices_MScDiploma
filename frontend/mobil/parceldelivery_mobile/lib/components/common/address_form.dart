import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:parceldelivery_mobile/models/address.dart';

class AddressForm extends StatefulWidget {
  const AddressForm({
    required this.address,
    required this.addressChanged,
    super.key,
  });

  final Address address;
  final void Function({
    required String country,
    required String city,
    required String street,
    required int zipCode,
  }) addressChanged;

  @override
  State<AddressForm> createState() => _AddressFormState();
}

class _AddressFormState extends State<AddressForm> {
  String country = "";
  String city = "";
  String street = "";
  int zipCode = 0;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    country = widget.address.country;
    street = widget.address.street;
    city = widget.address.city;
    zipCode = widget.address.zipCode;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          children: [
            Expanded(
              flex: 2,
              child: TextFormField(
                decoration: const InputDecoration(labelText: "Ország"),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Az ország nevét kitölteni kötelező!";
                  }
                  return null;
                },
                keyboardType: TextInputType.text,
                onChanged: (value) {
                  setState(() {
                    country = value;
                    widget.addressChanged(
                      street: street,
                      city: city,
                      zipCode: zipCode,
                      country: value,
                    );
                  });
                },
                initialValue: country,
              ),
            ),
            const SizedBox(
              width: 10,
            ),
            Expanded(
              flex: 3,
              child: TextFormField(
                decoration: const InputDecoration(labelText: "Város"),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "A város nevét kitölteni kötelező!";
                  }
                  return null;
                },
                keyboardType: TextInputType.text,
                onChanged: (value) {
                  setState(() {
                    city = value;
                    widget.addressChanged(
                      street: street,
                      city: value,
                      zipCode: zipCode,
                      country: country,
                    );
                  });
                },
                initialValue: city,
              ),
            ),
          ],
        ),
        const SizedBox(
          height: 10,
        ),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: TextFormField(
                decoration: const InputDecoration(labelText: "Irányítószám"),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Az irányítószám kitölteni kötelező!";
                  }
                  return null;
                },
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                keyboardType: TextInputType.number,
                onChanged: (value) {
                  setState(() {
                    zipCode = int.parse(value);
                    widget.addressChanged(
                      street: street,
                      city: city,
                      zipCode: int.parse(value),
                      country: country,
                    );
                  });
                },
                initialValue: zipCode.toString(),
              ),
            ),
            const SizedBox(
              width: 10,
            ),
            Expanded(
              flex: 4,
              child: TextFormField(
                decoration: const InputDecoration(labelText: "Utca"),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Az utca nevét kitölteni kötelező!";
                  }
                  return null;
                },
                keyboardType: TextInputType.text,
                onChanged: (value) {
                  setState(() {
                    street = value;
                    widget.addressChanged(
                      street: value,
                      city: city,
                      zipCode: zipCode,
                      country: country,
                    );
                  });
                },
                initialValue: street,
              ),
            ),
          ],
        ),
      ],
    );
  }
}
