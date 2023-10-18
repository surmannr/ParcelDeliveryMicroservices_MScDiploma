import 'package:freezed_annotation/freezed_annotation.dart';

part 'shipping_option.freezed.dart';
part 'shipping_option.g.dart';

@freezed
class ShippingOption with _$ShippingOption {
  const factory ShippingOption({
    required int id,
    required String name,
    required int price,
  }) = _ShippingOption;

  factory ShippingOption.fromJson(Map<String, Object?> json) =>
      _$ShippingOptionFromJson(json);
}
