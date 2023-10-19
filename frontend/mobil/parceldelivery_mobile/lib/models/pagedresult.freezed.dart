// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'pagedresult.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$PagedResult<T> {
  int get totalCount => throw _privateConstructorUsedError;
  int get totalPages => throw _privateConstructorUsedError;
  int get pageNumber => throw _privateConstructorUsedError;
  int get pageSize => throw _privateConstructorUsedError;
  List<T> get data => throw _privateConstructorUsedError;

  @JsonKey(ignore: true)
  $PagedResultCopyWith<T, PagedResult<T>> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $PagedResultCopyWith<T, $Res> {
  factory $PagedResultCopyWith(
          PagedResult<T> value, $Res Function(PagedResult<T>) then) =
      _$PagedResultCopyWithImpl<T, $Res, PagedResult<T>>;
  @useResult
  $Res call(
      {int totalCount,
      int totalPages,
      int pageNumber,
      int pageSize,
      List<T> data});
}

/// @nodoc
class _$PagedResultCopyWithImpl<T, $Res, $Val extends PagedResult<T>>
    implements $PagedResultCopyWith<T, $Res> {
  _$PagedResultCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? totalCount = null,
    Object? totalPages = null,
    Object? pageNumber = null,
    Object? pageSize = null,
    Object? data = null,
  }) {
    return _then(_value.copyWith(
      totalCount: null == totalCount
          ? _value.totalCount
          : totalCount // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: null == totalPages
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
      pageNumber: null == pageNumber
          ? _value.pageNumber
          : pageNumber // ignore: cast_nullable_to_non_nullable
              as int,
      pageSize: null == pageSize
          ? _value.pageSize
          : pageSize // ignore: cast_nullable_to_non_nullable
              as int,
      data: null == data
          ? _value.data
          : data // ignore: cast_nullable_to_non_nullable
              as List<T>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$PagedResultImplCopyWith<T, $Res>
    implements $PagedResultCopyWith<T, $Res> {
  factory _$$PagedResultImplCopyWith(_$PagedResultImpl<T> value,
          $Res Function(_$PagedResultImpl<T>) then) =
      __$$PagedResultImplCopyWithImpl<T, $Res>;
  @override
  @useResult
  $Res call(
      {int totalCount,
      int totalPages,
      int pageNumber,
      int pageSize,
      List<T> data});
}

/// @nodoc
class __$$PagedResultImplCopyWithImpl<T, $Res>
    extends _$PagedResultCopyWithImpl<T, $Res, _$PagedResultImpl<T>>
    implements _$$PagedResultImplCopyWith<T, $Res> {
  __$$PagedResultImplCopyWithImpl(
      _$PagedResultImpl<T> _value, $Res Function(_$PagedResultImpl<T>) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? totalCount = null,
    Object? totalPages = null,
    Object? pageNumber = null,
    Object? pageSize = null,
    Object? data = null,
  }) {
    return _then(_$PagedResultImpl<T>(
      totalCount: null == totalCount
          ? _value.totalCount
          : totalCount // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: null == totalPages
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
      pageNumber: null == pageNumber
          ? _value.pageNumber
          : pageNumber // ignore: cast_nullable_to_non_nullable
              as int,
      pageSize: null == pageSize
          ? _value.pageSize
          : pageSize // ignore: cast_nullable_to_non_nullable
              as int,
      data: null == data
          ? _value._data
          : data // ignore: cast_nullable_to_non_nullable
              as List<T>,
    ));
  }
}

/// @nodoc

class _$PagedResultImpl<T> extends _PagedResult<T> {
  const _$PagedResultImpl(
      {required this.totalCount,
      required this.totalPages,
      required this.pageNumber,
      required this.pageSize,
      required final List<T> data})
      : _data = data,
        super._();

  @override
  final int totalCount;
  @override
  final int totalPages;
  @override
  final int pageNumber;
  @override
  final int pageSize;
  final List<T> _data;
  @override
  List<T> get data {
    if (_data is EqualUnmodifiableListView) return _data;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_data);
  }

  @override
  String toString() {
    return 'PagedResult<$T>(totalCount: $totalCount, totalPages: $totalPages, pageNumber: $pageNumber, pageSize: $pageSize, data: $data)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$PagedResultImpl<T> &&
            (identical(other.totalCount, totalCount) ||
                other.totalCount == totalCount) &&
            (identical(other.totalPages, totalPages) ||
                other.totalPages == totalPages) &&
            (identical(other.pageNumber, pageNumber) ||
                other.pageNumber == pageNumber) &&
            (identical(other.pageSize, pageSize) ||
                other.pageSize == pageSize) &&
            const DeepCollectionEquality().equals(other._data, _data));
  }

  @override
  int get hashCode => Object.hash(runtimeType, totalCount, totalPages,
      pageNumber, pageSize, const DeepCollectionEquality().hash(_data));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$PagedResultImplCopyWith<T, _$PagedResultImpl<T>> get copyWith =>
      __$$PagedResultImplCopyWithImpl<T, _$PagedResultImpl<T>>(
          this, _$identity);
}

abstract class _PagedResult<T> extends PagedResult<T> {
  const factory _PagedResult(
      {required final int totalCount,
      required final int totalPages,
      required final int pageNumber,
      required final int pageSize,
      required final List<T> data}) = _$PagedResultImpl<T>;
  const _PagedResult._() : super._();

  @override
  int get totalCount;
  @override
  int get totalPages;
  @override
  int get pageNumber;
  @override
  int get pageSize;
  @override
  List<T> get data;
  @override
  @JsonKey(ignore: true)
  _$$PagedResultImplCopyWith<T, _$PagedResultImpl<T>> get copyWith =>
      throw _privateConstructorUsedError;
}
