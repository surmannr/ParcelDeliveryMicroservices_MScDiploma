import 'package:parceldelivery_mobile/api/_connector.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';

// Valuták, illetve fizetési és szállítási opciók felsorolása
class InformationsApi {
  static Future<PagedResult<Currency>> getCurrencies() async {
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
}
