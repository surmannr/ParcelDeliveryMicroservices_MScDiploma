import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/menu/appbar.dart';
import 'package:parceldelivery_mobile/components/menu/customer_drawer.dart';
import 'package:parceldelivery_mobile/components/menu/employee_drawer.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:shared_preferences/shared_preferences.dart';

class FrameScaffold extends StatelessWidget {
  const FrameScaffold(
      {required this.child, super.key, this.floatingActionButton});

  final Widget child;
  final Widget? floatingActionButton;

  Future<String> _getUserId() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    final storedRole = prefs.getString(Constants.sharedPref.roleTag);
    return storedRole ?? "customer";
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
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
            final role = snapshot.data as String;
            return Scaffold(
              appBar: PackageDeliveryAppBar(),
              drawer: role == "customer"
                  ? const CustomerDrawer()
                  : const EmployeeDrawer(),
              body: child,
              floatingActionButton: floatingActionButton,
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
      },
      future: _getUserId(),
    );
  }
}
