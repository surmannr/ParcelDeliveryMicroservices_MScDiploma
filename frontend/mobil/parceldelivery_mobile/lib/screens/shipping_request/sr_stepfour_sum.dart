import 'dart:math';

import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/api/shipping_requests.api.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/add_new_billing.dart';
import 'package:parceldelivery_mobile/models/add_new_shipping_request.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ShipReqStepFourSum extends StatelessWidget {
  const ShipReqStepFourSum({
    required this.billing,
    required this.shippingRequest,
    required this.sharedPreferences,
    required this.currencies,
    required this.shippingOptions,
    required this.paymentOptions,
    super.key,
  });

  final AddNewBilling billing;
  final AddNewShippingRequest shippingRequest;
  final SharedPreferences sharedPreferences;

  final List<PaymentOption> paymentOptions;
  final List<ShippingOption> shippingOptions;
  final List<Currency> currencies;

  @override
  Widget build(BuildContext context) {
    int min = 1;
    int max = 300;
    final rnd = Random();
    int totalDistance = min + rnd.nextInt(max - min);
    int totalAmount = (shippingOptions
                .where(
                    (element) => element.id == shippingRequest.shippingOptionId)
                .singleOrNull
                ?.price ??
            0) +
        shippingRequest.packages.fold(
            0,
            (previousValue, element) =>
                previousValue +
                (element.sizeX + element.sizeY + element.sizeZ) * 100 +
                element.weight * 200);
    var newBilling = billing.copyWith(
        totalAmount: totalAmount, totalDistance: totalDistance);
    return Column(
      mainAxisSize: MainAxisSize.max,
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          "Név: ${sharedPreferences.getString(Constants.sharedPref.nameTag) ?? ""}",
          style: const TextStyle(
            fontSize: 17,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Email: ${sharedPreferences.getString(Constants.sharedPref.emailTag) ?? ""}",
          style: const TextStyle(
            fontSize: 17,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        const Divider(),
        const SizedBox(
          height: 5,
        ),
        const Text(
          "Csomagfeladás adatok:",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Honnan: ${shippingRequest.addressFrom.country} ${shippingRequest.addressFrom.zipCode} ${shippingRequest.addressFrom.city}, ${shippingRequest.addressFrom.street}",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Hová: ${shippingRequest.addressTo.country} ${shippingRequest.addressTo.zipCode} ${shippingRequest.addressTo.city}, ${shippingRequest.addressTo.street}",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Szállítási mód: ${shippingOptions.where((element) => element.id == shippingRequest.shippingOptionId).singleOrNull?.name ?? ""}",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Fizetési mód: ${paymentOptions.where((element) => element.id == shippingRequest.paymentOptionId).singleOrNull?.name ?? ""}",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        const Text(
          "Csomagok:",
          style: TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        ...shippingRequest.packages
            .map((e) => Row(
                  children: [
                    const SizedBox(
                      width: 10,
                    ),
                    Text(
                      "- ${e.sizeX} x ${e.sizeY} x ${e.sizeZ} m, ${e.weight} kg ${e.isFragile ? "Törékeny" : ""}",
                      style: const TextStyle(
                        fontSize: 13,
                      ),
                      textAlign: TextAlign.start,
                    ),
                  ],
                ))
            .toList(),
        const SizedBox(
          height: 5,
        ),
        const Divider(),
        const SizedBox(
          height: 5,
        ),
        const Text(
          "Számlázási adatok:",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Név: ${newBilling.name}",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Távolság: ${newBilling.totalDistance} km",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 5,
        ),
        Text(
          "Végösszeg: ${newBilling.totalAmount} Ft (${currencies.where((element) => element.id == newBilling.currencyId).singleOrNull?.name ?? ""} a kiválasztott valuta)",
          style: const TextStyle(
            fontSize: 13,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 15,
        ),
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {
              ShippingRequestsApi.add(shippingRequest, newBilling);
              Navigator.of(context).pushNamed(WelcomeCustomer.routeName);
            },
            clipBehavior: Clip.hardEdge,
            child: const Text('Új csomagfeladás'),
          ),
        ),
      ],
    );
  }
}
