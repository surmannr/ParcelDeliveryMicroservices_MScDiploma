import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';
import 'package:parceldelivery_mobile/screens/shipping_option/shipping_option_dialog.dart';

class ShippingOptionTile extends StatelessWidget {
  const ShippingOptionTile({
    required this.entity,
    super.key,
  });

  final ShippingOption entity;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 4,
        child: ListTile(
          title: Text(
            "${entity.name} (Ár: ${entity.price})",
            style: const TextStyle(
              fontSize: 15,
            ),
          ),
          onTap: () => showDialog(
            context: context,
            builder: (BuildContext context) {
              return ShippingOptionDialog(
                entity: entity,
              );
            },
          ),
        ),
      ),
    );
  }
}
