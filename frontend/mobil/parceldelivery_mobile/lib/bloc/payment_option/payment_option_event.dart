part of 'payment_option_bloc.dart';

@freezed
class PaymentOptionEvent with _$PaymentOptionEvent {
  const factory PaymentOptionEvent.getAll() = _GetAll;
  const factory PaymentOptionEvent.add(PaymentOption entity) = _Add;
  const factory PaymentOptionEvent.update(PaymentOption entity) = _Update;
  const factory PaymentOptionEvent.delete(PaymentOption entity) = _Delete;
}
