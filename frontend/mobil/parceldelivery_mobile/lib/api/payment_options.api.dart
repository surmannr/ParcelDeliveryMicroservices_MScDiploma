import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';

class PaymentOptionsApi {
  static Future<PagedResult<PaymentOption>> get() async {
    final dio = await Connector.createDio();
    final response = await dio.get("/PaymentOption");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => PaymentOption.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> add(PaymentOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.post("/PaymentOption", data: entity);

    if (response.statusCode == 201) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(PaymentOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.put("/PaymentOption", data: entity);

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> delete(PaymentOption entity) async {
    final dio = await Connector.createDio();
    final response = await dio.delete("/PaymentOption/${entity.id}");

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
