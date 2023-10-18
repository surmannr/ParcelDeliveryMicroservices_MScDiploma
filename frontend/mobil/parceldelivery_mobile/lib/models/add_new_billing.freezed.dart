// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'add_new_billing.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

AddNewBilling _$AddNewBillingFromJson(Map<String, dynamic> json) {
  return _AddNewBilling.fromJson(json);
}

/// @nodoc
mixin _$AddNewBilling {
  String get userId => throw _privateConstructorUsedError;
  int get totalDistance => throw _privateConstructorUsedError;
  int get totalAmount => throw _privateConstructorUsedError;
  int get currencyId => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $AddNewBillingCopyWith<AddNewBilling> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AddNewBillingCopyWith<$Res> {
  factory $AddNewBillingCopyWith(
          AddNewBilling value, $Res Function(AddNewBilling) then) =
      _$AddNewBillingCopyWithImpl<$Res, AddNewBilling>;
  @useResult
  $Res call(
      {String userId, int totalDistance, int totalAmount, int currencyId});
}

/// @nodoc
class _$AddNewBillingCopyWithImpl<$Res, $Val extends AddNewBilling>
    implements $AddNewBillingCopyWith<$Res> {
  _$AddNewBillingCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = null,
    Object? totalDistance = null,
    Object? totalAmount = null,
    Object? currencyId = null,
  }) {
    return _then(_value.copyWith(
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String,
      totalDistance: null == totalDistance
          ? _value.totalDistance
          : totalDistance // ignore: cast_nullable_to_non_nullable
              as int,
      totalAmount: null == totalAmount
          ? _value.totalAmount
          : totalAmount // ignore: cast_nullable_to_non_nullable
              as int,
      currencyId: null == currencyId
          ? _value.currencyId
          : currencyId // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$AddNewBillingImplCopyWith<$Res>
    implements $AddNewBillingCopyWith<$Res> {
  factory _$$AddNewBillingImplCopyWith(
          _$AddNewBillingImpl value, $Res Function(_$AddNewBillingImpl) then) =
      __$$AddNewBillingImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String userId, int totalDistance, int totalAmount, int currencyId});
}

/// @nodoc
class __$$AddNewBillingImplCopyWithImpl<$Res>
    extends _$AddNewBillingCopyWithImpl<$Res, _$AddNewBillingImpl>
    implements _$$AddNewBillingImplCopyWith<$Res> {
  __$$AddNewBillingImplCopyWithImpl(
      _$AddNewBillingImpl _value, $Res Function(_$AddNewBillingImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? userId = null,
    Object? totalDistance = null,
    Object? totalAmount = null,
    Object? currencyId = null,
  }) {
    return _then(_$AddNewBillingImpl(
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String,
      totalDistance: null == totalDistance
          ? _value.totalDistance
          : totalDistance // ignore: cast_nullable_to_non_nullable
              as int,
      totalAmount: null == totalAmount
          ? _value.totalAmount
          : totalAmount // ignore: cast_nullable_to_non_nullable
              as int,
      currencyId: null == currencyId
          ? _value.currencyId
          : currencyId // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$AddNewBillingImpl implements _AddNewBilling {
  const _$AddNewBillingImpl(
      {required this.userId,
      required this.totalDistance,
      required this.totalAmount,
      required this.currencyId});

  factory _$AddNewBillingImpl.fromJson(Map<String, dynamic> json) =>
      _$$AddNewBillingImplFromJson(json);

  @override
  final String userId;
  @override
  final int totalDistance;
  @override
  final int totalAmount;
  @override
  final int currencyId;

  @override
  String toString() {
    return 'AddNewBilling(userId: $userId, totalDistance: $totalDistance, totalAmount: $totalAmount, currencyId: $currencyId)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$AddNewBillingImpl &&
            (identical(other.userId, userId) || other.userId == userId) &&
            (identical(other.totalDistance, totalDistance) ||
                other.totalDistance == totalDistance) &&
            (identical(other.totalAmount, totalAmount) ||
                other.totalAmount == totalAmount) &&
            (identical(other.currencyId, currencyId) ||
                other.currencyId == currencyId));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, userId, totalDistance, totalAmount, currencyId);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$AddNewBillingImplCopyWith<_$AddNewBillingImpl> get copyWith =>
      __$$AddNewBillingImplCopyWithImpl<_$AddNewBillingImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$AddNewBillingImplToJson(
      this,
    );
  }
}

abstract class _AddNewBilling implements AddNewBilling {
  const factory _AddNewBilling(
      {required final String userId,
      required final int totalDistance,
      required final int totalAmount,
      required final int currencyId}) = _$AddNewBillingImpl;

  factory _AddNewBilling.fromJson(Map<String, dynamic> json) =
      _$AddNewBillingImpl.fromJson;

  @override
  String get userId;
  @override
  int get totalDistance;
  @override
  int get totalAmount;
  @override
  int get currencyId;
  @override
  @JsonKey(ignore: true)
  _$$AddNewBillingImplCopyWith<_$AddNewBillingImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
