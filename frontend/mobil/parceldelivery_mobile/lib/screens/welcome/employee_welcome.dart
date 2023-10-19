import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/api/informations.api.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';

class WelcomeEmployee extends StatefulWidget {
  const WelcomeEmployee({super.key});

  static const routeName = '/welcome-employee';

  @override
  State<WelcomeEmployee> createState() => _WelcomeEmployeeState();
}

class _WelcomeEmployeeState extends State<WelcomeEmployee> {
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _asyncMethod();
    });
  }

  late PagedResult<Currency> data;
  _asyncMethod() async {
    data = await InformationsApi.getCurrencies();
    print(data);
  }

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
