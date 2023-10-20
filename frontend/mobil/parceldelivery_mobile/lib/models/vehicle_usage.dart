import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:parceldelivery_mobile/models/vehicle.dart';

part 'vehicle_usage.freezed.dart';
part 'vehicle_usage.g.dart';

@freezed
class VehicleUsage with _$VehicleUsage {
  const factory VehicleUsage({
    required String id,
    required String employeeId,
    required String employeeName,
    required String employeeEmail,
    required Vehicle vehicle,
    required DateTime dateFrom,
    required DateTime dateTo,
    required String note,
  }) = _VehicleUsage;

  factory VehicleUsage.fromJson(Map<String, Object?> json) =>
      _$VehicleUsageFromJson(json);
}
