// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'vehicle_usage.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

VehicleUsage _$VehicleUsageFromJson(Map<String, dynamic> json) {
  return _VehicleUsage.fromJson(json);
}

/// @nodoc
mixin _$VehicleUsage {
  String get id => throw _privateConstructorUsedError;
  String get employeeId => throw _privateConstructorUsedError;
  String get employeeName => throw _privateConstructorUsedError;
  String get employeeEmail => throw _privateConstructorUsedError;
  Vehicle get vehicle => throw _privateConstructorUsedError;
  DateTime get dateFrom => throw _privateConstructorUsedError;
  DateTime get dateTo => throw _privateConstructorUsedError;
  String get note => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $VehicleUsageCopyWith<VehicleUsage> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $VehicleUsageCopyWith<$Res> {
  factory $VehicleUsageCopyWith(
          VehicleUsage value, $Res Function(VehicleUsage) then) =
      _$VehicleUsageCopyWithImpl<$Res, VehicleUsage>;
  @useResult
  $Res call(
      {String id,
      String employeeId,
      String employeeName,
      String employeeEmail,
      Vehicle vehicle,
      DateTime dateFrom,
      DateTime dateTo,
      String note});

  $VehicleCopyWith<$Res> get vehicle;
}

/// @nodoc
class _$VehicleUsageCopyWithImpl<$Res, $Val extends VehicleUsage>
    implements $VehicleUsageCopyWith<$Res> {
  _$VehicleUsageCopyWithImpl(this._value, this._then);

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
    Object? dateFrom = null,
    Object? dateTo = null,
    Object? note = null,
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
      dateFrom: null == dateFrom
          ? _value.dateFrom
          : dateFrom // ignore: cast_nullable_to_non_nullable
              as DateTime,
      dateTo: null == dateTo
          ? _value.dateTo
          : dateTo // ignore: cast_nullable_to_non_nullable
              as DateTime,
      note: null == note
          ? _value.note
          : note // ignore: cast_nullable_to_non_nullable
              as String,
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
abstract class _$$VehicleUsageImplCopyWith<$Res>
    implements $VehicleUsageCopyWith<$Res> {
  factory _$$VehicleUsageImplCopyWith(
          _$VehicleUsageImpl value, $Res Function(_$VehicleUsageImpl) then) =
      __$$VehicleUsageImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String id,
      String employeeId,
      String employeeName,
      String employeeEmail,
      Vehicle vehicle,
      DateTime dateFrom,
      DateTime dateTo,
      String note});

  @override
  $VehicleCopyWith<$Res> get vehicle;
}

/// @nodoc
class __$$VehicleUsageImplCopyWithImpl<$Res>
    extends _$VehicleUsageCopyWithImpl<$Res, _$VehicleUsageImpl>
    implements _$$VehicleUsageImplCopyWith<$Res> {
  __$$VehicleUsageImplCopyWithImpl(
      _$VehicleUsageImpl _value, $Res Function(_$VehicleUsageImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? employeeId = null,
    Object? employeeName = null,
    Object? employeeEmail = null,
    Object? vehicle = null,
    Object? dateFrom = null,
    Object? dateTo = null,
    Object? note = null,
  }) {
    return _then(_$VehicleUsageImpl(
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
      dateFrom: null == dateFrom
          ? _value.dateFrom
          : dateFrom // ignore: cast_nullable_to_non_nullable
              as DateTime,
      dateTo: null == dateTo
          ? _value.dateTo
          : dateTo // ignore: cast_nullable_to_non_nullable
              as DateTime,
      note: null == note
          ? _value.note
          : note // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$VehicleUsageImpl implements _VehicleUsage {
  const _$VehicleUsageImpl(
      {required this.id,
      required this.employeeId,
      required this.employeeName,
      required this.employeeEmail,
      required this.vehicle,
      required this.dateFrom,
      required this.dateTo,
      required this.note});

  factory _$VehicleUsageImpl.fromJson(Map<String, dynamic> json) =>
      _$$VehicleUsageImplFromJson(json);

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
  @override
  final DateTime dateFrom;
  @override
  final DateTime dateTo;
  @override
  final String note;

  @override
  String toString() {
    return 'VehicleUsage(id: $id, employeeId: $employeeId, employeeName: $employeeName, employeeEmail: $employeeEmail, vehicle: $vehicle, dateFrom: $dateFrom, dateTo: $dateTo, note: $note)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$VehicleUsageImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.employeeId, employeeId) ||
                other.employeeId == employeeId) &&
            (identical(other.employeeName, employeeName) ||
                other.employeeName == employeeName) &&
            (identical(other.employeeEmail, employeeEmail) ||
                other.employeeEmail == employeeEmail) &&
            (identical(other.vehicle, vehicle) || other.vehicle == vehicle) &&
            (identical(other.dateFrom, dateFrom) ||
                other.dateFrom == dateFrom) &&
            (identical(other.dateTo, dateTo) || other.dateTo == dateTo) &&
            (identical(other.note, note) || other.note == note));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, id, employeeId, employeeName,
      employeeEmail, vehicle, dateFrom, dateTo, note);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$VehicleUsageImplCopyWith<_$VehicleUsageImpl> get copyWith =>
      __$$VehicleUsageImplCopyWithImpl<_$VehicleUsageImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$VehicleUsageImplToJson(
      this,
    );
  }
}

abstract class _VehicleUsage implements VehicleUsage {
  const factory _VehicleUsage(
      {required final String id,
      required final String employeeId,
      required final String employeeName,
      required final String employeeEmail,
      required final Vehicle vehicle,
      required final DateTime dateFrom,
      required final DateTime dateTo,
      required final String note}) = _$VehicleUsageImpl;

  factory _VehicleUsage.fromJson(Map<String, dynamic> json) =
      _$VehicleUsageImpl.fromJson;

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
  DateTime get dateFrom;
  @override
  DateTime get dateTo;
  @override
  String get note;
  @override
  @JsonKey(ignore: true)
  _$$VehicleUsageImplCopyWith<_$VehicleUsageImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
