import 'package:freezed_annotation/freezed_annotation.dart';

import 'currency.dart';

part 'billing.freezed.dart';
part 'billing.g.dart';

@freezed
class Billing with _$Billing {
  const factory Billing({
    required String id,
    required String userId,
    required String name,
    required int totalDistance,
    required int totalAmount,
    required Currency currency,
  }) = _Billing;

  factory Billing.fromJson(Map<String, Object?> json) =>
      _$BillingFromJson(json);
}
