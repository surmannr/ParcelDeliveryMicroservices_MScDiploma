import 'package:freezed_annotation/freezed_annotation.dart';

part 'payment_option.freezed.dart';
part 'payment_option.g.dart';

@freezed
class PaymentOption with _$PaymentOption {
  const factory PaymentOption({
    required int id,
    required String name,
  }) = _PaymentOption;

  factory PaymentOption.fromJson(Map<String, Object?> json) =>
      _$PaymentOptionFromJson(json);
}
