import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/shipping_request.dart';

class ShippingRequestsApi {
  static Future<PagedResult<ShippingRequest>> getByUserId(String id) async {
    final dio = await Connector.createDio();
    final response = await dio.get("/ShippingRequest/$id");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => ShippingRequest.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> add(ShippingRequest entity) async {
    final dio = await Connector.createDio();
    final response = await dio.post("/ShippingRequest", data: entity);

    if (response.statusCode == 201) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(ShippingRequest entity) async {
    final dio = await Connector.createDio();
    final response = await dio.put("/ShippingRequest", data: entity);

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<ShippingRequest> track(String id) async {
    final dio = await Connector.createDio();
    final response = await dio.get("/PackageTracking/$id");

    var data = ShippingRequest.fromJson(response.data);

    if (response.statusCode == 200) {
      return data;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
