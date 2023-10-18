// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'package.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$PackageImpl _$$PackageImplFromJson(Map<String, dynamic> json) =>
    _$PackageImpl(
      id: json['id'] as String,
      userId: json['userId'] as String,
      sizeX: json['sizeX'] as int,
      sizeY: json['sizeY'] as int,
      sizeZ: json['sizeZ'] as int,
      weight: json['weight'] as int,
      isFragile: json['isFragile'] as bool,
      shippingRequestId: json['shippingRequestId'] as String,
    );

Map<String, dynamic> _$$PackageImplToJson(_$PackageImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userId': instance.userId,
      'sizeX': instance.sizeX,
      'sizeY': instance.sizeY,
      'sizeZ': instance.sizeZ,
      'weight': instance.weight,
      'isFragile': instance.isFragile,
      'shippingRequestId': instance.shippingRequestId,
    };
