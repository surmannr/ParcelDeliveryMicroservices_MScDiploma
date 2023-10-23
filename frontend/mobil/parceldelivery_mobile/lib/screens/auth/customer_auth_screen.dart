import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/config.dart';
import 'package:parceldelivery_mobile/screens/auth/auth.dart';
import 'package:parceldelivery_mobile/screens/welcome/customer_welcome.dart';

class CustomerAuthScreen extends StatefulWidget {
  const CustomerAuthScreen({super.key});

  static const routeName = '/customer-auth';

  @override
  State<CustomerAuthScreen> createState() => _CustomerAuthScreenState();
}

class _CustomerAuthScreenState extends State<CustomerAuthScreen> {
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
                  "Ügyfél bejelentkezés/regisztrálás",
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
                      config.customerBaseUrl,
                      context,
                      WelcomeCustomer.routeName,
                      'customer',
                    );
                  },
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Bejelentkezés'),
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {
                    await Auth.register();
                  },
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Regisztráció'),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
