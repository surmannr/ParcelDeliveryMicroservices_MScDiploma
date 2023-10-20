import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/screens/payment_option/payment_option_dialog.dart';

class PaymentOptionTile extends StatelessWidget {
  const PaymentOptionTile({
    required this.entity,
    super.key,
  });

  final PaymentOption entity;

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
              return PaymentOptionDialog(
                entity: entity,
              );
            },
          ),
        ),
      ),
    );
  }
}
