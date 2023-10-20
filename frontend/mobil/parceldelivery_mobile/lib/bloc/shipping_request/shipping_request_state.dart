part of 'shipping_request_bloc.dart';

@freezed
class ShippingRequestState with _$ShippingRequestState {
  const factory ShippingRequestState.loading() = _Loading;
  const factory ShippingRequestState.loaded(PagedResult<ShippingRequest> list) =
      _Loaded;
  const factory ShippingRequestState.modified(bool result) = _Modified;
  const factory ShippingRequestState.error(String message) = _Error;

  factory ShippingRequestState.fromJson(Map<String, Object?> json) =>
      _$ShippingRequestStateFromJson(json);
}
