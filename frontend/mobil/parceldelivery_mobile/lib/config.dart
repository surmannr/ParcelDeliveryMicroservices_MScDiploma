import 'dart:convert';

import 'package:flutter/services.dart';

class Config {
  static String environment = "dev";

  final String protocol;
  final String customerBaseUrl;
  final String employeeBaseUrl;
  final String baseUrl;

  Config({
    required this.protocol,
    required this.customerBaseUrl,
    required this.employeeBaseUrl,
    required this.baseUrl,
  });

  static Future<Config> forEnvironment() async {
    // load the json file
    final contents = await rootBundle.loadString(
      'assets/config/$environment.json',
    );

    // decode our json
    final json = jsonDecode(contents);

    // convert our JSON into an instance of our AppConfig class
    return Config(
      protocol: json['protocol'],
      customerBaseUrl: json['customerBaseUrl'],
      employeeBaseUrl: json['employeeBaseUrl'],
      baseUrl: json['baseUrl'],
    );
  }
}
