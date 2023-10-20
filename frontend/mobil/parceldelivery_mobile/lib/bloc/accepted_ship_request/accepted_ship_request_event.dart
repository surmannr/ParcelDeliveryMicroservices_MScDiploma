part of 'accepted_ship_request_bloc.dart';

@freezed
class AcceptedShipRequestEvent with _$AcceptedShipRequestEvent {
  const factory AcceptedShipRequestEvent.getAll() = _GetAll;
  const factory AcceptedShipRequestEvent.update(AcceptedShipRequest entity) =
      _Update;
}
