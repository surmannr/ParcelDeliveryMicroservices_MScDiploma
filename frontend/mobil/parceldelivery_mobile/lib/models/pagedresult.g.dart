// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pagedresult.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PagedResult<T> _$PagedResultFromJson<T>(
  Map<String, dynamic> json,
  T Function(Object? json) fromJsonT,
) =>
    PagedResult<T>(
      totalCount: json['totalCount'] as int,
      totalPages: json['totalPages'] as int,
      pageNumber: json['pageNumber'] as int,
      pageSize: json['pageSize'] as int,
      data: (json['data'] as List<dynamic>).map(fromJsonT).toList(),
    );

Map<String, dynamic> _$PagedResultToJson<T>(
  PagedResult<T> instance,
  Object? Function(T value) toJsonT,
) =>
    <String, dynamic>{
      'totalCount': instance.totalCount,
      'totalPages': instance.totalPages,
      'pageNumber': instance.pageNumber,
      'pageSize': instance.pageSize,
      'data': instance.data.map(toJsonT).toList(),
    };
