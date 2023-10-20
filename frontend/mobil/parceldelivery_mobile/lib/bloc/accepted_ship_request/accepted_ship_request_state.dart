part of 'accepted_ship_request_bloc.dart';

@freezed
class AcceptedShipRequestState with _$AcceptedShipRequestState {
  const factory AcceptedShipRequestState.loading() = _Loading;
  const factory AcceptedShipRequestState.loaded(
      PagedResult<AcceptedShipRequest> list) = _Loaded;
  const factory AcceptedShipRequestState.modified(bool result) = _Modified;
  const factory AcceptedShipRequestState.error(String message) = _Error;

  factory AcceptedShipRequestState.fromJson(Map<String, Object?> json) =>
      _$AcceptedShipRequestStateFromJson(json);
}
