import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/frame.dart';

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
      child: Column(
        children: [
          Text("Welcome"),
        ],
      ),
    );
  }
}
