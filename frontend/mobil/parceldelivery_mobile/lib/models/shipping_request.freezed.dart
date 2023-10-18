// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'shipping_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

ShippingRequest _$ShippingRequestFromJson(Map<String, dynamic> json) {
  return _ShippingRequest.fromJson(json);
}

/// @nodoc
mixin _$ShippingRequest {
  String get id => throw _privateConstructorUsedError;
  String get userId => throw _privateConstructorUsedError;
  String get name => throw _privateConstructorUsedError;
  String get email => throw _privateConstructorUsedError;
  String get courierId => throw _privateConstructorUsedError;
  Address get addressFrom => throw _privateConstructorUsedError;
  Address get addressTo => throw _privateConstructorUsedError;
  bool get isExpress => throw _privateConstructorUsedError;
  bool get isFinished => throw _privateConstructorUsedError;
  int get status => throw _privateConstructorUsedError;
  PaymentOption get paymentOption => throw _privateConstructorUsedError;
  ShippingOption get shippingOption => throw _privateConstructorUsedError;
  Billing get billing => throw _privateConstructorUsedError;
  List<Package> get packages => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $ShippingRequestCopyWith<ShippingRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ShippingRequestCopyWith<$Res> {
  factory $ShippingRequestCopyWith(
          ShippingRequest value, $Res Function(ShippingRequest) then) =
      _$ShippingRequestCopyWithImpl<$Res, ShippingRequest>;
  @useResult
  $Res call(
      {String id,
      String userId,
      String name,
      String email,
      String courierId,
      Address addressFrom,
      Address addressTo,
      bool isExpress,
      bool isFinished,
      int status,
      PaymentOption paymentOption,
      ShippingOption shippingOption,
      Billing billing,
      List<Package> packages});

  $AddressCopyWith<$Res> get addressFrom;
  $AddressCopyWith<$Res> get addressTo;
  $PaymentOptionCopyWith<$Res> get paymentOption;
  $ShippingOptionCopyWith<$Res> get shippingOption;
  $BillingCopyWith<$Res> get billing;
}

/// @nodoc
class _$ShippingRequestCopyWithImpl<$Res, $Val extends ShippingRequest>
    implements $ShippingRequestCopyWith<$Res> {
  _$ShippingRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? userId = null,
    Object? name = null,
    Object? email = null,
    Object? courierId = null,
    Object? addressFrom = null,
    Object? addressTo = null,
    Object? isExpress = null,
    Object? isFinished = null,
    Object? status = null,
    Object? paymentOption = null,
    Object? shippingOption = null,
    Object? billing = null,
    Object? packages = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      courierId: null == courierId
          ? _value.courierId
          : courierId // ignore: cast_nullable_to_non_nullable
              as String,
      addressFrom: null == addressFrom
          ? _value.addressFrom
          : addressFrom // ignore: cast_nullable_to_non_nullable
              as Address,
      addressTo: null == addressTo
          ? _value.addressTo
          : addressTo // ignore: cast_nullable_to_non_nullable
              as Address,
      isExpress: null == isExpress
          ? _value.isExpress
          : isExpress // ignore: cast_nullable_to_non_nullable
              as bool,
      isFinished: null == isFinished
          ? _value.isFinished
          : isFinished // ignore: cast_nullable_to_non_nullable
              as bool,
      status: null == status
          ? _value.status
          : status // ignore: cast_nullable_to_non_nullable
              as int,
      paymentOption: null == paymentOption
          ? _value.paymentOption
          : paymentOption // ignore: cast_nullable_to_non_nullable
              as PaymentOption,
      shippingOption: null == shippingOption
          ? _value.shippingOption
          : shippingOption // ignore: cast_nullable_to_non_nullable
              as ShippingOption,
      billing: null == billing
          ? _value.billing
          : billing // ignore: cast_nullable_to_non_nullable
              as Billing,
      packages: null == packages
          ? _value.packages
          : packages // ignore: cast_nullable_to_non_nullable
              as List<Package>,
    ) as $Val);
  }

  @override
  @pragma('vm:prefer-inline')
  $AddressCopyWith<$Res> get addressFrom {
    return $AddressCopyWith<$Res>(_value.addressFrom, (value) {
      return _then(_value.copyWith(addressFrom: value) as $Val);
    });
  }

  @override
  @pragma('vm:prefer-inline')
  $AddressCopyWith<$Res> get addressTo {
    return $AddressCopyWith<$Res>(_value.addressTo, (value) {
      return _then(_value.copyWith(addressTo: value) as $Val);
    });
  }

  @override
  @pragma('vm:prefer-inline')
  $PaymentOptionCopyWith<$Res> get paymentOption {
    return $PaymentOptionCopyWith<$Res>(_value.paymentOption, (value) {
      return _then(_value.copyWith(paymentOption: value) as $Val);
    });
  }

  @override
  @pragma('vm:prefer-inline')
  $ShippingOptionCopyWith<$Res> get shippingOption {
    return $ShippingOptionCopyWith<$Res>(_value.shippingOption, (value) {
      return _then(_value.copyWith(shippingOption: value) as $Val);
    });
  }

  @override
  @pragma('vm:prefer-inline')
  $BillingCopyWith<$Res> get billing {
    return $BillingCopyWith<$Res>(_value.billing, (value) {
      return _then(_value.copyWith(billing: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$ShippingRequestImplCopyWith<$Res>
    implements $ShippingRequestCopyWith<$Res> {
  factory _$$ShippingRequestImplCopyWith(_$ShippingRequestImpl value,
          $Res Function(_$ShippingRequestImpl) then) =
      __$$ShippingRequestImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String id,
      String userId,
      String name,
      String email,
      String courierId,
      Address addressFrom,
      Address addressTo,
      bool isExpress,
      bool isFinished,
      int status,
      PaymentOption paymentOption,
      ShippingOption shippingOption,
      Billing billing,
      List<Package> packages});

  @override
  $AddressCopyWith<$Res> get addressFrom;
  @override
  $AddressCopyWith<$Res> get addressTo;
  @override
  $PaymentOptionCopyWith<$Res> get paymentOption;
  @override
  $ShippingOptionCopyWith<$Res> get shippingOption;
  @override
  $BillingCopyWith<$Res> get billing;
}

/// @nodoc
class __$$ShippingRequestImplCopyWithImpl<$Res>
    extends _$ShippingRequestCopyWithImpl<$Res, _$ShippingRequestImpl>
    implements _$$ShippingRequestImplCopyWith<$Res> {
  __$$ShippingRequestImplCopyWithImpl(
      _$ShippingRequestImpl _value, $Res Function(_$ShippingRequestImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? userId = null,
    Object? name = null,
    Object? email = null,
    Object? courierId = null,
    Object? addressFrom = null,
    Object? addressTo = null,
    Object? isExpress = null,
    Object? isFinished = null,
    Object? status = null,
    Object? paymentOption = null,
    Object? shippingOption = null,
    Object? billing = null,
    Object? packages = null,
  }) {
    return _then(_$ShippingRequestImpl(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      courierId: null == courierId
          ? _value.courierId
          : courierId // ignore: cast_nullable_to_non_nullable
              as String,
      addressFrom: null == addressFrom
          ? _value.addressFrom
          : addressFrom // ignore: cast_nullable_to_non_nullable
              as Address,
      addressTo: null == addressTo
          ? _value.addressTo
          : addressTo // ignore: cast_nullable_to_non_nullable
              as Address,
      isExpress: null == isExpress
          ? _value.isExpress
          : isExpress // ignore: cast_nullable_to_non_nullable
              as bool,
      isFinished: null == isFinished
          ? _value.isFinished
          : isFinished // ignore: cast_nullable_to_non_nullable
              as bool,
      status: null == status
          ? _value.status
          : status // ignore: cast_nullable_to_non_nullable
              as int,
      paymentOption: null == paymentOption
          ? _value.paymentOption
          : paymentOption // ignore: cast_nullable_to_non_nullable
              as PaymentOption,
      shippingOption: null == shippingOption
          ? _value.shippingOption
          : shippingOption // ignore: cast_nullable_to_non_nullable
              as ShippingOption,
      billing: null == billing
          ? _value.billing
          : billing // ignore: cast_nullable_to_non_nullable
              as Billing,
      packages: null == packages
          ? _value._packages
          : packages // ignore: cast_nullable_to_non_nullable
              as List<Package>,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$ShippingRequestImpl implements _ShippingRequest {
  const _$ShippingRequestImpl(
      {required this.id,
      required this.userId,
      required this.name,
      required this.email,
      required this.courierId,
      required this.addressFrom,
      required this.addressTo,
      required this.isExpress,
      required this.isFinished,
      required this.status,
      required this.paymentOption,
      required this.shippingOption,
      required this.billing,
      required final List<Package> packages})
      : _packages = packages;

  factory _$ShippingRequestImpl.fromJson(Map<String, dynamic> json) =>
      _$$ShippingRequestImplFromJson(json);

  @override
  final String id;
  @override
  final String userId;
  @override
  final String name;
  @override
  final String email;
  @override
  final String courierId;
  @override
  final Address addressFrom;
  @override
  final Address addressTo;
  @override
  final bool isExpress;
  @override
  final bool isFinished;
  @override
  final int status;
  @override
  final PaymentOption paymentOption;
  @override
  final ShippingOption shippingOption;
  @override
  final Billing billing;
  final List<Package> _packages;
  @override
  List<Package> get packages {
    if (_packages is EqualUnmodifiableListView) return _packages;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_packages);
  }

  @override
  String toString() {
    return 'ShippingRequest(id: $id, userId: $userId, name: $name, email: $email, courierId: $courierId, addressFrom: $addressFrom, addressTo: $addressTo, isExpress: $isExpress, isFinished: $isFinished, status: $status, paymentOption: $paymentOption, shippingOption: $shippingOption, billing: $billing, packages: $packages)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ShippingRequestImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.userId, userId) || other.userId == userId) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.email, email) || other.email == email) &&
            (identical(other.courierId, courierId) ||
                other.courierId == courierId) &&
            (identical(other.addressFrom, addressFrom) ||
                other.addressFrom == addressFrom) &&
            (identical(other.addressTo, addressTo) ||
                other.addressTo == addressTo) &&
            (identical(other.isExpress, isExpress) ||
                other.isExpress == isExpress) &&
            (identical(other.isFinished, isFinished) ||
                other.isFinished == isFinished) &&
            (identical(other.status, status) || other.status == status) &&
            (identical(other.paymentOption, paymentOption) ||
                other.paymentOption == paymentOption) &&
            (identical(other.shippingOption, shippingOption) ||
                other.shippingOption == shippingOption) &&
            (identical(other.billing, billing) || other.billing == billing) &&
            const DeepCollectionEquality().equals(other._packages, _packages));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      id,
      userId,
      name,
      email,
      courierId,
      addressFrom,
      addressTo,
      isExpress,
      isFinished,
      status,
      paymentOption,
      shippingOption,
      billing,
      const DeepCollectionEquality().hash(_packages));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ShippingRequestImplCopyWith<_$ShippingRequestImpl> get copyWith =>
      __$$ShippingRequestImplCopyWithImpl<_$ShippingRequestImpl>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$ShippingRequestImplToJson(
      this,
    );
  }
}

abstract class _ShippingRequest implements ShippingRequest {
  const factory _ShippingRequest(
      {required final String id,
      required final String userId,
      required final String name,
      required final String email,
      required final String courierId,
      required final Address addressFrom,
      required final Address addressTo,
      required final bool isExpress,
      required final bool isFinished,
      required final int status,
      required final PaymentOption paymentOption,
      required final ShippingOption shippingOption,
      required final Billing billing,
      required final List<Package> packages}) = _$ShippingRequestImpl;

  factory _ShippingRequest.fromJson(Map<String, dynamic> json) =
      _$ShippingRequestImpl.fromJson;

  @override
  String get id;
  @override
  String get userId;
  @override
  String get name;
  @override
  String get email;
  @override
  String get courierId;
  @override
  Address get addressFrom;
  @override
  Address get addressTo;
  @override
  bool get isExpress;
  @override
  bool get isFinished;
  @override
  int get status;
  @override
  PaymentOption get paymentOption;
  @override
  ShippingOption get shippingOption;
  @override
  Billing get billing;
  @override
  List<Package> get packages;
  @override
  @JsonKey(ignore: true)
  _$$ShippingRequestImplCopyWith<_$ShippingRequestImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
