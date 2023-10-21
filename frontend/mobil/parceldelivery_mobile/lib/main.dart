import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/accepted_ship_request/accepted_ship_request_bloc.dart';
import 'package:parceldelivery_mobile/bloc/currency/currency_bloc.dart';
import 'package:parceldelivery_mobile/bloc/payment_option/payment_option_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_option/shipping_option_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_request/shipping_request_bloc.dart';
import 'package:parceldelivery_mobile/bloc/vehicle_usage/vehicle_usage_bloc.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/screens/auth/employee_auth_screen.dart';
import 'package:parceldelivery_mobile/screens/auth/role_chooser.dart';
import 'package:parceldelivery_mobile/screens/currency/currency_list.dart';
import 'package:parceldelivery_mobile/screens/payment_option/payment_option_list.dart';
import 'package:parceldelivery_mobile/screens/shipping_option/shipping_option_list.dart';
import 'package:parceldelivery_mobile/screens/vehicle_usage/vehicle_usage_list.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';
import 'package:parceldelivery_mobile/screens/welcome/employee_welcome.dart';

import 'package:flex_color_scheme/flex_color_scheme.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'screens/auth/customer_auth_screen.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  HttpOverrides.global = MyHttpOverrides();
  final preferences = await SharedPreferences.getInstance();
  final theme = preferences.getString(Constants.sharedPref.themeModeTag);
  runApp(MyApp(
    themeModeValue: theme ?? Constants.theme.system,
  ));
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
  const MyApp({required this.themeModeValue, super.key});

  final String themeModeValue;
  // ignore: library_private_types_in_public_api
  static _MyAppState of(BuildContext context) =>
      context.findAncestorStateOfType<_MyAppState>()!;

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  ThemeMode themeMode = ThemeMode.system;

  @override
  void initState() {
    super.initState();
    switch (widget.themeModeValue) {
      case "dark":
        themeMode = ThemeMode.dark;
      case "light":
        themeMode = ThemeMode.light;
      default:
        themeMode = ThemeMode.system;
    }
  }

  void changeTheme(ThemeMode changedThemeMode) async {
    setState(() {
      themeMode = changedThemeMode;
    });
    final preferences = await SharedPreferences.getInstance();
    preferences.setString(Constants.sharedPref.themeModeTag, themeMode.name);
  }

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<CurrencyBloc>(
          lazy: false,
          create: (BuildContext context) => CurrencyBloc(),
        ),
        BlocProvider<PaymentOptionBloc>(
          lazy: false,
          create: (BuildContext context) => PaymentOptionBloc(),
        ),
        BlocProvider<ShippingOptionBloc>(
          lazy: false,
          create: (BuildContext context) => ShippingOptionBloc(),
        ),
        BlocProvider<AcceptedShipRequestBloc>(
          lazy: false,
          create: (BuildContext context) => AcceptedShipRequestBloc(),
        ),
        BlocProvider<ShippingRequestBloc>(
          lazy: false,
          create: (BuildContext context) => ShippingRequestBloc(),
        ),
        BlocProvider<VehicleUsageBloc>(
          lazy: false,
          create: (BuildContext context) => VehicleUsageBloc(),
        ),
      ],
      child: MaterialApp(
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
          CurrencyListScreen.routeName: (context) => const CurrencyListScreen(),
          PaymentOptionListScreen.routeName: (context) =>
              const PaymentOptionListScreen(),
          ShippingOptionListScreen.routeName: (context) =>
              const ShippingOptionListScreen(),
          VehicleUsageListScreen.routeName: (context) =>
              const VehicleUsageListScreen(),
        },
      ),
    );
  }
}
