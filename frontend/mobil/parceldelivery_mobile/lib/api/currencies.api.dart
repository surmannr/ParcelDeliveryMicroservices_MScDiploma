import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';

// Valuták, illetve fizetési és szállítási opciók felsorolása
class CurrenciesApi {
  static Future<PagedResult<Currency>> get() async {
    final dio = await Connector.createDio();
    final response = await dio.get("/Currency");

    var pagedData = PagedResult.fromJson(response.data,
        (json) => Currency.fromJson(json as Map<String, dynamic>));

    if (response.statusCode == 200) {
      return pagedData;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> add(Currency entity) async {
    final dio = await Connector.createDio();
    final response = await dio.post("/Currency", data: entity);

    if (response.statusCode == 201) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> update(Currency entity) async {
    final dio = await Connector.createDio();
    final response = await dio.put("/Currency", data: entity);

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }

  static Future<bool> delete(Currency entity) async {
    final dio = await Connector.createDio();
    final response = await dio.delete("/Currency/${entity.id}");

    if (response.statusCode == 200) {
      return true;
    } else {
      throw Exception(response.statusMessage);
    }
  }
}
