import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

class ShippingOptionsApi {
  static Future<PagedResult<ShippingOption>> get() async {
    final dio = await Connector.createDio();
    final response = await dio.get("/ShippingOption");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => ShippingOption.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> add(ShippingOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.post("/ShippingOption", data: entity);

    if (response.statusCode == 201) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(ShippingOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.put("/ShippingOption", data: entity);

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> delete(ShippingOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.delete("/ShippingOption/${entity.id}");

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
