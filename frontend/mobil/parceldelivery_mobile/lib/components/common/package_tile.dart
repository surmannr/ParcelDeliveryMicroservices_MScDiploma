import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/package.dart';

class PackageTile extends StatelessWidget {
  const PackageTile({
    required this.entity,
    required this.deletePackage,
    super.key,
  });

  final Package entity;
  final void Function(Package package) deletePackage;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 4,
        child: ListTile(
          onTap: () {
            deletePackage(entity);
          },
          title: Text(
            "Méret: ${entity.sizeX}m x ${entity.sizeY}m x ${entity.sizeZ}m",
            style: const TextStyle(
              fontSize: 15,
            ),
          ),
          subtitle: Text(
            "Súly: ${entity.weight}kg",
            style: const TextStyle(
              fontSize: 12,
            ),
          ),
          trailing: Text(
            entity.isFragile ? "Törékeny" : "",
            style: const TextStyle(
              fontSize: 12,
            ),
          ),
        ),
      ),
    );
  }
}
