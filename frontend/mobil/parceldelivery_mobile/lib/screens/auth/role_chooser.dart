import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/screens/auth/customer_auth_screen.dart';
import 'package:parceldelivery_mobile/screens/auth/employee_auth_screen.dart';

class RoleChooserScreen extends StatelessWidget {
  RoleChooserScreen({super.key});

  static const routeName = '/role';
  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Form(
        key: _formKey,
        autovalidateMode: AutovalidateMode.disabled,
        child: Padding(
          padding: const EdgeInsets.all(18.0),
          child: Column(
            mainAxisSize: MainAxisSize.max,
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const Padding(
                padding: EdgeInsets.only(bottom: 42.0),
                child: Text(
                  "Kérem válasszon az alábbiak közül:",
                  style: TextStyle(
                    fontSize: 20.0,
                  ),
                ),
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {
                    await Navigator.of(context)
                        .pushNamed(CustomerAuthScreen.routeName);
                  },
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Ügyfél'),
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {
                    await Navigator.of(context)
                        .pushNamed(EmployeeAuthScreen.routeName);
                  },
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Munkatárs'),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
