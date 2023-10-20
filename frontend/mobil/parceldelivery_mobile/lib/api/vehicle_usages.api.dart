import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/vehicle_usage.dart';

class VehicleUsagesApi {
  static Future<PagedResult<VehicleUsage>> getByEmployeeId(String id) async {
    final dio = await Connector.createDio();
    final response = await dio.get("/VehicleUsage/employee/$id");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => VehicleUsage.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
