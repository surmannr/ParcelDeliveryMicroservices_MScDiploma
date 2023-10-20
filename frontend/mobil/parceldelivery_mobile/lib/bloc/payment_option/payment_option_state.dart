part of 'payment_option_bloc.dart';

@freezed
class PaymentOptionState with _$PaymentOptionState {
  const factory PaymentOptionState.loading() = _Loading;
  const factory PaymentOptionState.loaded(PagedResult<PaymentOption> list) =
      _Loaded;
  const factory PaymentOptionState.modified(bool result) = _Modified;
  const factory PaymentOptionState.error(String message) = _Error;

  factory PaymentOptionState.fromJson(Map<String, Object?> json) =>
      _$PaymentOptionStateFromJson(json);
}
