// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'shipping_option.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

ShippingOption _$ShippingOptionFromJson(Map<String, dynamic> json) {
  return _ShippingOption.fromJson(json);
}

/// @nodoc
mixin _$ShippingOption {
  int get id => throw _privateConstructorUsedError;
  String get name => throw _privateConstructorUsedError;
  int get price => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $ShippingOptionCopyWith<ShippingOption> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ShippingOptionCopyWith<$Res> {
  factory $ShippingOptionCopyWith(
          ShippingOption value, $Res Function(ShippingOption) then) =
      _$ShippingOptionCopyWithImpl<$Res, ShippingOption>;
  @useResult
  $Res call({int id, String name, int price});
}

/// @nodoc
class _$ShippingOptionCopyWithImpl<$Res, $Val extends ShippingOption>
    implements $ShippingOptionCopyWith<$Res> {
  _$ShippingOptionCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? name = null,
    Object? price = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      price: null == price
          ? _value.price
          : price // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$ShippingOptionImplCopyWith<$Res>
    implements $ShippingOptionCopyWith<$Res> {
  factory _$$ShippingOptionImplCopyWith(_$ShippingOptionImpl value,
          $Res Function(_$ShippingOptionImpl) then) =
      __$$ShippingOptionImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({int id, String name, int price});
}

/// @nodoc
class __$$ShippingOptionImplCopyWithImpl<$Res>
    extends _$ShippingOptionCopyWithImpl<$Res, _$ShippingOptionImpl>
    implements _$$ShippingOptionImplCopyWith<$Res> {
  __$$ShippingOptionImplCopyWithImpl(
      _$ShippingOptionImpl _value, $Res Function(_$ShippingOptionImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? name = null,
    Object? price = null,
  }) {
    return _then(_$ShippingOptionImpl(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      price: null == price
          ? _value.price
          : price // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$ShippingOptionImpl implements _ShippingOption {
  const _$ShippingOptionImpl(
      {required this.id, required this.name, required this.price});

  factory _$ShippingOptionImpl.fromJson(Map<String, dynamic> json) =>
      _$$ShippingOptionImplFromJson(json);

  @override
  final int id;
  @override
  final String name;
  @override
  final int price;

  @override
  String toString() {
    return 'ShippingOption(id: $id, name: $name, price: $price)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ShippingOptionImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.price, price) || other.price == price));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, id, name, price);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ShippingOptionImplCopyWith<_$ShippingOptionImpl> get copyWith =>
      __$$ShippingOptionImplCopyWithImpl<_$ShippingOptionImpl>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$ShippingOptionImplToJson(
      this,
    );
  }
}

abstract class _ShippingOption implements ShippingOption {
  const factory _ShippingOption(
      {required final int id,
      required final String name,
      required final int price}) = _$ShippingOptionImpl;

  factory _ShippingOption.fromJson(Map<String, dynamic> json) =
      _$ShippingOptionImpl.fromJson;

  @override
  int get id;
  @override
  String get name;
  @override
  int get price;
  @override
  @JsonKey(ignore: true)
  _$$ShippingOptionImplCopyWith<_$ShippingOptionImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
