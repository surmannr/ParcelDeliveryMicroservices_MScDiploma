import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/shipping_request.dart';
import 'package:parceldelivery_mobile/screens/track/track_detail.dart';

class ShippingRequestTile extends StatelessWidget {
  const ShippingRequestTile({
    required this.entity,
    super.key,
  });

  final ShippingRequest entity;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 4,
        child: ListTile(
          onTap: () {
            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => TrackDetailScreen(
                  id: entity.id,
                ),
              ),
            );
          },
          title: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "${entity.addressFrom.country} ${entity.addressFrom.zipCode} ${entity.addressFrom.city},",
                textAlign: TextAlign.start,
                style: const TextStyle(
                  fontSize: 11,
                ),
              ),
              Text(
                entity.addressFrom.street,
                textAlign: TextAlign.start,
                style: const TextStyle(
                  fontSize: 11,
                ),
              ),
              const Divider(),
              Text(
                "${entity.addressTo.country} ${entity.addressTo.zipCode} ${entity.addressTo.city}, ",
                textAlign: TextAlign.start,
                style: const TextStyle(
                  fontSize: 11,
                ),
              ),
              Text(
                entity.addressTo.street,
                textAlign: TextAlign.start,
                style: const TextStyle(
                  fontSize: 11,
                ),
              ),
            ],
          ),
          subtitle: Column(
            children: [
              const Divider(),
              Text(
                "Csomagok száma: ${entity.packages.length}",
                style: const TextStyle(
                  fontSize: 10,
                ),
              ),
            ],
          ),
          trailing: Text(
            Constants.status.getStatusName(entity.status),
            style: const TextStyle(
              fontSize: 12,
            ),
          ),
        ),
      ),
    );
  }
}
