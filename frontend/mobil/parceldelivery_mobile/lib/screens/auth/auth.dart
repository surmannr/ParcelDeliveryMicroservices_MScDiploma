import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_web_auth_2/flutter_web_auth_2.dart';
import 'package:jwt_decoder/jwt_decoder.dart';
import 'package:pkce/pkce.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class Auth {
  static final redirectUrl = Uri.parse("com.example.flutterapp://callback");
  // Client information
  static const identifier = 'flutter-client';
  static const secret = 'secret';

  static const employeeApiScope = "employeeApi";
  static const customerApiScope = "customersApi";

  static Future<String> getAccessToken(
      String protocol, String baseUrl, bool isEmployee) async {
    final pkcePair = PkcePair.generate();

    var scope = isEmployee ? employeeApiScope : customerApiScope;

    // Construct the url
    var url = protocol == "https://"
        ? Uri.https(baseUrl, '/connect/authorize', {
            'response_type': 'code',
            'client_id': identifier,
            'redirect_uri': redirectUrl.toString(),
            'scope': 'openid profile offline_access $scope',
            'grant_type': 'authorization_code',
            'code_challenge_method': 'S256',
            'code_challenge': pkcePair.codeChallenge
          })
        : Uri.http(baseUrl, '/connect/authorize', {
            'response_type': 'code',
            'client_id': identifier,
            'redirect_uri': redirectUrl.toString(),
            'scope': 'openid profile offline_access $scope',
            'grant_type': 'authorization_code',
            'code_challenge_method': 'S256',
            'code_challenge': pkcePair.codeChallenge
          });
    // Present the dialog to the user
    var result = await FlutterWebAuth2.authenticate(
        url: url.toString(), callbackUrlScheme: "com.example.flutterapp");

    // Extract token from resulting url
    var code = Uri.parse(result).queryParameters['code'] ?? "nope";

    final urlT = protocol == "https://"
        ? Uri.https(baseUrl, '/connect/token', {})
        : Uri.http(baseUrl, '/connect/token', {});
    var map = <String, dynamic>{};
    map['grant_type'] = 'authorization_code';
    map['client_id'] = identifier;
    map['client_secret'] = secret;
    map['code'] = code;
    map['code_verifier'] = pkcePair.codeVerifier;
    map['scope'] = 'openid profile offline_access $scope';
    map['redirect_uri'] = redirectUrl.toString();
    final response = await http.post(urlT, headers: {}, body: map);

    // Get the access token from the response
    return jsonDecode(response.body)['access_token'] ?? "";
  }

  static Future<void> redirectLogin(
    String protocol,
    String baseUrl,
    BuildContext context,
    String navigateRouteName,
    String role,
  ) async {
    var accesToken =
        await getAccessToken(protocol, baseUrl, role == "employee");

    if (accesToken.isNotEmpty) {
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      await prefs.setString('access_token', accesToken);
      var jwt = JwtDecoder.decode(accesToken);
      await prefs.setString('user_id', jwt['sub']);
      await prefs.setString('name', jwt['name']);
      await prefs.setString('username', jwt['preferred_username']);
      await prefs.setString('given_name', jwt['given_name']);
      await prefs.setString('family_name', jwt['family_name']);
      await prefs.setString('email', jwt['email']);
      await prefs.setString('role', role);
      // ignore: use_build_context_synchronously
      await Navigator.of(context).popAndPushNamed(navigateRouteName);
    } else {
      const snackBar = SnackBar(
        content: Text('Sikertelen bejelentkezés!'),
      );
      // ignore: use_build_context_synchronously
      ScaffoldMessenger.of(context).showSnackBar(snackBar);
    }
  }
}
