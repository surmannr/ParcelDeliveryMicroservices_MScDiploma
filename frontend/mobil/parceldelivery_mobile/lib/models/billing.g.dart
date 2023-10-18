// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'billing.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$BillingImpl _$$BillingImplFromJson(Map<String, dynamic> json) =>
    _$BillingImpl(
      id: json['id'] as String,
      userId: json['userId'] as String,
      name: json['name'] as String,
      totalDistance: json['totalDistance'] as int,
      totalAmount: json['totalAmount'] as int,
      currency: Currency.fromJson(json['currency'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$$BillingImplToJson(_$BillingImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userId': instance.userId,
      'name': instance.name,
      'totalDistance': instance.totalDistance,
      'totalAmount': instance.totalAmount,
      'currency': instance.currency,
    };
