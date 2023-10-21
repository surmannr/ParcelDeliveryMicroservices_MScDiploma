import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/api/payment_options.api.dart';
import 'package:parceldelivery_mobile/api/shipping_options.api.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

class ShipReqStepThreeOther extends StatefulWidget {
  const ShipReqStepThreeOther({
    required this.paymentOption,
    required this.paymentOptionChanged,
    required this.shippingOption,
    required this.shippingOptionChanged,
    super.key,
  });

  final int paymentOption;
  final void Function(int paymentOption) paymentOptionChanged;
  final int shippingOption;
  final void Function(int shippingOption) shippingOptionChanged;

  @override
  State<ShipReqStepThreeOther> createState() => _ShipReqStepThreeOtherState();
}

class _ShipReqStepThreeOtherState extends State<ShipReqStepThreeOther> {
  @override
  void initState() {
    super.initState();
  }

  List<PaymentOption> paymentOptions = [];
  List<ShippingOption> shippingOptions = [];

  PaymentOption? selectedPaymentOption;
  ShippingOption? selectedshippingOption;

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.max,
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        const Text(
          "Fizetési opció megadása:",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 10,
        ),
        FutureBuilder(
          future: PaymentOptionsApi.get(),
          builder: (ctx, snapshot) {
            if (snapshot.connectionState == ConnectionState.done) {
              // If we got an error
              if (snapshot.hasError) {
                return const Center(
                  child: Text(
                    'Hiba történt',
                    style: TextStyle(fontSize: 18),
                  ),
                );
              } else if (snapshot.hasData) {
                paymentOptions = snapshot.data!.data;
                selectedPaymentOption = paymentOptions.singleOrNull;
                return DropdownMenu<PaymentOption>(
                  width: 300,
                  initialSelection: selectedPaymentOption,
                  onSelected: (PaymentOption? value) {
                    widget.paymentOptionChanged(value!.id);
                  },
                  dropdownMenuEntries: paymentOptions
                      .map<DropdownMenuEntry<PaymentOption>>(
                          (PaymentOption value) {
                    return DropdownMenuEntry<PaymentOption>(
                      value: value,
                      label: value.name,
                    );
                  }).toList(),
                );
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            } else {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
          },
        ),
        const SizedBox(
          height: 10,
        ),
        const Text(
          "Szállítási opció megadása:",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 10,
        ),
        FutureBuilder(
          future: ShippingOptionsApi.get(),
          builder: (ctx, snapshot) {
            if (snapshot.connectionState == ConnectionState.done) {
              // If we got an error
              if (snapshot.hasError) {
                return const Center(
                  child: Text(
                    'Hiba történt',
                    style: TextStyle(fontSize: 18),
                  ),
                );
              } else if (snapshot.hasData) {
                shippingOptions = snapshot.data!.data;
                selectedshippingOption = shippingOptions.singleOrNull;
                return DropdownMenu<ShippingOption>(
                  width: 300,
                  initialSelection: selectedshippingOption,
                  onSelected: (ShippingOption? value) {
                    widget.shippingOptionChanged(value!.id);
                  },
                  dropdownMenuEntries: shippingOptions
                      .map<DropdownMenuEntry<ShippingOption>>(
                          (ShippingOption value) {
                    return DropdownMenuEntry<ShippingOption>(
                      value: value,
                      label: value.name,
                    );
                  }).toList(),
                );
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            } else {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
          },
        ),
      ],
    );
  }
}
