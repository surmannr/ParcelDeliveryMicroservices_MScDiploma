import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:parceldelivery_mobile/models/package.dart';
import 'package:parceldelivery_mobile/models/shipping_request.dart';
import 'package:parceldelivery_mobile/models/vehicle.dart';

part 'accepted_ship_request.freezed.dart';
part 'accepted_ship_request.g.dart';

@freezed
class AcceptedShipRequest with _$AcceptedShipRequest {
  const factory AcceptedShipRequest({
    required String id,
    required String employeeId,
    required String employeeName,
    required String employeeEmail,
    required Vehicle vehicle,
    required List<Package> packages,
    required List<ShippingRequest> shippingRequests,
    required bool isAllPackageTaken,
    required bool isAssignedToEmployee,
    required List<String> readPackageIds,
  }) = _AcceptedShipRequest;

  factory AcceptedShipRequest.fromJson(Map<String, Object?> json) =>
      _$AcceptedShipRequestFromJson(json);
}
