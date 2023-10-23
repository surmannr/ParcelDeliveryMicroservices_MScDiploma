// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'package.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

Package _$PackageFromJson(Map<String, dynamic> json) {
  return _Package.fromJson(json);
}

/// @nodoc
mixin _$Package {
  String get id => throw _privateConstructorUsedError;
  String get userId => throw _privateConstructorUsedError;
  int get sizeX => throw _privateConstructorUsedError;
  int get sizeY => throw _privateConstructorUsedError;
  int get sizeZ => throw _privateConstructorUsedError;
  int get weight => throw _privateConstructorUsedError;
  bool get isFragile => throw _privateConstructorUsedError;
  String? get shippingRequestId => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $PackageCopyWith<Package> get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PackageCopyWith<$Res> {
  factory $PackageCopyWith(Package value, $Res Function(Package) then) =
      _$PackageCopyWithImpl<$Res, Package>;
  @useResult
  $Res call(
      {String id,
      String userId,
      int sizeX,
      int sizeY,
      int sizeZ,
      int weight,
      bool isFragile,
      String? shippingRequestId});
}

/// @nodoc
class _$PackageCopyWithImpl<$Res, $Val extends Package>
    implements $PackageCopyWith<$Res> {
  _$PackageCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? userId = null,
    Object? sizeX = null,
    Object? sizeY = null,
    Object? sizeZ = null,
    Object? weight = null,
    Object? isFragile = null,
    Object? shippingRequestId = freezed,
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
      sizeX: null == sizeX
          ? _value.sizeX
          : sizeX // ignore: cast_nullable_to_non_nullable
              as int,
      sizeY: null == sizeY
          ? _value.sizeY
          : sizeY // ignore: cast_nullable_to_non_nullable
              as int,
      sizeZ: null == sizeZ
          ? _value.sizeZ
          : sizeZ // ignore: cast_nullable_to_non_nullable
              as int,
      weight: null == weight
          ? _value.weight
          : weight // ignore: cast_nullable_to_non_nullable
              as int,
      isFragile: null == isFragile
          ? _value.isFragile
          : isFragile // ignore: cast_nullable_to_non_nullable
              as bool,
      shippingRequestId: freezed == shippingRequestId
          ? _value.shippingRequestId
          : shippingRequestId // ignore: cast_nullable_to_non_nullable
              as String?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PackageImplCopyWith<$Res> implements $PackageCopyWith<$Res> {
  factory _$$PackageImplCopyWith(
          _$PackageImpl value, $Res Function(_$PackageImpl) then) =
      __$$PackageImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String id,
      String userId,
      int sizeX,
      int sizeY,
      int sizeZ,
      int weight,
      bool isFragile,
      String? shippingRequestId});
}

/// @nodoc
class __$$PackageImplCopyWithImpl<$Res>
    extends _$PackageCopyWithImpl<$Res, _$PackageImpl>
    implements _$$PackageImplCopyWith<$Res> {
  __$$PackageImplCopyWithImpl(
      _$PackageImpl _value, $Res Function(_$PackageImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? userId = null,
    Object? sizeX = null,
    Object? sizeY = null,
    Object? sizeZ = null,
    Object? weight = null,
    Object? isFragile = null,
    Object? shippingRequestId = freezed,
  }) {
    return _then(_$PackageImpl(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      userId: null == userId
          ? _value.userId
          : userId // ignore: cast_nullable_to_non_nullable
              as String,
      sizeX: null == sizeX
          ? _value.sizeX
          : sizeX // ignore: cast_nullable_to_non_nullable
              as int,
      sizeY: null == sizeY
          ? _value.sizeY
          : sizeY // ignore: cast_nullable_to_non_nullable
              as int,
      sizeZ: null == sizeZ
          ? _value.sizeZ
          : sizeZ // ignore: cast_nullable_to_non_nullable
              as int,
      weight: null == weight
          ? _value.weight
          : weight // ignore: cast_nullable_to_non_nullable
              as int,
      isFragile: null == isFragile
          ? _value.isFragile
          : isFragile // ignore: cast_nullable_to_non_nullable
              as bool,
      shippingRequestId: freezed == shippingRequestId
          ? _value.shippingRequestId
          : shippingRequestId // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$PackageImpl implements _Package {
  const _$PackageImpl(
      {required this.id,
      required this.userId,
      required this.sizeX,
      required this.sizeY,
      required this.sizeZ,
      required this.weight,
      required this.isFragile,
      this.shippingRequestId});

  factory _$PackageImpl.fromJson(Map<String, dynamic> json) =>
      _$$PackageImplFromJson(json);

  @override
  final String id;
  @override
  final String userId;
  @override
  final int sizeX;
  @override
  final int sizeY;
  @override
  final int sizeZ;
  @override
  final int weight;
  @override
  final bool isFragile;
  @override
  final String? shippingRequestId;

  @override
  String toString() {
    return 'Package(id: $id, userId: $userId, sizeX: $sizeX, sizeY: $sizeY, sizeZ: $sizeZ, weight: $weight, isFragile: $isFragile, shippingRequestId: $shippingRequestId)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PackageImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.userId, userId) || other.userId == userId) &&
            (identical(other.sizeX, sizeX) || other.sizeX == sizeX) &&
            (identical(other.sizeY, sizeY) || other.sizeY == sizeY) &&
            (identical(other.sizeZ, sizeZ) || other.sizeZ == sizeZ) &&
            (identical(other.weight, weight) || other.weight == weight) &&
            (identical(other.isFragile, isFragile) ||
                other.isFragile == isFragile) &&
            (identical(other.shippingRequestId, shippingRequestId) ||
                other.shippingRequestId == shippingRequestId));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, id, userId, sizeX, sizeY, sizeZ,
      weight, isFragile, shippingRequestId);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PackageImplCopyWith<_$PackageImpl> get copyWith =>
      __$$PackageImplCopyWithImpl<_$PackageImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$PackageImplToJson(
      this,
    );
  }
}

abstract class _Package implements Package {
  const factory _Package(
      {required final String id,
      required final String userId,
      required final int sizeX,
      required final int sizeY,
      required final int sizeZ,
      required final int weight,
      required final bool isFragile,
      final String? shippingRequestId}) = _$PackageImpl;

  factory _Package.fromJson(Map<String, dynamic> json) = _$PackageImpl.fromJson;

  @override
  String get id;
  @override
  String get userId;
  @override
  int get sizeX;
  @override
  int get sizeY;
  @override
  int get sizeZ;
  @override
  int get weight;
  @override
  bool get isFragile;
  @override
  String? get shippingRequestId;
  @override
  @JsonKey(ignore: true)
  _$$PackageImplCopyWith<_$PackageImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
