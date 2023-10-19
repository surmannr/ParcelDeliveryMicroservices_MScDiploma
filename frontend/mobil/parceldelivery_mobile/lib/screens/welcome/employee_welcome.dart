import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/frame.dart';

class WelcomeEmployee extends StatefulWidget {
  const WelcomeEmployee({super.key});

  static const routeName = '/welcome-employee';

  @override
  State<WelcomeEmployee> createState() => _WelcomeEmployeeState();
}

class _WelcomeEmployeeState extends State<WelcomeEmployee> {
  @override
  Widget build(BuildContext context) {
    return const FrameScaffold(
      child: Column(
        children: [
          Text("TESZT"),
        ],
      ),
    );
  }
}
