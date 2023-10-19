import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/config.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:shared_preferences/shared_preferences.dart';

class Connector {
  static String tag = "API call :";

  static Future<Dio> createDio() async {
    final config = await Config.forEnvironment();
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    final accessToken = prefs.getString('access_token');

    var customBaseOptions = BaseOptions(
      contentType: 'application/json',
      baseUrl: config.protocol + config.baseUrl,
      headers: {
        'Authorization': 'Bearer $accessToken',
        'Accept': 'application/json',
      },
    );

    var logInterceptor = InterceptorsWrapper(
      onRequest: (options, handler) {
        debugPrint("$tag ${options.toString()}", wrapWidth: 1024);
        return handler.next(options);
      },
      onResponse: (response, handler) {
        debugPrint("$tag ${response.toString()}", wrapWidth: 1024);
        return handler.next(response);
      },
      onError: (exception, handler) {
        debugPrint("$tag ${exception.toString()}", wrapWidth: 1024);
        return handler.next(exception);
      },
    );

    return Dio(customBaseOptions)..interceptors.add(logInterceptor);
  }

  static PagedResult<T> createPagedResult<T>(
      Map<String, dynamic> json, T Function(dynamic) mapping) {
    return PagedResult<T>(
      pageNumber: json["pageNumber"],
      pageSize: json["pageSize"],
      totalCount: json["totalCount"],
      totalPages: json["totalPages"],
      data: List.empty(),
      //data: json["data"].map<T>((entity) => mapping(entity)).toList(),
    );
  }
}
