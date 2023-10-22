import 'package:freezed_annotation/freezed_annotation.dart';

part 'add_new_billing.freezed.dart';
part 'add_new_billing.g.dart';

@freezed
class AddNewBilling with _$AddNewBilling {
  const factory AddNewBilling({
    required String userId,
    required String name,
    required int totalDistance,
    required int totalAmount,
    required int currencyId,
  }) = _AddNewBilling;

  factory AddNewBilling.fromJson(Map<String, Object?> json) =>
      _$AddNewBillingFromJson(json);
}
