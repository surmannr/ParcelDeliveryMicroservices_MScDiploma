// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'shipping_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$ShippingRequestImpl _$$ShippingRequestImplFromJson(
        Map<String, dynamic> json) =>
    _$ShippingRequestImpl(
      id: json['id'] as String,
      userId: json['userId'] as String,
      name: json['name'] as String,
      email: json['email'] as String,
      courierId: json['courierId'] as String,
      addressFrom:
          Address.fromJson(json['addressFrom'] as Map<String, dynamic>),
      addressTo: Address.fromJson(json['addressTo'] as Map<String, dynamic>),
      isExpress: json['isExpress'] as bool,
      isFinished: json['isFinished'] as bool,
      status: json['status'] as int,
      paymentOption:
          PaymentOption.fromJson(json['paymentOption'] as Map<String, dynamic>),
      shippingOption: ShippingOption.fromJson(
          json['shippingOption'] as Map<String, dynamic>),
      billing: Billing.fromJson(json['billing'] as Map<String, dynamic>),
      packages: (json['packages'] as List<dynamic>)
          .map((e) => Package.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$$ShippingRequestImplToJson(
        _$ShippingRequestImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userId': instance.userId,
      'name': instance.name,
      'email': instance.email,
      'courierId': instance.courierId,
      'addressFrom': instance.addressFrom,
      'addressTo': instance.addressTo,
      'isExpress': instance.isExpress,
      'isFinished': instance.isFinished,
      'status': instance.status,
      'paymentOption': instance.paymentOption,
      'shippingOption': instance.shippingOption,
      'billing': instance.billing,
      'packages': instance.packages,
    };
