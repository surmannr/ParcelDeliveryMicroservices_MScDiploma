// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_new_shipping_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$AddNewShippingRequestImpl _$$AddNewShippingRequestImplFromJson(
        Map<String, dynamic> json) =>
    _$AddNewShippingRequestImpl(
      userId: json['userId'] as String,
      name: json['name'] as String,
      email: json['email'] as String,
      courierId: json['courierId'] as String,
      addressFrom:
          Address.fromJson(json['addressFrom'] as Map<String, dynamic>),
      addressTo: Address.fromJson(json['addressTo'] as Map<String, dynamic>),
      isExpress: json['isExpress'] as bool,
      shippingOptionId: json['shippingOptionId'] as int,
      paymentOptionId: json['paymentOptionId'] as int,
      billingId: json['billingId'] as String,
      isFinished: json['isFinished'] as bool,
      packages: (json['packages'] as List<dynamic>)
          .map((e) => Package.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$$AddNewShippingRequestImplToJson(
        _$AddNewShippingRequestImpl instance) =>
    <String, dynamic>{
      'userId': instance.userId,
      'name': instance.name,
      'email': instance.email,
      'courierId': instance.courierId,
      'addressFrom': instance.addressFrom,
      'addressTo': instance.addressTo,
      'isExpress': instance.isExpress,
      'shippingOptionId': instance.shippingOptionId,
      'paymentOptionId': instance.paymentOptionId,
      'billingId': instance.billingId,
      'isFinished': instance.isFinished,
      'packages': instance.packages,
    };
