// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'add_new_shipping_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

AddNewShippingRequest _$AddNewShippingRequestFromJson(
    Map<String, dynamic> json) {
  return _AddNewShippingRequest.fromJson(json);
}

/// @nodoc
mixin _$AddNewShippingRequest {
  String get userId => throw _privateConstructorUsedError;
  String get courierId => throw _privateConstructorUsedError;
  Address get addressFrom => throw _privateConstructorUsedError;
  Address get addressTo => throw _privateConstructorUsedError;
  bool get isExpress => throw _privateConstructorUsedError;
  int get shippingOptionId => throw _privateConstructorUsedError;
  int get paymentOptionId => throw _privateConstructorUsedError;
  String get billingId => throw _privateConstructorUsedError;
  bool get isFinished => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $AddNewShippingRequestCopyWith<AddNewShippingRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AddNewShippingRequestCopyWith<$Res> {
  factory $AddNewShippingRequestCopyWith(AddNewShippingRequest value,
          $Res Function(AddNewShippingRequest) then) =
      _$AddNewShippingRequestCopyWithImpl<$Res, AddNewShippingRequest>;
  @useResult
  $Res call(
      {String userId,
      String courierId,
      Address addressFrom,
      Address addressTo,
      bool isExpress,
      int shippingOptionId,
      int paymentOptionId,
      String billingId,
      bool isFinished});

  $AddressCopyWith<$Res> get addressFrom;
  $AddressCopyWith<$Res> get addressTo;
}

/// @nodoc
class _$AddNewShippingRequestCopyWithImpl<$Res,
        $Val extends AddNewShippingRequest>
    implements $AddNewShippingRequestCopyWith<$Res> {
  _$AddNewShippingRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = null,
    Object? courierId = null,
    Object? addressFrom = null,
    Object? addressTo = null,
    Object? isExpress = null,
    Object? shippingOptionId = null,
    Object? paymentOptionId = null,
    Object? billingId = null,
    Object? isFinished = null,
  }) {
    return _then(_value.copyWith(
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
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
      shippingOptionId: null == shippingOptionId
          ? _value.shippingOptionId
          : shippingOptionId // ignore: cast_nullable_to_non_nullable
              as int,
      paymentOptionId: null == paymentOptionId
          ? _value.paymentOptionId
          : paymentOptionId // ignore: cast_nullable_to_non_nullable
              as int,
      billingId: null == billingId
          ? _value.billingId
          : billingId // ignore: cast_nullable_to_non_nullable
              as String,
      isFinished: null == isFinished
          ? _value.isFinished
          : isFinished // ignore: cast_nullable_to_non_nullable
              as bool,
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
}

/// @nodoc
abstract class _$$AddNewShippingRequestImplCopyWith<$Res>
    implements $AddNewShippingRequestCopyWith<$Res> {
  factory _$$AddNewShippingRequestImplCopyWith(
          _$AddNewShippingRequestImpl value,
          $Res Function(_$AddNewShippingRequestImpl) then) =
      __$$AddNewShippingRequestImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String userId,
      String courierId,
      Address addressFrom,
      Address addressTo,
      bool isExpress,
      int shippingOptionId,
      int paymentOptionId,
      String billingId,
      bool isFinished});

  @override
  $AddressCopyWith<$Res> get addressFrom;
  @override
  $AddressCopyWith<$Res> get addressTo;
}

/// @nodoc
class __$$AddNewShippingRequestImplCopyWithImpl<$Res>
    extends _$AddNewShippingRequestCopyWithImpl<$Res,
        _$AddNewShippingRequestImpl>
    implements _$$AddNewShippingRequestImplCopyWith<$Res> {
  __$$AddNewShippingRequestImplCopyWithImpl(_$AddNewShippingRequestImpl _value,
      $Res Function(_$AddNewShippingRequestImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = null,
    Object? courierId = null,
    Object? addressFrom = null,
    Object? addressTo = null,
    Object? isExpress = null,
    Object? shippingOptionId = null,
    Object? paymentOptionId = null,
    Object? billingId = null,
    Object? isFinished = null,
  }) {
    return _then(_$AddNewShippingRequestImpl(
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
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
      shippingOptionId: null == shippingOptionId
          ? _value.shippingOptionId
          : shippingOptionId // ignore: cast_nullable_to_non_nullable
              as int,
      paymentOptionId: null == paymentOptionId
          ? _value.paymentOptionId
          : paymentOptionId // ignore: cast_nullable_to_non_nullable
              as int,
      billingId: null == billingId
          ? _value.billingId
          : billingId // ignore: cast_nullable_to_non_nullable
              as String,
      isFinished: null == isFinished
          ? _value.isFinished
          : isFinished // ignore: cast_nullable_to_non_nullable
              as bool,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$AddNewShippingRequestImpl implements _AddNewShippingRequest {
  const _$AddNewShippingRequestImpl(
      {required this.userId,
      required this.courierId,
      required this.addressFrom,
      required this.addressTo,
      required this.isExpress,
      required this.shippingOptionId,
      required this.paymentOptionId,
      required this.billingId,
      required this.isFinished});

  factory _$AddNewShippingRequestImpl.fromJson(Map<String, dynamic> json) =>
      _$$AddNewShippingRequestImplFromJson(json);

  @override
  final String userId;
  @override
  final String courierId;
  @override
  final Address addressFrom;
  @override
  final Address addressTo;
  @override
  final bool isExpress;
  @override
  final int shippingOptionId;
  @override
  final int paymentOptionId;
  @override
  final String billingId;
  @override
  final bool isFinished;

  @override
  String toString() {
    return 'AddNewShippingRequest(userId: $userId, courierId: $courierId, addressFrom: $addressFrom, addressTo: $addressTo, isExpress: $isExpress, shippingOptionId: $shippingOptionId, paymentOptionId: $paymentOptionId, billingId: $billingId, isFinished: $isFinished)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$AddNewShippingRequestImpl &&
            (identical(other.userId, userId) || other.userId == userId) &&
            (identical(other.courierId, courierId) ||
                other.courierId == courierId) &&
            (identical(other.addressFrom, addressFrom) ||
                other.addressFrom == addressFrom) &&
            (identical(other.addressTo, addressTo) ||
                other.addressTo == addressTo) &&
            (identical(other.isExpress, isExpress) ||
                other.isExpress == isExpress) &&
            (identical(other.shippingOptionId, shippingOptionId) ||
                other.shippingOptionId == shippingOptionId) &&
            (identical(other.paymentOptionId, paymentOptionId) ||
                other.paymentOptionId == paymentOptionId) &&
            (identical(other.billingId, billingId) ||
                other.billingId == billingId) &&
            (identical(other.isFinished, isFinished) ||
                other.isFinished == isFinished));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      userId,
      courierId,
      addressFrom,
      addressTo,
      isExpress,
      shippingOptionId,
      paymentOptionId,
      billingId,
      isFinished);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$AddNewShippingRequestImplCopyWith<_$AddNewShippingRequestImpl>
      get copyWith => __$$AddNewShippingRequestImplCopyWithImpl<
          _$AddNewShippingRequestImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$AddNewShippingRequestImplToJson(
      this,
    );
  }
}

abstract class _AddNewShippingRequest implements AddNewShippingRequest {
  const factory _AddNewShippingRequest(
      {required final String userId,
      required final String courierId,
      required final Address addressFrom,
      required final Address addressTo,
      required final bool isExpress,
      required final int shippingOptionId,
      required final int paymentOptionId,
      required final String billingId,
      required final bool isFinished}) = _$AddNewShippingRequestImpl;

  factory _AddNewShippingRequest.fromJson(Map<String, dynamic> json) =
      _$AddNewShippingRequestImpl.fromJson;

  @override
  String get userId;
  @override
  String get courierId;
  @override
  Address get addressFrom;
  @override
  Address get addressTo;
  @override
  bool get isExpress;
  @override
  int get shippingOptionId;
  @override
  int get paymentOptionId;
  @override
  String get billingId;
  @override
  bool get isFinished;
  @override
  @JsonKey(ignore: true)
  _$$AddNewShippingRequestImplCopyWith<_$AddNewShippingRequestImpl>
      get copyWith => throw _privateConstructorUsedError;
}
