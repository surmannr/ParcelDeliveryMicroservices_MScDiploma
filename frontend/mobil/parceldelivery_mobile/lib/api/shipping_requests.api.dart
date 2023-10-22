import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/add_new_billing.dart';
import 'package:parceldelivery_mobile/models/add_new_shipping_request.dart';
import 'package:parceldelivery_mobile/models/billing.dart';
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

  static Future<bool> add(
      AddNewShippingRequest entity, AddNewBilling billing) async {
    final dio = await Connector.createDio();
    final billingResponse = await dio.post("/Billing", data: billing);

    print(billingResponse.data);
    var newBilling = Billing.fromJson(billingResponse.data);
    print("newBilling");
    print(newBilling);
    var shipReqWithBilling = entity.copyWith(billingId: newBilling.id);
    print(shipReqWithBilling);
    final response =
        await dio.post("/ShippingRequest", data: shipReqWithBilling);

    if (response.statusCode == 201) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(AddNewShippingRequest entity) async {
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
