import 'package:freezed_annotation/freezed_annotation.dart';

part 'package.freezed.dart';
part 'package.g.dart';

@freezed
class Package with _$Package {
  const factory Package({
    required String id,
    required String userId,
    required int sizeX,
    required int sizeY,
    required int sizeZ,
    required int weight,
    required bool isFragile,
    required String shippingRequestId,
  }) = _Package;

  factory Package.fromJson(Map<String, Object?> json) =>
      _$PackageFromJson(json);
}
