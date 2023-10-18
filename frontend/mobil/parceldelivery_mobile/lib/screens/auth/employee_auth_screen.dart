import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/screens/welcome/employee_welcome.dart';

import '../../config.dart';
import 'auth.dart';

class EmployeeAuthScreen extends StatefulWidget {
  const EmployeeAuthScreen({super.key});

  static const routeName = '/employee-auth';

  @override
  State<EmployeeAuthScreen> createState() => _EmployeeAuthScreenState();
}

class _EmployeeAuthScreenState extends State<EmployeeAuthScreen> {
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
                  "Munkatárs bejelentkezés",
                  style: TextStyle(
                    fontSize: 20.0,
                  ),
                ),
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {
                    final config = await Config.forEnvironment();
                    // ignore: use_build_context_synchronously
                    await Auth.redirectLogin(
                      config.protocol,
                      config.employeeBaseUrl,
                      context,
                      WelcomeEmployee.routeName,
                      'employee',
                    );
                  },
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Bejelentkezés'),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
