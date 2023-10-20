part of 'shipping_option_bloc.dart';

@freezed
class ShippingOptionEvent with _$ShippingOptionEvent {
  const factory ShippingOptionEvent.getAll() = _GetAll;
  const factory ShippingOptionEvent.add(ShippingOption entity) = _Add;
  const factory ShippingOptionEvent.update(ShippingOption entity) = _Update;
  const factory ShippingOptionEvent.delete(ShippingOption entity) = _Delete;
}
