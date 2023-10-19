part of 'currency_bloc.dart';

@freezed
class CurrencyState with _$CurrencyState {
  const factory CurrencyState.loading() = _Loading;
  const factory CurrencyState.loaded(PagedResult<Currency> list) = _Loaded;
  const factory CurrencyState.modified(bool result) = _Modified;
  const factory CurrencyState.error(String message) = _Error;

  factory CurrencyState.fromJson(Map<String, Object?> json) =>
      _$CurrencyStateFromJson(json);
}
