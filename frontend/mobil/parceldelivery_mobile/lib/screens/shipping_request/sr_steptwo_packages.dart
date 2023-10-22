import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:parceldelivery_mobile/components/common/package_tile.dart';
import 'package:parceldelivery_mobile/models/package.dart';

class ShipReqStepTwoPackages extends StatefulWidget {
  const ShipReqStepTwoPackages({
    required this.packages,
    required this.userId,
    required this.addPackage,
    required this.deletePackage,
    super.key,
  });

  final List<Package> packages;
  final String userId;
  final void Function(Package package) addPackage;
  final void Function(Package package) deletePackage;

  @override
  State<ShipReqStepTwoPackages> createState() => _ShipReqStepTwoPackagesState();
}

class _ShipReqStepTwoPackagesState extends State<ShipReqStepTwoPackages> {
  final MaterialStateProperty<Icon?> thumbIcon =
      MaterialStateProperty.resolveWith<Icon?>(
    (Set<MaterialState> states) {
      if (states.contains(MaterialState.selected)) {
        return const Icon(Icons.check);
      }
      return const Icon(Icons.close);
    },
  );

  Package newPackage = Package(
    id: Guid.newGuid.toString(),
    userId: "",
    sizeX: 0,
    sizeY: 0,
    sizeZ: 0,
    weight: 0,
    isFragile: false,
    shippingRequestId: "",
  );

  bool checkPackageValid() {
    if (newPackage.userId.isEmpty ||
        newPackage.sizeX <= 0 ||
        newPackage.sizeY <= 0 ||
        newPackage.sizeZ <= 0 ||
        newPackage.weight <= 0) return false;
    return true;
  }

  bool saveable = false;

  @override
  Widget build(BuildContext context) {
    newPackage = newPackage.copyWith(userId: widget.userId);
    return Column(
      mainAxisSize: MainAxisSize.max,
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        const Text(
          "Új csomag felvétele",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 10,
        ),
        Row(
          children: [
            Expanded(
              flex: 1,
              child: TextFormField(
                decoration: const InputDecoration(
                  labelText: "Méret (X)",
                  suffixText: "m",
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "A méretet kitölteni kötelező!";
                  }
                  return null;
                },
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                keyboardType: TextInputType.number,
                onChanged: (value) {
                  setState(() {
                    newPackage = newPackage.copyWith(sizeX: int.parse(value));
                  });
                },
                initialValue: newPackage.sizeX.toString(),
              ),
            ),
            const SizedBox(
              width: 10,
            ),
            Expanded(
              flex: 1,
              child: TextFormField(
                decoration: const InputDecoration(
                  labelText: "Méret (Y)",
                  suffixText: "m",
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "A méretet kitölteni kötelező!";
                  }
                  return null;
                },
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                keyboardType: TextInputType.number,
                onChanged: (value) {
                  setState(() {
                    newPackage = newPackage.copyWith(sizeY: int.parse(value));
                  });
                },
                initialValue: newPackage.sizeY.toString(),
              ),
            ),
            const SizedBox(
              width: 10,
            ),
            Expanded(
              flex: 1,
              child: TextFormField(
                decoration: const InputDecoration(
                  labelText: "Méret (Z)",
                  suffixText: "m",
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "A méretet kitölteni kötelező!";
                  }
                  return null;
                },
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                keyboardType: TextInputType.number,
                onChanged: (value) {
                  setState(() {
                    newPackage = newPackage.copyWith(sizeZ: int.parse(value));
                  });
                },
                initialValue: newPackage.sizeZ.toString(),
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
              flex: 1,
              child: TextFormField(
                decoration: const InputDecoration(
                  labelText: "Súly",
                  suffixText: "kg",
                ),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "A súlyt kitölteni kötelező!";
                  }
                  return null;
                },
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.digitsOnly
                ],
                keyboardType: TextInputType.number,
                onChanged: (value) {
                  setState(() {
                    newPackage = newPackage.copyWith(weight: int.parse(value));
                  });
                },
                initialValue: newPackage.weight.toString(),
              ),
            ),
            const SizedBox(
              width: 10,
            ),
            Expanded(
              flex: 1,
              child: Column(
                children: [
                  const Text(
                    "Törékeny?",
                    style: TextStyle(
                      fontSize: 15,
                    ),
                    textAlign: TextAlign.start,
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Switch(
                    thumbIcon: thumbIcon,
                    value: newPackage.isFragile,
                    onChanged: (bool value) {
                      setState(() {
                        newPackage = newPackage.copyWith(isFragile: value);
                      });
                    },
                  ),
                ],
              ),
            ),
          ],
        ),
        const SizedBox(
          height: 10,
        ),
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: checkPackageValid()
                ? () {
                    newPackage = newPackage.copyWith(
                      id: Guid.newGuid.toString(),
                    );
                    widget.addPackage(newPackage);
                  }
                : null,
            child: const Text('Új csomag hozzáadása'),
          ),
        ),
        const SizedBox(
          height: 10,
        ),
        const Divider(),
        const SizedBox(
          height: 10,
        ),
        ListView.builder(
            shrinkWrap: true,
            physics: const NeverScrollableScrollPhysics(),
            itemCount: widget.packages.length,
            itemBuilder: (BuildContext context, int index) {
              return PackageTile(
                entity: widget.packages[index],
                deletePackage: widget.deletePackage,
              );
            }),
      ],
    );
  }
}
