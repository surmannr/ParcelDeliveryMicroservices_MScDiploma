part of 'shipping_option_bloc.dart';

@freezed
class ShippingOptionState with _$ShippingOptionState {
  const factory ShippingOptionState.loading() = _Loading;
  const factory ShippingOptionState.loaded(PagedResult<ShippingOption> list) =
      _Loaded;
  const factory ShippingOptionState.modified(bool result) = _Modified;
  const factory ShippingOptionState.error(String message) = _Error;

  factory ShippingOptionState.fromJson(Map<String, Object?> json) =>
      _$ShippingOptionStateFromJson(json);
}
