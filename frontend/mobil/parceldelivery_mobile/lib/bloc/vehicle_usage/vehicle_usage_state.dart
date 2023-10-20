part of 'vehicle_usage_bloc.dart';

@freezed
class VehicleUsageState with _$VehicleUsageState {
  const factory VehicleUsageState.loading() = _Loading;
  const factory VehicleUsageState.loaded(PagedResult<VehicleUsage> list) =
      _Loaded;
  const factory VehicleUsageState.error(String message) = _Error;

  factory VehicleUsageState.fromJson(Map<String, Object?> json) =>
      _$VehicleUsageStateFromJson(json);
}
