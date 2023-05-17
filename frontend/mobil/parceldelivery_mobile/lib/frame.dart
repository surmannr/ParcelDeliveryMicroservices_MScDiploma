import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/menu/appbar.dart';

class FrameScaffold extends StatelessWidget {
  FrameScaffold({required this.child, super.key});

  Widget child;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PackageDeliveryAppBar(),
      body: child,
    );
  }
}
