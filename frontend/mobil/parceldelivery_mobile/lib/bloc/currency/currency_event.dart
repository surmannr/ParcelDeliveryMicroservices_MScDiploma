part of 'currency_bloc.dart';

@freezed
class CurrencyEvent with _$CurrencyEvent {
  const factory CurrencyEvent.getAll() = _GetAll;
  const factory CurrencyEvent.add(Currency entity) = _Add;
  const factory CurrencyEvent.update(Currency entity) = _Update;
  const factory CurrencyEvent.delete(Currency entity) = _Delete;
}
