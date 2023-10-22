import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

class ShipReqStepThreeOther extends StatefulWidget {
  const ShipReqStepThreeOther({
    required this.paymentOptionChanged,
    required this.shippingOptionChanged,
    required this.currencyChanged,
    required this.currencyId,
    required this.paymentOptionId,
    required this.shippingOptionId,
    required this.currencies,
    required this.shippingOptions,
    required this.paymentOptions,
    super.key,
  });

  final void Function(int paymentOption) paymentOptionChanged;
  final void Function(int shippingOption) shippingOptionChanged;
  final void Function(int currency) currencyChanged;

  final int currencyId;
  final int paymentOptionId;
  final int shippingOptionId;

  final List<PaymentOption> paymentOptions;
  final List<ShippingOption> shippingOptions;
  final List<Currency> currencies;

  @override
  State<ShipReqStepThreeOther> createState() => _ShipReqStepThreeOtherState();
}

class _ShipReqStepThreeOtherState extends State<ShipReqStepThreeOther> {
  @override
  void initState() {
    super.initState();
  }

  PaymentOption? selectedPaymentOption;
  ShippingOption? selectedShippingOption;
  Currency? selectedCurrency;

  @override
  Widget build(BuildContext context) {
    selectedPaymentOption = widget.paymentOptions
        .where((element) => element.id == widget.paymentOptionId)
        .singleOrNull;
    selectedShippingOption = widget.shippingOptions
        .where((element) => element.id == widget.shippingOptionId)
        .singleOrNull;
    selectedCurrency = widget.currencies
        .where((element) => element.id == widget.currencyId)
        .singleOrNull;
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
        DropdownButtonFormField<PaymentOption>(
          value: selectedPaymentOption,
          onChanged: (PaymentOption? value) {
            widget.paymentOptionChanged(value!.id);
          },
          validator: (PaymentOption? value) {
            return value == null ? "Válassz egy fizetési opciót" : null;
          },
          hint: const Text("Válassz"),
          items: widget.paymentOptions
              .map<DropdownMenuItem<PaymentOption>>((PaymentOption value) {
            return DropdownMenuItem<PaymentOption>(
              value: value,
              child: Text(value.name),
            );
          }).toList(),
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
        DropdownButtonFormField<ShippingOption>(
          value: selectedShippingOption,
          onChanged: (ShippingOption? value) {
            widget.shippingOptionChanged(value!.id);
          },
          validator: (ShippingOption? value) {
            return value == null ? "Válassz egy szállítási opciót" : null;
          },
          hint: const Text("Válassz"),
          items: widget.shippingOptions
              .map<DropdownMenuItem<ShippingOption>>((ShippingOption value) {
            return DropdownMenuItem<ShippingOption>(
              value: value,
              child: Text(value.name),
            );
          }).toList(),
        ),
        const SizedBox(
          height: 10,
        ),
        const Text(
          "Valuta megadása:",
          style: TextStyle(
            fontSize: 20,
          ),
          textAlign: TextAlign.start,
        ),
        const SizedBox(
          height: 10,
        ),
        DropdownButtonFormField<Currency>(
          value: selectedCurrency,
          onChanged: (Currency? value) {
            widget.currencyChanged(value!.id);
          },
          validator: (Currency? value) {
            return value == null ? "Válassz egy valutát" : null;
          },
          hint: const Text("Válassz"),
          items: widget.currencies
              .map<DropdownMenuItem<Currency>>((Currency value) {
            return DropdownMenuItem<Currency>(
              value: value,
              child: Text(value.name),
            );
          }).toList(),
        ),
      ],
    );
  }
}
