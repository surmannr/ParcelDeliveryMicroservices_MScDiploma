// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vehicle.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$VehicleImpl _$$VehicleImplFromJson(Map<String, dynamic> json) =>
    _$VehicleImpl(
      id: json['id'] as String,
      registrationNumber: json['registrationNumber'] as String,
      type: json['type'] as String,
      year: json['year'] as int,
      technicalInspectionExpirationDate:
          DateTime.parse(json['technicalInspectionExpirationDate'] as String),
      seatingCapacity: json['seatingCapacity'] as int,
      maxInternalSpaceX: json['maxInternalSpaceX'] as int,
      maxInternalSpaceY: json['maxInternalSpaceY'] as int,
      maxInternalSpaceZ: json['maxInternalSpaceZ'] as int,
    );

Map<String, dynamic> _$$VehicleImplToJson(_$VehicleImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'registrationNumber': instance.registrationNumber,
      'type': instance.type,
      'year': instance.year,
      'technicalInspectionExpirationDate':
          instance.technicalInspectionExpirationDate.toIso8601String(),
      'seatingCapacity': instance.seatingCapacity,
      'maxInternalSpaceX': instance.maxInternalSpaceX,
      'maxInternalSpaceY': instance.maxInternalSpaceY,
      'maxInternalSpaceZ': instance.maxInternalSpaceZ,
    };
