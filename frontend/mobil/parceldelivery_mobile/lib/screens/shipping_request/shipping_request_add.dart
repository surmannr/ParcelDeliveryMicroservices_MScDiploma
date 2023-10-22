import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/api/currencies.api.dart';
import 'package:parceldelivery_mobile/api/payment_options.api.dart';
import 'package:parceldelivery_mobile/api/shipping_options.api.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/add_new_billing.dart';
import 'package:parceldelivery_mobile/models/add_new_shipping_request.dart';
import 'package:parceldelivery_mobile/models/address.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/package.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/sr_stepfour_sum.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/sr_stepone_address.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/sr_stepthree_other.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/sr_steptwo_packages.dart';
import 'package:shared_preferences/shared_preferences.dart';

class ShippingRequestAddScreen extends StatefulWidget {
  const ShippingRequestAddScreen({super.key});

  static const routeName = '/new-shipping-request';

  @override
  State<ShippingRequestAddScreen> createState() =>
      _ShippingRequestAddScreenState();
}

class _ShippingRequestAddScreenState extends State<ShippingRequestAddScreen> {
  final List<GlobalKey<FormState>> _formKeys = [
    GlobalKey<FormState>(),
    GlobalKey<FormState>(),
    GlobalKey<FormState>(),
    GlobalKey<FormState>(),
  ];

  AddNewShippingRequest newShippingRequest = const AddNewShippingRequest(
    userId: "",
    name: "",
    email: "",
    courierId: "",
    addressFrom: Address(city: "", street: "", country: "", zipCode: 0),
    addressTo: Address(city: "", street: "", country: "", zipCode: 0),
    isExpress: false,
    shippingOptionId: 0,
    paymentOptionId: 0,
    billingId: "",
    isFinished: false,
    packages: [],
  );
  AddNewBilling newBilling = const AddNewBilling(
    userId: "",
    name: "",
    totalDistance: 0,
    totalAmount: 0,
    currencyId: 0,
  );

  List<PaymentOption> paymentOptions = [];
  List<ShippingOption> shippingOptions = [];
  List<Currency> currencies = [];

  getAll() async {
    var pagedCurrencies = await CurrenciesApi.get();
    var pagedPaymentOptions = await PaymentOptionsApi.get();
    var pagedShippingOptions = await ShippingOptionsApi.get();

    setState(() {
      currencies = pagedCurrencies.data;
      paymentOptions = pagedPaymentOptions.data;
      shippingOptions = pagedShippingOptions.data;
    });
  }

  @override
  void initState() {
    super.initState();
    getAll();
  }

  void changeAddressFrom({
    required String country,
    required String city,
    required String street,
    required int zipCode,
  }) {
    newShippingRequest = newShippingRequest.copyWith(
      addressFrom: Address(
        city: city,
        zipCode: zipCode,
        country: country,
        street: street,
      ),
    );
  }

  void changeAddressTo({
    required String country,
    required String city,
    required String street,
    required int zipCode,
  }) {
    newShippingRequest = newShippingRequest.copyWith(
      addressTo: Address(
        city: city,
        zipCode: zipCode,
        country: country,
        street: street,
      ),
    );
  }

  void addPackage(Package package) {
    setState(() {
      var packages = [...newShippingRequest.packages];
      packages.add(package);
      newShippingRequest = newShippingRequest.copyWith(packages: packages);
    });
  }

  void deletePackage(Package package) {
    setState(() {
      var packages = [...newShippingRequest.packages];
      packages.removeWhere(
        (element) => element == package,
      );
      newShippingRequest = newShippingRequest.copyWith(packages: packages);
    });
  }

  void changePaymentOption(int value) {
    newShippingRequest = newShippingRequest.copyWith(paymentOptionId: value);
  }

  void changeShippingOption(int value) {
    newShippingRequest = newShippingRequest.copyWith(shippingOptionId: value);
  }

  void changeCurrency(int value) {
    newBilling = newBilling.copyWith(currencyId: value);
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: null,
      child: SingleChildScrollView(
        child: FutureBuilder(
            future: SharedPreferences.getInstance(),
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
                  newBilling = newBilling.copyWith(
                      userId: snapshot.data
                              ?.getString(Constants.sharedPref.userIdTag) ??
                          "");
                  newBilling = newBilling.copyWith(
                      name: snapshot.data
                              ?.getString(Constants.sharedPref.nameTag) ??
                          "");
                  newShippingRequest = newShippingRequest.copyWith(
                      userId: snapshot.data
                              ?.getString(Constants.sharedPref.userIdTag) ??
                          "",
                      name: snapshot.data
                              ?.getString(Constants.sharedPref.nameTag) ??
                          "",
                      email: snapshot.data
                              ?.getString(Constants.sharedPref.emailTag) ??
                          "");
                  return Column(
                    children: [
                      const SizedBox(
                        height: 10,
                      ),
                      const Text(
                        "Új rendelés felvétele",
                        style: TextStyle(
                          fontSize: 25,
                        ),
                        textAlign: TextAlign.start,
                      ),
                      const SizedBox(
                        height: 5,
                      ),
                      Stepper(
                        physics: const ClampingScrollPhysics(),
                        controlsBuilder: (context, controller) {
                          return Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: <Widget>[
                              TextButton(
                                onPressed:
                                    _currentStep != 0 ? _stepCancel : null,
                                child: const Text('Vissza'),
                              ),
                              TextButton(
                                onPressed: () {
                                  setState(() {
                                    if (_formKeys[_currentStep]
                                            .currentState!
                                            .validate() &&
                                        _currentStep != 3) {
                                      _stepContinue();
                                    }
                                  });
                                },
                                child: const Text('Következő'),
                              ),
                            ],
                          );
                        },
                        steps: <Step>[
                          Step(
                            title: const Text('Helyadatok'),
                            content: Container(
                              alignment: Alignment.centerLeft,
                              child: Form(
                                key: _formKeys[0],
                                child: ShipReqStepOneAddress(
                                  addressFrom: newShippingRequest.addressFrom,
                                  addressTo: newShippingRequest.addressTo,
                                  addressToChanged: changeAddressTo,
                                  addressFromChanged: changeAddressFrom,
                                  sharedPreferences: snapshot.data!,
                                ),
                              ),
                            ),
                            isActive: _currentStep == 0,
                          ),
                          Step(
                            title: const Text('Csomagok'),
                            content: Container(
                              alignment: Alignment.centerLeft,
                              child: Form(
                                key: _formKeys[1],
                                child: ShipReqStepTwoPackages(
                                  userId: snapshot.data!.getString(
                                          Constants.sharedPref.userIdTag) ??
                                      "",
                                  packages: newShippingRequest.packages,
                                  addPackage: addPackage,
                                  deletePackage: deletePackage,
                                ),
                              ),
                            ),
                            isActive: _currentStep == 1,
                          ),
                          Step(
                            title: const Text('Egyéb információk'),
                            content: Container(
                              alignment: Alignment.centerLeft,
                              child: Form(
                                key: _formKeys[2],
                                child: ShipReqStepThreeOther(
                                  currencies: currencies,
                                  shippingOptions: shippingOptions,
                                  paymentOptions: paymentOptions,
                                  currencyChanged: changeCurrency,
                                  paymentOptionChanged: changePaymentOption,
                                  shippingOptionChanged: changeShippingOption,
                                  currencyId: newBilling.currencyId,
                                  shippingOptionId:
                                      newShippingRequest.shippingOptionId,
                                  paymentOptionId:
                                      newShippingRequest.paymentOptionId,
                                ),
                              ),
                            ),
                            isActive: _currentStep == 2,
                          ),
                          Step(
                            title: const Text('Összegzés'),
                            content: Container(
                              alignment: Alignment.centerLeft,
                              child: Form(
                                key: _formKeys[3],
                                child: ShipReqStepFourSum(
                                  sharedPreferences: snapshot.data!,
                                  billing: newBilling,
                                  shippingRequest: newShippingRequest,
                                  currencies: currencies,
                                  shippingOptions: shippingOptions,
                                  paymentOptions: paymentOptions,
                                ),
                              ),
                            ),
                            isActive: _currentStep == 3,
                          ),
                        ],
                        currentStep: _currentStep,
                        onStepTapped: (step) => _stepTapped(step),
                        onStepContinue: _stepContinue,
                        onStepCancel: _stepCancel,
                      )
                    ],
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
            }),
      ),
    );
  }

  int _currentStep = 0;
  final int _maxStepIndex = 3;

  // Ha magára a lépésre kattintunk akkor az állítódjon be.
  _stepTapped(int step) {
    setState(() => _currentStep = step);
  }

  // A lépés alján lévő következő gomb funkciója, továbblép a következőre.
  _stepContinue() {
    _currentStep < _maxStepIndex
        ? setState(() {
            _currentStep += 1;
          })
        : null;
  }

  // A lépés alján lévő vissza gomb funkciója, visszalép az előzőre.
  _stepCancel() {
    _currentStep > 0 ? setState(() => _currentStep -= 1) : null;
  }
}
