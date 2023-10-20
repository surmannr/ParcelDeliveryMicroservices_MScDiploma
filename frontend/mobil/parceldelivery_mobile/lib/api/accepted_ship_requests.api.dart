import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/accepted_ship_request.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';

class AcceptedShipRequestsApi {
  static Future<PagedResult<AcceptedShipRequest>> getByEmployeeId(
      String id) async {
    final dio = await Connector.createDio();
    final response = await dio.get("/AcceptedShipRequest/employee/$id");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => AcceptedShipRequest.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(AcceptedShipRequest entity) async {
    final dio = await Connector.createDio();
    final response = await dio.put("/AcceptedShipRequest", data: entity);

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
