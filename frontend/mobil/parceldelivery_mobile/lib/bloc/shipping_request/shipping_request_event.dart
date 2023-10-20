part of 'shipping_request_bloc.dart';

@freezed
class ShippingRequestEvent with _$ShippingRequestEvent {
  const factory ShippingRequestEvent.getAll() = _GetAll;
  const factory ShippingRequestEvent.add(ShippingRequest entity) = _Add;
  const factory ShippingRequestEvent.update(ShippingRequest entity) = _Update;
  const factory ShippingRequestEvent.track(String id) = _Track;
}
