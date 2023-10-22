part of 'shipping_request_bloc.dart';

@freezed
class ShippingRequestEvent with _$ShippingRequestEvent {
  const factory ShippingRequestEvent.getAll() = _GetAll;
  const factory ShippingRequestEvent.add(
      AddNewShippingRequest entity, AddNewBilling billing) = _Add;
  const factory ShippingRequestEvent.update(AddNewShippingRequest entity) =
      _Update;
  const factory ShippingRequestEvent.track(String id) = _Track;
}
