// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'accepted_ship_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$AcceptedShipRequestImpl _$$AcceptedShipRequestImplFromJson(
        Map<String, dynamic> json) =>
    _$AcceptedShipRequestImpl(
      id: json['id'] as String,
      employeeId: json['employeeId'] as String,
      employeeName: json['employeeName'] as String,
      employeeEmail: json['employeeEmail'] as String,
      vehicle: Vehicle.fromJson(json['vehicle'] as Map<String, dynamic>),
      packages: (json['packages'] as List<dynamic>)
          .map((e) => Package.fromJson(e as Map<String, dynamic>))
          .toList(),
      shippingRequests: (json['shippingRequests'] as List<dynamic>)
          .map((e) => ShippingRequest.fromJson(e as Map<String, dynamic>))
          .toList(),
      isAllPackageTaken: json['isAllPackageTaken'] as bool,
      isAssignedToEmployee: json['isAssignedToEmployee'] as bool,
      readPackageIds: (json['readPackageIds'] as List<dynamic>)
          .map((e) => e as String)
          .toList(),
    );

Map<String, dynamic> _$$AcceptedShipRequestImplToJson(
        _$AcceptedShipRequestImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'employeeId': instance.employeeId,
      'employeeName': instance.employeeName,
      'employeeEmail': instance.employeeEmail,
      'vehicle': instance.vehicle,
      'packages': instance.packages,
      'shippingRequests': instance.shippingRequests,
      'isAllPackageTaken': instance.isAllPackageTaken,
      'isAssignedToEmployee': instance.isAssignedToEmployee,
      'readPackageIds': instance.readPackageIds,
    };
