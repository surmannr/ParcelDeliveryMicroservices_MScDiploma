import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:parceldelivery_mobile/models/vehicle_usage.dart';

class VehicleUsageTile extends StatelessWidget {
  const VehicleUsageTile({
    required this.entity,
    super.key,
  });

  final VehicleUsage entity;

  @override
  Widget build(BuildContext context) {
    final dateFormat = DateFormat('yyyy-MM-dd');
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 4,
        child: ListTile(
          title: Text(
            entity.vehicle.registrationNumber,
            style: const TextStyle(
              fontSize: 15,
            ),
          ),
          subtitle: Text(
            entity.vehicle.type,
            style: const TextStyle(
              fontSize: 10,
            ),
          ),
          trailing: Text(
            "${dateFormat.format(entity.dateFrom)} - ${dateFormat.format(entity.dateTo)}",
            style: const TextStyle(
              fontSize: 12,
            ),
          ),
        ),
      ),
    );
  }
}
