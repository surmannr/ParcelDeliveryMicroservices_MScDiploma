// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_new_billing.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$AddNewBillingImpl _$$AddNewBillingImplFromJson(Map<String, dynamic> json) =>
    _$AddNewBillingImpl(
      userId: json['userId'] as String,
      totalDistance: json['totalDistance'] as int,
      totalAmount: json['totalAmount'] as int,
      currencyId: json['currencyId'] as int,
    );

Map<String, dynamic> _$$AddNewBillingImplToJson(_$AddNewBillingImpl instance) =>
    <String, dynamic>{
      'userId': instance.userId,
      'totalDistance': instance.totalDistance,
      'totalAmount': instance.totalAmount,
      'currencyId': instance.currencyId,
    };
