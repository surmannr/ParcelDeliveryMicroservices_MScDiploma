// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'accepted_ship_request.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

AcceptedShipRequest _$AcceptedShipRequestFromJson(Map<String, dynamic> json) {
  return _AcceptedShipRequest.fromJson(json);
}

/// @nodoc
mixin _$AcceptedShipRequest {
  String get id => throw _privateConstructorUsedError;
  String get employeeId => throw _privateConstructorUsedError;
  String get employeeName => throw _privateConstructorUsedError;
  String get employeeEmail => throw _privateConstructorUsedError;
  Vehicle get vehicle => throw _privateConstructorUsedError;
  List<Package> get packages => throw _privateConstructorUsedError;
  List<ShippingRequest> get shippingRequests =>
      throw _privateConstructorUsedError;
  bool get isAllPackageTaken => throw _privateConstructorUsedError;
  bool get isAssignedToEmployee => throw _privateConstructorUsedError;
  List<String> get readPackageIds => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $AcceptedShipRequestCopyWith<AcceptedShipRequest> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AcceptedShipRequestCopyWith<$Res> {
  factory $AcceptedShipRequestCopyWith(
          AcceptedShipRequest value, $Res Function(AcceptedShipRequest) then) =
      _$AcceptedShipRequestCopyWithImpl<$Res, AcceptedShipRequest>;
  @useResult
  $Res call(
      {String id,
      String employeeId,
      String employeeName,
      String employeeEmail,
      Vehicle vehicle,
      List<Package> packages,
      List<ShippingRequest> shippingRequests,
      bool isAllPackageTaken,
      bool isAssignedToEmployee,
      List<String> readPackageIds});

  $VehicleCopyWith<$Res> get vehicle;
}

/// @nodoc
class _$AcceptedShipRequestCopyWithImpl<$Res, $Val extends AcceptedShipRequest>
    implements $AcceptedShipRequestCopyWith<$Res> {
  _$AcceptedShipRequestCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? employeeId = null,
    Object? employeeName = null,
    Object? employeeEmail = null,
    Object? vehicle = null,
    Object? packages = null,
    Object? shippingRequests = null,
    Object? isAllPackageTaken = null,
    Object? isAssignedToEmployee = null,
    Object? readPackageIds = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      employeeId: null == employeeId
          ? _value.employeeId
          : employeeId // ignore: cast_nullable_to_non_nullable
              as String,
      employeeName: null == employeeName
          ? _value.employeeName
          : employeeName // ignore: cast_nullable_to_non_nullable
              as String,
      employeeEmail: null == employeeEmail
          ? _value.employeeEmail
          : employeeEmail // ignore: cast_nullable_to_non_nullable
              as String,
      vehicle: null == vehicle
          ? _value.vehicle
          : vehicle // ignore: cast_nullable_to_non_nullable
              as Vehicle,
      packages: null == packages
          ? _value.packages
          : packages // ignore: cast_nullable_to_non_nullable
              as List<Package>,
      shippingRequests: null == shippingRequests
          ? _value.shippingRequests
          : shippingRequests // ignore: cast_nullable_to_non_nullable
              as List<ShippingRequest>,
      isAllPackageTaken: null == isAllPackageTaken
          ? _value.isAllPackageTaken
          : isAllPackageTaken // ignore: cast_nullable_to_non_nullable
              as bool,
      isAssignedToEmployee: null == isAssignedToEmployee
          ? _value.isAssignedToEmployee
          : isAssignedToEmployee // ignore: cast_nullable_to_non_nullable
              as bool,
      readPackageIds: null == readPackageIds
          ? _value.readPackageIds
          : readPackageIds // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ) as $Val);
  }

  @override
  @pragma('vm:prefer-inline')
  $VehicleCopyWith<$Res> get vehicle {
    return $VehicleCopyWith<$Res>(_value.vehicle, (value) {
      return _then(_value.copyWith(vehicle: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$AcceptedShipRequestImplCopyWith<$Res>
    implements $AcceptedShipRequestCopyWith<$Res> {
  factory _$$AcceptedShipRequestImplCopyWith(_$AcceptedShipRequestImpl value,
          $Res Function(_$AcceptedShipRequestImpl) then) =
      __$$AcceptedShipRequestImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String id,
      String employeeId,
      String employeeName,
      String employeeEmail,
      Vehicle vehicle,
      List<Package> packages,
      List<ShippingRequest> shippingRequests,
      bool isAllPackageTaken,
      bool isAssignedToEmployee,
      List<String> readPackageIds});

  @override
  $VehicleCopyWith<$Res> get vehicle;
}

/// @nodoc
class __$$AcceptedShipRequestImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestCopyWithImpl<$Res, _$AcceptedShipRequestImpl>
    implements _$$AcceptedShipRequestImplCopyWith<$Res> {
  __$$AcceptedShipRequestImplCopyWithImpl(_$AcceptedShipRequestImpl _value,
      $Res Function(_$AcceptedShipRequestImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? employeeId = null,
    Object? employeeName = null,
    Object? employeeEmail = null,
    Object? vehicle = null,
    Object? packages = null,
    Object? shippingRequests = null,
    Object? isAllPackageTaken = null,
    Object? isAssignedToEmployee = null,
    Object? readPackageIds = null,
  }) {
    return _then(_$AcceptedShipRequestImpl(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      employeeId: null == employeeId
          ? _value.employeeId
          : employeeId // ignore: cast_nullable_to_non_nullable
              as String,
      employeeName: null == employeeName
          ? _value.employeeName
          : employeeName // ignore: cast_nullable_to_non_nullable
              as String,
      employeeEmail: null == employeeEmail
          ? _value.employeeEmail
          : employeeEmail // ignore: cast_nullable_to_non_nullable
              as String,
      vehicle: null == vehicle
          ? _value.vehicle
          : vehicle // ignore: cast_nullable_to_non_nullable
              as Vehicle,
      packages: null == packages
          ? _value._packages
          : packages // ignore: cast_nullable_to_non_nullable
              as List<Package>,
      shippingRequests: null == shippingRequests
          ? _value._shippingRequests
          : shippingRequests // ignore: cast_nullable_to_non_nullable
              as List<ShippingRequest>,
      isAllPackageTaken: null == isAllPackageTaken
          ? _value.isAllPackageTaken
          : isAllPackageTaken // ignore: cast_nullable_to_non_nullable
              as bool,
      isAssignedToEmployee: null == isAssignedToEmployee
          ? _value.isAssignedToEmployee
          : isAssignedToEmployee // ignore: cast_nullable_to_non_nullable
              as bool,
      readPackageIds: null == readPackageIds
          ? _value._readPackageIds
          : readPackageIds // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$AcceptedShipRequestImpl implements _AcceptedShipRequest {
  const _$AcceptedShipRequestImpl(
      {required this.id,
      required this.employeeId,
      required this.employeeName,
      required this.employeeEmail,
      required this.vehicle,
      required final List<Package> packages,
      required final List<ShippingRequest> shippingRequests,
      required this.isAllPackageTaken,
      required this.isAssignedToEmployee,
      required final List<String> readPackageIds})
      : _packages = packages,
        _shippingRequests = shippingRequests,
        _readPackageIds = readPackageIds;

  factory _$AcceptedShipRequestImpl.fromJson(Map<String, dynamic> json) =>
      _$$AcceptedShipRequestImplFromJson(json);

  @override
  final String id;
  @override
  final String employeeId;
  @override
  final String employeeName;
  @override
  final String employeeEmail;
  @override
  final Vehicle vehicle;
  final List<Package> _packages;
  @override
  List<Package> get packages {
    if (_packages is EqualUnmodifiableListView) return _packages;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_packages);
  }

  final List<ShippingRequest> _shippingRequests;
  @override
  List<ShippingRequest> get shippingRequests {
    if (_shippingRequests is EqualUnmodifiableListView)
      return _shippingRequests;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_shippingRequests);
  }

  @override
  final bool isAllPackageTaken;
  @override
  final bool isAssignedToEmployee;
  final List<String> _readPackageIds;
  @override
  List<String> get readPackageIds {
    if (_readPackageIds is EqualUnmodifiableListView) return _readPackageIds;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_readPackageIds);
  }

  @override
  String toString() {
    return 'AcceptedShipRequest(id: $id, employeeId: $employeeId, employeeName: $employeeName, employeeEmail: $employeeEmail, vehicle: $vehicle, packages: $packages, shippingRequests: $shippingRequests, isAllPackageTaken: $isAllPackageTaken, isAssignedToEmployee: $isAssignedToEmployee, readPackageIds: $readPackageIds)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$AcceptedShipRequestImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.employeeId, employeeId) ||
                other.employeeId == employeeId) &&
            (identical(other.employeeName, employeeName) ||
                other.employeeName == employeeName) &&
            (identical(other.employeeEmail, employeeEmail) ||
                other.employeeEmail == employeeEmail) &&
            (identical(other.vehicle, vehicle) || other.vehicle == vehicle) &&
            const DeepCollectionEquality().equals(other._packages, _packages) &&
            const DeepCollectionEquality()
                .equals(other._shippingRequests, _shippingRequests) &&
            (identical(other.isAllPackageTaken, isAllPackageTaken) ||
                other.isAllPackageTaken == isAllPackageTaken) &&
            (identical(other.isAssignedToEmployee, isAssignedToEmployee) ||
                other.isAssignedToEmployee == isAssignedToEmployee) &&
            const DeepCollectionEquality()
                .equals(other._readPackageIds, _readPackageIds));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      id,
      employeeId,
      employeeName,
      employeeEmail,
      vehicle,
      const DeepCollectionEquality().hash(_packages),
      const DeepCollectionEquality().hash(_shippingRequests),
      isAllPackageTaken,
      isAssignedToEmployee,
      const DeepCollectionEquality().hash(_readPackageIds));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$AcceptedShipRequestImplCopyWith<_$AcceptedShipRequestImpl> get copyWith =>
      __$$AcceptedShipRequestImplCopyWithImpl<_$AcceptedShipRequestImpl>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$AcceptedShipRequestImplToJson(
      this,
    );
  }
}

abstract class _AcceptedShipRequest implements AcceptedShipRequest {
  const factory _AcceptedShipRequest(
      {required final String id,
      required final String employeeId,
      required final String employeeName,
      required final String employeeEmail,
      required final Vehicle vehicle,
      required final List<Package> packages,
      required final List<ShippingRequest> shippingRequests,
      required final bool isAllPackageTaken,
      required final bool isAssignedToEmployee,
      required final List<String> readPackageIds}) = _$AcceptedShipRequestImpl;

  factory _AcceptedShipRequest.fromJson(Map<String, dynamic> json) =
      _$AcceptedShipRequestImpl.fromJson;

  @override
  String get id;
  @override
  String get employeeId;
  @override
  String get employeeName;
  @override
  String get employeeEmail;
  @override
  Vehicle get vehicle;
  @override
  List<Package> get packages;
  @override
  List<ShippingRequest> get shippingRequests;
  @override
  bool get isAllPackageTaken;
  @override
  bool get isAssignedToEmployee;
  @override
  List<String> get readPackageIds;
  @override
  @JsonKey(ignore: true)
  _$$AcceptedShipRequestImplCopyWith<_$AcceptedShipRequestImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
