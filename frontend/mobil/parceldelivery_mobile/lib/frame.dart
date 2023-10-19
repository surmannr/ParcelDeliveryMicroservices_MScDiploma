import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/menu/appbar.dart';
import 'package:parceldelivery_mobile/components/menu/employee_drawer.dart';

class FrameScaffold extends StatelessWidget {
  const FrameScaffold(
      {required this.child, super.key, this.floatingActionButton});

  final Widget child;
  final Widget? floatingActionButton;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PackageDeliveryAppBar(),
      drawer: const EmployeeDrawer(),
      body: child,
      floatingActionButton: floatingActionButton,
    );
  }
}
