import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/common/address_form.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/address.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ShipReqStepOneAddress extends StatelessWidget {
  const ShipReqStepOneAddress({
    required this.addressFrom,
    required this.addressTo,
    required this.addressFromChanged,
    required this.addressToChanged,
    super.key,
  });

  final Address addressFrom;
  final void Function(Address addressFrom) addressFromChanged;
  final Address addressTo;
  final void Function(Address addressToo) addressToChanged;

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: SharedPreferences.getInstance(),
      builder: (ctx, snapshot) {
        return Column(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.start,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "Név: ${snapshot.data?.getString(Constants.sharedPref.nameTag) ?? ""}",
              style: const TextStyle(
                fontSize: 20,
              ),
              textAlign: TextAlign.start,
            ),
            const SizedBox(
              height: 5,
            ),
            Text(
              "Email: ${snapshot.data?.getString(Constants.sharedPref.emailTag) ?? ""}",
              style: const TextStyle(
                fontSize: 20,
              ),
              textAlign: TextAlign.start,
            ),
            const SizedBox(
              height: 5,
            ),
            const Divider(),
            const SizedBox(
              height: 10,
            ),
            const Text(
              "Honnan",
              style: TextStyle(
                fontSize: 20,
              ),
              textAlign: TextAlign.start,
            ),
            const SizedBox(
              height: 5,
            ),
            AddressForm(
              address: addressFrom,
              addressChanged: addressFromChanged,
            ),
            const SizedBox(
              height: 5,
            ),
            const Text(
              "Hová",
              style: TextStyle(
                fontSize: 20,
              ),
              textAlign: TextAlign.start,
            ),
            const SizedBox(
              height: 5,
            ),
            AddressForm(
              address: addressTo,
              addressChanged: addressToChanged,
            ),
          ],
        );
      },
    );
  }
}
