import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:shared_preferences/shared_preferences.dart';

class WelcomeCustomer extends StatefulWidget {
  const WelcomeCustomer({super.key});

  static const routeName = '/welcome-customer';

  @override
  State<WelcomeCustomer> createState() => _WelcomeCustomerState();
}

class _WelcomeCustomerState extends State<WelcomeCustomer> {
  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      child: FutureBuilder(
          future: SharedPreferences.getInstance(),
          builder: (ctx, snapshot) {
            if (snapshot.connectionState == ConnectionState.done) {
              // If we got an error
              if (snapshot.hasError) {
                return const Center(
                  child: Text(
                    'Hiba történt',
                    style: TextStyle(fontSize: 18),
                  ),
                );
              } else if (snapshot.hasData) {
                return Center(
                  child: Text(
                    "Üdvözöljük ${snapshot.data?.getString(Constants.sharedPref.nameTag) ?? ""}",
                    style: const TextStyle(
                      fontSize: 22,
                    ),
                  ),
                );
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            } else {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
          }),
    );
  }
}
