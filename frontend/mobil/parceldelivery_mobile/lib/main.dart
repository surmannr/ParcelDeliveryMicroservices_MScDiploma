import 'dart:io';

import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/screens/auth/employee_auth_screen.dart';
import 'package:parceldelivery_mobile/screens/auth/role_chooser.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';
import 'package:parceldelivery_mobile/screens/welcome/employee_welcome.dart';

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

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ParcelDeliveryApp',
      builder: (context, child) => MediaQuery(
          data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
          child: child!),
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: const Color.fromARGB(255, 1, 184, 95)),
        useMaterial3: true,
        fontFamily: 'Coolvetica',
      ),
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
