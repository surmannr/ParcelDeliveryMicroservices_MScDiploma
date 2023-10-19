import 'package:freezed_annotation/freezed_annotation.dart';

part 'pagedresult.freezed.dart';
part 'pagedresult.g.dart';

@freezed
@JsonSerializable(genericArgumentFactories: true)
class PagedResult<T> with _$PagedResult<T> {
  const PagedResult._();

  const factory PagedResult({
    required int totalCount,
    required int totalPages,
    required int pageNumber,
    required int pageSize,
    required List<T> data,
  }) = _PagedResult<T>;

  factory PagedResult.fromJson(
      Map<String, dynamic> json, T Function(Object? json) fromJsonT) {
    return _$PagedResultFromJson<T>(json, fromJsonT);
  }

  Map<String, dynamic> toJson(Object Function(T value) toJsonT) {
    return _$PagedResultToJson<T>(this, toJsonT);
  }
}
