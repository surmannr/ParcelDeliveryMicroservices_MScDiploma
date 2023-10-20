import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/menu/appbar.dart';
import 'package:parceldelivery_mobile/components/menu/customer_drawer.dart';
import 'package:parceldelivery_mobile/components/menu/employee_drawer.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:shared_preferences/shared_preferences.dart';

class FrameScaffold extends StatefulWidget {
  const FrameScaffold(
      {required this.child, super.key, this.floatingActionButton});

  final Widget child;
  final Widget? floatingActionButton;

  @override
  State<FrameScaffold> createState() => _FrameScaffoldState();
}

class _FrameScaffoldState extends State<FrameScaffold> {
  @override
  void initState() {
    super.initState();
    _getUserId();
  }

  String role = "customer";
  _getUserId() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    role = prefs.getString(Constants.sharedPref.roleTag) ?? "customer";
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PackageDeliveryAppBar(),
      drawer:
          role == "customer" ? const CustomerDrawer() : const EmployeeDrawer(),
      body: widget.child,
      floatingActionButton: widget.floatingActionButton,
    );
  }
}
