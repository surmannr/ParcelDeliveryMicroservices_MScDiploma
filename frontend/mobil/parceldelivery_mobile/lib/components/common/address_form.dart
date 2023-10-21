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
  final void Function(Address address) addressChanged;

  @override
  State<AddressForm> createState() => _AddressFormState();
}

class _AddressFormState extends State<AddressForm> {
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
                  widget.addressChanged(
                    Address(
                      street: widget.address.street,
                      city: widget.address.city,
                      zipCode: widget.address.zipCode,
                      country: value,
                    ),
                  );
                },
                initialValue: widget.address.country,
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
                  widget.addressChanged(
                    Address(
                      street: widget.address.street,
                      city: value,
                      zipCode: widget.address.zipCode,
                      country: widget.address.country,
                    ),
                  );
                },
                initialValue: widget.address.country,
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
                  widget.addressChanged(
                    Address(
                      street: widget.address.street,
                      city: widget.address.city,
                      zipCode: int.parse(value),
                      country: widget.address.country,
                    ),
                  );
                },
                initialValue: widget.address.zipCode.toString(),
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
                  widget.addressChanged(
                    Address(
                      street: value,
                      city: widget.address.city,
                      zipCode: widget.address.zipCode,
                      country: widget.address.country,
                    ),
                  );
                },
                initialValue: widget.address.street,
              ),
            ),
          ],
        ),
      ],
    );
  }
}
