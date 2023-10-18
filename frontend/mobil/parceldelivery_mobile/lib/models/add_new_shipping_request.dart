import 'package:parceldelivery_mobile/models/address.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'add_new_shipping_request.freezed.dart';
part 'add_new_shipping_request.g.dart';

@freezed
class AddNewShippingRequest with _$AddNewShippingRequest {
  const factory AddNewShippingRequest({
    required String userId,
    required String courierId,
    required Address addressFrom,
    required Address addressTo,
    required bool isExpress,
    required int shippingOptionId,
    required int paymentOptionId,
    required String billingId,
    required bool isFinished,
  }) = _AddNewShippingRequest;

  factory AddNewShippingRequest.fromJson(Map<String, Object?> json) =>
      _$AddNewShippingRequestFromJson(json);
}
