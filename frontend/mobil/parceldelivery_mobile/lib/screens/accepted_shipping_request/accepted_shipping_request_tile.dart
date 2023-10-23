import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/accepted_ship_request.dart';
import 'package:parceldelivery_mobile/screens/accepted_shipping_request/accepted_shipping_request_detail.dart';

class AcceptedShippingRequestTile extends StatelessWidget {
  const AcceptedShippingRequestTile({
    required this.entity,
    super.key,
  });

  final AcceptedShipRequest entity;

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
                builder: (context) => AcceptedShippingRequestDetail(
                  entity: entity,
                ),
              ),
            );
          },
          title: Text(
            "Csomagok száma: ${entity.packages.length}",
            style: const TextStyle(
              fontSize: 15,
            ),
          ),
          subtitle: Text(
            "Jármű: ${entity.vehicle.registrationNumber} (${entity.vehicle.type})",
            style: const TextStyle(
              fontSize: 10,
            ),
          ),
          trailing: entity.isAllPackageTaken
              ? const Icon(
                  Icons.done,
                )
              : const Icon(
                  Icons.hourglass_bottom,
                ),
        ),
      ),
    );
  }
}
