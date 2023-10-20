import 'package:freezed_annotation/freezed_annotation.dart';

part 'vehicle.freezed.dart';
part 'vehicle.g.dart';

@freezed
class Vehicle with _$Vehicle {
  const factory Vehicle({
    required String id,
    required String registrationNumber,
    required String type,
    required int year,
    required DateTime technicalInspectionExpirationDate,
    required int seatingCapacity,
    required int maxInternalSpaceX,
    required int maxInternalSpaceY,
    required int maxInternalSpaceZ,
  }) = _Vehicle;

  factory Vehicle.fromJson(Map<String, Object?> json) =>
      _$VehicleFromJson(json);
}
