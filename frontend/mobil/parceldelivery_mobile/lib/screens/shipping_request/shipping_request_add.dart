import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/add_new_shipping_request.dart';
import 'package:parceldelivery_mobile/models/address.dart';
import 'package:parceldelivery_mobile/models/package.dart';
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
  final _formKey = GlobalKey<FormState>();

  AddNewShippingRequest newShippingRequest = const AddNewShippingRequest(
    userId: "",
    courierId: "",
    addressFrom: Address(city: "", street: "", country: "", zipCode: 0),
    addressTo: Address(city: "", street: "", country: "", zipCode: 0),
    isExpress: false,
    shippingOptionId: 0,
    paymentOptionId: 0,
    billingId: "",
    isFinished: false,
  );

  void changeAddressFrom(Address address) {
    newShippingRequest = newShippingRequest.copyWith(addressFrom: address);
  }

  void changeAddressTo(Address address) {
    newShippingRequest = newShippingRequest.copyWith(addressTo: address);
  }

  List<Package> packages = [];
  void addPackage(Package package) {
    setState(() {
      packages.add(package);
    });
  }

  void deletePackage(Package package) {
    setState(() {
      packages.remove(package);
    });
  }

  void changePaymentOption(int value) {
    newShippingRequest = newShippingRequest.copyWith(paymentOptionId: value);
  }

  void changeShippingOption(int value) {
    newShippingRequest = newShippingRequest.copyWith(shippingOptionId: value);
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
                      Form(
                        key: _formKey,
                        child: Stepper(
                          physics: const ClampingScrollPhysics(),
                          controlsBuilder: (context, controller) {
                            return Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: <Widget>[
                                TextButton(
                                  onPressed: _stepContinue,
                                  child: const Text('Következő'),
                                ),
                                TextButton(
                                  onPressed: _stepCancel,
                                  child: const Text('Vissza'),
                                ),
                              ],
                            );
                          },
                          steps: <Step>[
                            Step(
                              title: const Text('Helyadatok'),
                              content: Container(
                                alignment: Alignment.centerLeft,
                                child: ShipReqStepOneAddress(
                                  addressFrom: newShippingRequest.addressFrom,
                                  addressTo: newShippingRequest.addressTo,
                                  addressToChanged: changeAddressTo,
                                  addressFromChanged: changeAddressFrom,
                                ),
                              ),
                              isActive: _currentStep == 0,
                            ),
                            Step(
                              title: const Text('Csomagok'),
                              content: Container(
                                alignment: Alignment.centerLeft,
                                child: ShipReqStepTwoPackages(
                                  userId: snapshot.data!.getString(
                                          Constants.sharedPref.userIdTag) ??
                                      "",
                                  packages: packages,
                                  addPackage: addPackage,
                                  deletePackage: deletePackage,
                                ),
                              ),
                              isActive: _currentStep == 1,
                            ),
                            Step(
                              title: const Text('Egyéb információk'),
                              content: Container(
                                alignment: Alignment.centerLeft,
                                child: ShipReqStepThreeOther(
                                  paymentOption:
                                      newShippingRequest.paymentOptionId,
                                  shippingOption:
                                      newShippingRequest.shippingOptionId,
                                  paymentOptionChanged: changePaymentOption,
                                  shippingOptionChanged: changeShippingOption,
                                ),
                              ),
                              isActive: _currentStep == 2,
                            ),
                          ],
                          currentStep: _currentStep,
                          onStepTapped: (step) => _stepTapped(step),
                          onStepContinue: _stepContinue,
                          onStepCancel: _stepCancel,
                        ),
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
