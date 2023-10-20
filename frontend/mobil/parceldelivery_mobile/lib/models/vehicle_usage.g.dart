// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vehicle_usage.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$VehicleUsageImpl _$$VehicleUsageImplFromJson(Map<String, dynamic> json) =>
    _$VehicleUsageImpl(
      id: json['id'] as String,
      employeeId: json['employeeId'] as String,
      employeeName: json['employeeName'] as String,
      employeeEmail: json['employeeEmail'] as String,
      vehicle: Vehicle.fromJson(json['vehicle'] as Map<String, dynamic>),
      dateFrom: DateTime.parse(json['dateFrom'] as String),
      dateTo: DateTime.parse(json['dateTo'] as String),
      note: json['note'] as String,
    );

Map<String, dynamic> _$$VehicleUsageImplToJson(_$VehicleUsageImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'employeeId': instance.employeeId,
      'employeeName': instance.employeeName,
      'employeeEmail': instance.employeeEmail,
      'vehicle': instance.vehicle,
      'dateFrom': instance.dateFrom.toIso8601String(),
      'dateTo': instance.dateTo.toIso8601String(),
      'note': instance.note,
    };
