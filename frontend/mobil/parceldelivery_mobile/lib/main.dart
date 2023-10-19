import 'dart:io';

import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/screens/auth/employee_auth_screen.dart';
import 'package:parceldelivery_mobile/screens/auth/role_chooser.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';
import 'package:parceldelivery_mobile/screens/welcome/employee_welcome.dart';

import 'package:flex_color_scheme/flex_color_scheme.dart';

import 'screens/auth/customer_auth_screen.dart';

void main() {
  HttpOverrides.global = MyHttpOverrides();
  runApp(const MyApp());
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  // ignore: library_private_types_in_public_api
  static _MyAppState of(BuildContext context) =>
      context.findAncestorStateOfType<_MyAppState>()!;

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  ThemeMode themeMode = ThemeMode.system;

  void changeTheme(ThemeMode changedThemeMode) {
    setState(() {
      themeMode = changedThemeMode;
    });
  }

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ParcelDeliveryApp',
      builder: (context, child) => MediaQuery(
          data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
          child: child!),
      theme: FlexThemeData.light(
        scheme: FlexScheme.dellGenoa,
        surfaceMode: FlexSurfaceMode.levelSurfacesLowScaffold,
        blendLevel: 7,
        subThemesData: const FlexSubThemesData(
          blendOnLevel: 10,
          blendOnColors: false,
          useTextTheme: true,
          useM2StyleDividerInM3: true,
          useInputDecoratorThemeInDialogs: true,
        ),
        visualDensity: FlexColorScheme.comfortablePlatformDensity,
        useMaterial3: true,
        fontFamily: 'Coolvetica',
        swapLegacyOnMaterial3: true,
      ),
      darkTheme: FlexThemeData.dark(
        scheme: FlexScheme.dellGenoa,
        surfaceMode: FlexSurfaceMode.levelSurfacesLowScaffold,
        blendLevel: 13,
        subThemesData: const FlexSubThemesData(
          blendOnLevel: 20,
          useTextTheme: true,
          useM2StyleDividerInM3: true,
          useInputDecoratorThemeInDialogs: true,
        ),
        visualDensity: FlexColorScheme.comfortablePlatformDensity,
        useMaterial3: true,
        fontFamily: 'Coolvetica',
        swapLegacyOnMaterial3: true,
      ),
      themeMode: themeMode,
      home: RoleChooserScreen(),
      routes: {
        WelcomeCustomer.routeName: (context) => const WelcomeCustomer(),
        WelcomeEmployee.routeName: (context) => const WelcomeEmployee(),
        RoleChooserScreen.routeName: (context) => RoleChooserScreen(),
        CustomerAuthScreen.routeName: (context) => const CustomerAuthScreen(),
        EmployeeAuthScreen.routeName: (context) => const EmployeeAuthScreen(),
      },
    );
  }
}
