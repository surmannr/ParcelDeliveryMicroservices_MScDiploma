import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:parceldelivery_mobile/models/address.dart';
import 'package:parceldelivery_mobile/models/billing.dart';
import 'package:parceldelivery_mobile/models/package.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

part 'shipping_request.freezed.dart';
part 'shipping_request.g.dart';

@freezed
class ShippingRequest with _$ShippingRequest {
  const factory ShippingRequest({
    required String id,
    required String userId,
    required String name,
    required String email,
    required String courierId,
    required Address addressFrom,
    required Address addressTo,
    required bool isExpress,
    required bool isFinished,
    required int status,
    required PaymentOption paymentOption,
    required ShippingOption shippingOption,
    required Billing billing,
    required List<Package> packages,
  }) = _ShippingRequest;

  factory ShippingRequest.fromJson(Map<String, Object?> json) =>
      _$ShippingRequestFromJson(json);
}
