import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/screens/currency/currency_dialog.dart';

class CurrencyTile extends StatelessWidget {
  const CurrencyTile({
    required this.entity,
    super.key,
  });

  final Currency entity;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 4,
        child: ListTile(
          title: Text(
            entity.name,
            style: const TextStyle(
              fontSize: 15,
            ),
          ),
          onTap: () => showDialog(
            context: context,
            builder: (BuildContext context) {
              return CurrencyDialog(
                entity: entity,
              );
            },
          ),
        ),
      ),
    );
  }
}
