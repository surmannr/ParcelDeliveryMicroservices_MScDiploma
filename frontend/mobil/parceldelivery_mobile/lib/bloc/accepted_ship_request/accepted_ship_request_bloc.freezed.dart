// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'accepted_ship_request_bloc.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

/// @nodoc
mixin _$AcceptedShipRequestEvent {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getAll,
    required TResult Function(AcceptedShipRequest entity) update,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getAll,
    TResult? Function(AcceptedShipRequest entity)? update,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getAll,
    TResult Function(AcceptedShipRequest entity)? update,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetAll value) getAll,
    required TResult Function(_Update value) update,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetAll value)? getAll,
    TResult? Function(_Update value)? update,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetAll value)? getAll,
    TResult Function(_Update value)? update,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AcceptedShipRequestEventCopyWith<$Res> {
  factory $AcceptedShipRequestEventCopyWith(AcceptedShipRequestEvent value,
          $Res Function(AcceptedShipRequestEvent) then) =
      _$AcceptedShipRequestEventCopyWithImpl<$Res, AcceptedShipRequestEvent>;
}

/// @nodoc
class _$AcceptedShipRequestEventCopyWithImpl<$Res,
        $Val extends AcceptedShipRequestEvent>
    implements $AcceptedShipRequestEventCopyWith<$Res> {
  _$AcceptedShipRequestEventCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$GetAllImplCopyWith<$Res> {
  factory _$$GetAllImplCopyWith(
          _$GetAllImpl value, $Res Function(_$GetAllImpl) then) =
      __$$GetAllImplCopyWithImpl<$Res>;
}

/// @nodoc
class __$$GetAllImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestEventCopyWithImpl<$Res, _$GetAllImpl>
    implements _$$GetAllImplCopyWith<$Res> {
  __$$GetAllImplCopyWithImpl(
      _$GetAllImpl _value, $Res Function(_$GetAllImpl) _then)
      : super(_value, _then);
}

/// @nodoc

class _$GetAllImpl implements _GetAll {
  const _$GetAllImpl();

  @override
  String toString() {
    return 'AcceptedShipRequestEvent.getAll()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$GetAllImpl);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getAll,
    required TResult Function(AcceptedShipRequest entity) update,
  }) {
    return getAll();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getAll,
    TResult? Function(AcceptedShipRequest entity)? update,
  }) {
    return getAll?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getAll,
    TResult Function(AcceptedShipRequest entity)? update,
    required TResult orElse(),
  }) {
    if (getAll != null) {
      return getAll();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetAll value) getAll,
    required TResult Function(_Update value) update,
  }) {
    return getAll(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetAll value)? getAll,
    TResult? Function(_Update value)? update,
  }) {
    return getAll?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetAll value)? getAll,
    TResult Function(_Update value)? update,
    required TResult orElse(),
  }) {
    if (getAll != null) {
      return getAll(this);
    }
    return orElse();
  }
}

abstract class _GetAll implements AcceptedShipRequestEvent {
  const factory _GetAll() = _$GetAllImpl;
}

/// @nodoc
abstract class _$$UpdateImplCopyWith<$Res> {
  factory _$$UpdateImplCopyWith(
          _$UpdateImpl value, $Res Function(_$UpdateImpl) then) =
      __$$UpdateImplCopyWithImpl<$Res>;
  @useResult
  $Res call({AcceptedShipRequest entity});

  $AcceptedShipRequestCopyWith<$Res> get entity;
}

/// @nodoc
class __$$UpdateImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestEventCopyWithImpl<$Res, _$UpdateImpl>
    implements _$$UpdateImplCopyWith<$Res> {
  __$$UpdateImplCopyWithImpl(
      _$UpdateImpl _value, $Res Function(_$UpdateImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? entity = null,
  }) {
    return _then(_$UpdateImpl(
      null == entity
          ? _value.entity
          : entity // ignore: cast_nullable_to_non_nullable
              as AcceptedShipRequest,
    ));
  }

  @override
  @pragma('vm:prefer-inline')
  $AcceptedShipRequestCopyWith<$Res> get entity {
    return $AcceptedShipRequestCopyWith<$Res>(_value.entity, (value) {
      return _then(_value.copyWith(entity: value));
    });
  }
}

/// @nodoc

class _$UpdateImpl implements _Update {
  const _$UpdateImpl(this.entity);

  @override
  final AcceptedShipRequest entity;

  @override
  String toString() {
    return 'AcceptedShipRequestEvent.update(entity: $entity)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UpdateImpl &&
            (identical(other.entity, entity) || other.entity == entity));
  }

  @override
  int get hashCode => Object.hash(runtimeType, entity);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UpdateImplCopyWith<_$UpdateImpl> get copyWith =>
      __$$UpdateImplCopyWithImpl<_$UpdateImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getAll,
    required TResult Function(AcceptedShipRequest entity) update,
  }) {
    return update(entity);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getAll,
    TResult? Function(AcceptedShipRequest entity)? update,
  }) {
    return update?.call(entity);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getAll,
    TResult Function(AcceptedShipRequest entity)? update,
    required TResult orElse(),
  }) {
    if (update != null) {
      return update(entity);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetAll value) getAll,
    required TResult Function(_Update value) update,
  }) {
    return update(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetAll value)? getAll,
    TResult? Function(_Update value)? update,
  }) {
    return update?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetAll value)? getAll,
    TResult Function(_Update value)? update,
    required TResult orElse(),
  }) {
    if (update != null) {
      return update(this);
    }
    return orElse();
  }
}

abstract class _Update implements AcceptedShipRequestEvent {
  const factory _Update(final AcceptedShipRequest entity) = _$UpdateImpl;

  AcceptedShipRequest get entity;
  @JsonKey(ignore: true)
  _$$UpdateImplCopyWith<_$UpdateImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

AcceptedShipRequestState _$AcceptedShipRequestStateFromJson(
    Map<String, dynamic> json) {
  switch (json['runtimeType']) {
    case 'loading':
      return _Loading.fromJson(json);
    case 'loaded':
      return _Loaded.fromJson(json);
    case 'modified':
      return _Modified.fromJson(json);
    case 'error':
      return _Error.fromJson(json);

    default:
      throw CheckedFromJsonException(
          json,
          'runtimeType',
          'AcceptedShipRequestState',
          'Invalid union type "${json['runtimeType']}"!');
  }
}

/// @nodoc
mixin _$AcceptedShipRequestState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(PagedResult<AcceptedShipRequest> list) loaded,
    required TResult Function(bool result) modified,
    required TResult Function(String message) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult? Function(bool result)? modified,
    TResult? Function(String message)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult Function(bool result)? modified,
    TResult Function(String message)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Loading value) loading,
    required TResult Function(_Loaded value) loaded,
    required TResult Function(_Modified value) modified,
    required TResult Function(_Error value) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Loading value)? loading,
    TResult? Function(_Loaded value)? loaded,
    TResult? Function(_Modified value)? modified,
    TResult? Function(_Error value)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Loading value)? loading,
    TResult Function(_Loaded value)? loaded,
    TResult Function(_Modified value)? modified,
    TResult Function(_Error value)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AcceptedShipRequestStateCopyWith<$Res> {
  factory $AcceptedShipRequestStateCopyWith(AcceptedShipRequestState value,
          $Res Function(AcceptedShipRequestState) then) =
      _$AcceptedShipRequestStateCopyWithImpl<$Res, AcceptedShipRequestState>;
}

/// @nodoc
class _$AcceptedShipRequestStateCopyWithImpl<$Res,
        $Val extends AcceptedShipRequestState>
    implements $AcceptedShipRequestStateCopyWith<$Res> {
  _$AcceptedShipRequestStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$LoadingImplCopyWith<$Res> {
  factory _$$LoadingImplCopyWith(
          _$LoadingImpl value, $Res Function(_$LoadingImpl) then) =
      __$$LoadingImplCopyWithImpl<$Res>;
}

/// @nodoc
class __$$LoadingImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestStateCopyWithImpl<$Res, _$LoadingImpl>
    implements _$$LoadingImplCopyWith<$Res> {
  __$$LoadingImplCopyWithImpl(
      _$LoadingImpl _value, $Res Function(_$LoadingImpl) _then)
      : super(_value, _then);
}

/// @nodoc
@JsonSerializable()
class _$LoadingImpl implements _Loading {
  const _$LoadingImpl({final String? $type}) : $type = $type ?? 'loading';

  factory _$LoadingImpl.fromJson(Map<String, dynamic> json) =>
      _$$LoadingImplFromJson(json);

  @JsonKey(name: 'runtimeType')
  final String $type;

  @override
  String toString() {
    return 'AcceptedShipRequestState.loading()';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType && other is _$LoadingImpl);
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(PagedResult<AcceptedShipRequest> list) loaded,
    required TResult Function(bool result) modified,
    required TResult Function(String message) error,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult? Function(bool result)? modified,
    TResult? Function(String message)? error,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult Function(bool result)? modified,
    TResult Function(String message)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Loading value) loading,
    required TResult Function(_Loaded value) loaded,
    required TResult Function(_Modified value) modified,
    required TResult Function(_Error value) error,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Loading value)? loading,
    TResult? Function(_Loaded value)? loaded,
    TResult? Function(_Modified value)? modified,
    TResult? Function(_Error value)? error,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Loading value)? loading,
    TResult Function(_Loaded value)? loaded,
    TResult Function(_Modified value)? modified,
    TResult Function(_Error value)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }

  @override
  Map<String, dynamic> toJson() {
    return _$$LoadingImplToJson(
      this,
    );
  }
}

abstract class _Loading implements AcceptedShipRequestState {
  const factory _Loading() = _$LoadingImpl;

  factory _Loading.fromJson(Map<String, dynamic> json) = _$LoadingImpl.fromJson;
}

/// @nodoc
abstract class _$$LoadedImplCopyWith<$Res> {
  factory _$$LoadedImplCopyWith(
          _$LoadedImpl value, $Res Function(_$LoadedImpl) then) =
      __$$LoadedImplCopyWithImpl<$Res>;
  @useResult
  $Res call({PagedResult<AcceptedShipRequest> list});

  $PagedResultCopyWith<AcceptedShipRequest, $Res> get list;
}

/// @nodoc
class __$$LoadedImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestStateCopyWithImpl<$Res, _$LoadedImpl>
    implements _$$LoadedImplCopyWith<$Res> {
  __$$LoadedImplCopyWithImpl(
      _$LoadedImpl _value, $Res Function(_$LoadedImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? list = null,
  }) {
    return _then(_$LoadedImpl(
      null == list
          ? _value.list
          : list // ignore: cast_nullable_to_non_nullable
              as PagedResult<AcceptedShipRequest>,
    ));
  }

  @override
  @pragma('vm:prefer-inline')
  $PagedResultCopyWith<AcceptedShipRequest, $Res> get list {
    return $PagedResultCopyWith<AcceptedShipRequest, $Res>(_value.list,
        (value) {
      return _then(_value.copyWith(list: value));
    });
  }
}

/// @nodoc
@JsonSerializable()
class _$LoadedImpl implements _Loaded {
  const _$LoadedImpl(this.list, {final String? $type})
      : $type = $type ?? 'loaded';

  factory _$LoadedImpl.fromJson(Map<String, dynamic> json) =>
      _$$LoadedImplFromJson(json);

  @override
  final PagedResult<AcceptedShipRequest> list;

  @JsonKey(name: 'runtimeType')
  final String $type;

  @override
  String toString() {
    return 'AcceptedShipRequestState.loaded(list: $list)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$LoadedImpl &&
            (identical(other.list, list) || other.list == list));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, list);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$LoadedImplCopyWith<_$LoadedImpl> get copyWith =>
      __$$LoadedImplCopyWithImpl<_$LoadedImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(PagedResult<AcceptedShipRequest> list) loaded,
    required TResult Function(bool result) modified,
    required TResult Function(String message) error,
  }) {
    return loaded(list);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult? Function(bool result)? modified,
    TResult? Function(String message)? error,
  }) {
    return loaded?.call(list);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult Function(bool result)? modified,
    TResult Function(String message)? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(list);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Loading value) loading,
    required TResult Function(_Loaded value) loaded,
    required TResult Function(_Modified value) modified,
    required TResult Function(_Error value) error,
  }) {
    return loaded(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Loading value)? loading,
    TResult? Function(_Loaded value)? loaded,
    TResult? Function(_Modified value)? modified,
    TResult? Function(_Error value)? error,
  }) {
    return loaded?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Loading value)? loading,
    TResult Function(_Loaded value)? loaded,
    TResult Function(_Modified value)? modified,
    TResult Function(_Error value)? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(this);
    }
    return orElse();
  }

  @override
  Map<String, dynamic> toJson() {
    return _$$LoadedImplToJson(
      this,
    );
  }
}

abstract class _Loaded implements AcceptedShipRequestState {
  const factory _Loaded(final PagedResult<AcceptedShipRequest> list) =
      _$LoadedImpl;

  factory _Loaded.fromJson(Map<String, dynamic> json) = _$LoadedImpl.fromJson;

  PagedResult<AcceptedShipRequest> get list;
  @JsonKey(ignore: true)
  _$$LoadedImplCopyWith<_$LoadedImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$ModifiedImplCopyWith<$Res> {
  factory _$$ModifiedImplCopyWith(
          _$ModifiedImpl value, $Res Function(_$ModifiedImpl) then) =
      __$$ModifiedImplCopyWithImpl<$Res>;
  @useResult
  $Res call({bool result});
}

/// @nodoc
class __$$ModifiedImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestStateCopyWithImpl<$Res, _$ModifiedImpl>
    implements _$$ModifiedImplCopyWith<$Res> {
  __$$ModifiedImplCopyWithImpl(
      _$ModifiedImpl _value, $Res Function(_$ModifiedImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? result = null,
  }) {
    return _then(_$ModifiedImpl(
      null == result
          ? _value.result
          : result // ignore: cast_nullable_to_non_nullable
              as bool,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$ModifiedImpl implements _Modified {
  const _$ModifiedImpl(this.result, {final String? $type})
      : $type = $type ?? 'modified';

  factory _$ModifiedImpl.fromJson(Map<String, dynamic> json) =>
      _$$ModifiedImplFromJson(json);

  @override
  final bool result;

  @JsonKey(name: 'runtimeType')
  final String $type;

  @override
  String toString() {
    return 'AcceptedShipRequestState.modified(result: $result)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ModifiedImpl &&
            (identical(other.result, result) || other.result == result));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, result);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ModifiedImplCopyWith<_$ModifiedImpl> get copyWith =>
      __$$ModifiedImplCopyWithImpl<_$ModifiedImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(PagedResult<AcceptedShipRequest> list) loaded,
    required TResult Function(bool result) modified,
    required TResult Function(String message) error,
  }) {
    return modified(result);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult? Function(bool result)? modified,
    TResult? Function(String message)? error,
  }) {
    return modified?.call(result);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult Function(bool result)? modified,
    TResult Function(String message)? error,
    required TResult orElse(),
  }) {
    if (modified != null) {
      return modified(result);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Loading value) loading,
    required TResult Function(_Loaded value) loaded,
    required TResult Function(_Modified value) modified,
    required TResult Function(_Error value) error,
  }) {
    return modified(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Loading value)? loading,
    TResult? Function(_Loaded value)? loaded,
    TResult? Function(_Modified value)? modified,
    TResult? Function(_Error value)? error,
  }) {
    return modified?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Loading value)? loading,
    TResult Function(_Loaded value)? loaded,
    TResult Function(_Modified value)? modified,
    TResult Function(_Error value)? error,
    required TResult orElse(),
  }) {
    if (modified != null) {
      return modified(this);
    }
    return orElse();
  }

  @override
  Map<String, dynamic> toJson() {
    return _$$ModifiedImplToJson(
      this,
    );
  }
}

abstract class _Modified implements AcceptedShipRequestState {
  const factory _Modified(final bool result) = _$ModifiedImpl;

  factory _Modified.fromJson(Map<String, dynamic> json) =
      _$ModifiedImpl.fromJson;

  bool get result;
  @JsonKey(ignore: true)
  _$$ModifiedImplCopyWith<_$ModifiedImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$ErrorImplCopyWith<$Res> {
  factory _$$ErrorImplCopyWith(
          _$ErrorImpl value, $Res Function(_$ErrorImpl) then) =
      __$$ErrorImplCopyWithImpl<$Res>;
  @useResult
  $Res call({String message});
}

/// @nodoc
class __$$ErrorImplCopyWithImpl<$Res>
    extends _$AcceptedShipRequestStateCopyWithImpl<$Res, _$ErrorImpl>
    implements _$$ErrorImplCopyWith<$Res> {
  __$$ErrorImplCopyWithImpl(
      _$ErrorImpl _value, $Res Function(_$ErrorImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? message = null,
  }) {
    return _then(_$ErrorImpl(
      null == message
          ? _value.message
          : message // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$ErrorImpl implements _Error {
  const _$ErrorImpl(this.message, {final String? $type})
      : $type = $type ?? 'error';

  factory _$ErrorImpl.fromJson(Map<String, dynamic> json) =>
      _$$ErrorImplFromJson(json);

  @override
  final String message;

  @JsonKey(name: 'runtimeType')
  final String $type;

  @override
  String toString() {
    return 'AcceptedShipRequestState.error(message: $message)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ErrorImpl &&
            (identical(other.message, message) || other.message == message));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, message);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$ErrorImplCopyWith<_$ErrorImpl> get copyWith =>
      __$$ErrorImplCopyWithImpl<_$ErrorImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(PagedResult<AcceptedShipRequest> list) loaded,
    required TResult Function(bool result) modified,
    required TResult Function(String message) error,
  }) {
    return error(message);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult? Function(bool result)? modified,
    TResult? Function(String message)? error,
  }) {
    return error?.call(message);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(PagedResult<AcceptedShipRequest> list)? loaded,
    TResult Function(bool result)? modified,
    TResult Function(String message)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(message);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_Loading value) loading,
    required TResult Function(_Loaded value) loaded,
    required TResult Function(_Modified value) modified,
    required TResult Function(_Error value) error,
  }) {
    return error(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_Loading value)? loading,
    TResult? Function(_Loaded value)? loaded,
    TResult? Function(_Modified value)? modified,
    TResult? Function(_Error value)? error,
  }) {
    return error?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_Loading value)? loading,
    TResult Function(_Loaded value)? loaded,
    TResult Function(_Modified value)? modified,
    TResult Function(_Error value)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(this);
    }
    return orElse();
  }

  @override
  Map<String, dynamic> toJson() {
    return _$$ErrorImplToJson(
      this,
    );
  }
}

abstract class _Error implements AcceptedShipRequestState {
  const factory _Error(final String message) = _$ErrorImpl;

  factory _Error.fromJson(Map<String, dynamic> json) = _$ErrorImpl.fromJson;

  String get message;
  @JsonKey(ignore: true)
  _$$ErrorImplCopyWith<_$ErrorImpl> get copyWith =>
      throw _privateConstructorUsedError;
}
