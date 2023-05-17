import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_web_auth_2/flutter_web_auth_2.dart';
import 'package:http/http.dart' as http;
import 'package:jwt_decoder/jwt_decoder.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';
import 'package:pkce/pkce.dart';
import 'package:shared_preferences/shared_preferences.dart';

class AuthScreen extends StatefulWidget {
  const AuthScreen({super.key});

  @override
  State<AuthScreen> createState() => _AuthScreenState();
}

class _AuthScreenState extends State<AuthScreen> {
  // Authorization
  final authorizationEndpoint = Uri.parse(
      '${const String.fromEnvironment("customerBaseUrl")}/connect/authorize');
  // Token
  final tokenEndpoint = Uri.parse(
      '${const String.fromEnvironment("customerBaseUrl")}/connect/token');
  // Revocation
  final revoke = Uri.parse(
      "${const String.fromEnvironment("customerBaseUrl")}/connect/revocation");
  // EndSession
  final endSession = Uri.parse(
      "${const String.fromEnvironment("customerBaseUrl")}/connect/endsession");
  final redirectUrl = Uri.parse("com.example.flutterapp://callback");
  // Client information
  final identifier = 'flutter-client';
  final secret = 'secret';

  Future<String> getAccessToken() async {
    final pkcePair = PkcePair.generate();
    // Construct the url
    var url = Uri.https('10.0.2.2:5002', '/connect/authorize', {
      'response_type': 'code',
      'client_id': identifier,
      'redirect_uri': 'com.example.flutterapp://callback',
      'scope': 'openid profile offline_access',
      'grant_type': 'authorization_code',
      'code_challenge_method': 'S256',
      'code_challenge': pkcePair.codeChallenge
    });
    // Present the dialog to the user
    var result = await FlutterWebAuth2.authenticate(
        url: url.toString(), callbackUrlScheme: "com.example.flutterapp");

    // Extract token from resulting url
    var code = Uri.parse(result).queryParameters['code'] ?? "nope";

    final urlT = Uri.https('10.0.2.2:5002', '/connect/token', {});
    var map = <String, dynamic>{};
    map['grant_type'] = 'authorization_code';
    map['client_id'] = identifier;
    map['client_secret'] = secret;
    map['code'] = code;
    map['code_verifier'] = pkcePair.codeVerifier;
    map['redirect_uri'] = redirectUrl.toString();
    final response = await http.post(urlT, headers: {}, body: map);

    // Get the access token from the response
    return jsonDecode(response.body)['access_token'] ?? "";
  }

  final _formKey = GlobalKey<FormState>();

  Future<void> _redirectLogin() async {
    var accesToken = await getAccessToken();

    if (accesToken.isNotEmpty) {
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      await prefs.setString('acces_token', accesToken);
      var jwt = JwtDecoder.decode(accesToken);
      await prefs.setString('user_id', jwt['sub']);
      await Navigator.of(context).pushNamed(WelcomeCustomer.routeName);
    } else {
      const snackBar = SnackBar(
        content: Text('Sikertelen bejelentkezés!'),
      );
      ScaffoldMessenger.of(context).showSnackBar(snackBar);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Form(
        key: _formKey,
        autovalidateMode: AutovalidateMode.disabled,
        child: Padding(
          padding: const EdgeInsets.all(18.0),
          child: Column(
            mainAxisSize: MainAxisSize.max,
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: _redirectLogin,
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Bejelentkezés'),
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {},
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Regisztráció'),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
