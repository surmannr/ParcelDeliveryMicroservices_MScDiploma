import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_request/shipping_request_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';

class TrackDetailScreen extends StatefulWidget {
  const TrackDetailScreen({this.id, super.key});

  static const routeName = '/track';
  final String? id;

  @override
  State<TrackDetailScreen> createState() => _TrackDetailScreenState();
}

class _TrackDetailScreenState extends State<TrackDetailScreen> {
  final _formKey = GlobalKey<FormState>();
  String? trackId;

  void _track() {
    final isValid = _formKey.currentState?.validate();

    if (isValid != null && isValid) {
      setState(() {
        _formKey.currentState?.save();
        print("id: $trackId");
        BlocProvider.of<ShippingRequestBloc>(context).add(
          ShippingRequestEvent.track(trackId ?? ""),
        );
      });
    }
  }

  @override
  void initState() {
    super.initState();
    trackId = widget.id;
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: null,
      child: Form(
        key: _formKey,
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(
                height: 15,
              ),
              const Text(
                "Csomagom nyomonkövetése:",
                style: TextStyle(
                  fontSize: 20,
                ),
                textAlign: TextAlign.start,
              ),
              const SizedBox(
                height: 15,
              ),
              TextFormField(
                decoration:
                    const InputDecoration(labelText: "Feladás azonosító száma"),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return "Az azonosítót kitölteni kötelező!";
                  }
                  return null;
                },
                keyboardType: TextInputType.text,
                onSaved: (value) {
                  trackId = value!;
                },
                initialValue: trackId,
              ),
              const SizedBox(
                height: 10,
              ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: _track,
                  clipBehavior: Clip.hardEdge,
                  child: const Text('Nyomonkövetés'),
                ),
              ),
              const SizedBox(
                height: 15,
              ),
              const Divider(),
              const SizedBox(
                height: 15,
              ),
              trackId != null
                  ? BlocBuilder<ShippingRequestBloc, ShippingRequestState>(
                      builder: (context, state) {
                      return state.when(
                        loading: () {
                          return const Center(
                            child: CircularProgressIndicator(),
                          );
                        },
                        error: (message) {
                          return Center(
                            child: Text(message),
                          );
                        },
                        modified: (result) {
                          return const Center(
                            child: Text(
                              "Nincs ilyen azonosítóval csomagfeladás.",
                            ),
                          );
                        },
                        loaded: (pagedData) {
                          var data = pagedData.data.first;
                          return SingleChildScrollView(
                            child: Padding(
                              padding: const EdgeInsets.all(10.0),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Text(
                                    "Csomagfeladás #${data.id}",
                                    style: const TextStyle(
                                      fontSize: 22,
                                    ),
                                  ),
                                  const SizedBox(
                                    height: 20,
                                  ),
                                  Text(
                                    "Honnan: ${data.addressFrom.country} ${data.addressFrom.zipCode} ${data.addressFrom.city}, ${data.addressFrom.street}",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                  ),
                                  const SizedBox(
                                    height: 5,
                                  ),
                                  Text(
                                    "Hova: ${data.addressTo.country} ${data.addressTo.zipCode} ${data.addressTo.city}, ${data.addressTo.street}",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                  ),
                                  const SizedBox(
                                    height: 15,
                                  ),
                                  Text(
                                    "Szállítási mód: ${data.shippingOption.name}",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                  const SizedBox(
                                    height: 5,
                                  ),
                                  Text(
                                    "Fizetési mód: ${data.paymentOption.name}",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                  const SizedBox(
                                    height: 15,
                                  ),
                                  const Text(
                                    "Csomagok:",
                                    style: TextStyle(
                                      fontSize: 15,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                  ...data.packages
                                      .map((e) => Row(
                                            children: [
                                              const SizedBox(
                                                width: 15,
                                              ),
                                              Text(
                                                "- ${e.sizeX} x ${e.sizeY} x ${e.sizeZ} m, ${e.weight} kg ${e.isFragile ? "Törékeny" : ""}",
                                                style: const TextStyle(
                                                  fontSize: 13,
                                                ),
                                                textAlign: TextAlign.start,
                                              ),
                                            ],
                                          ))
                                      .toList(),
                                  const SizedBox(
                                    height: 15,
                                  ),
                                  Text(
                                    "Feladó neve: ${data.name}",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                  const SizedBox(
                                    height: 5,
                                  ),
                                  Text(
                                    "Fizetendő összeg: ${data.billing.totalAmount} Ft",
                                    style: const TextStyle(
                                      fontSize: 15,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                  const SizedBox(
                                    height: 5,
                                  ),
                                  Text(
                                    "Ezt az összeget ${data.billing.currency.name} alapon kell majd átvételnél fizetni.",
                                    style: const TextStyle(
                                      fontSize: 10,
                                    ),
                                    textAlign: TextAlign.start,
                                  ),
                                ],
                              ),
                            ),
                          );
                        },
                      );
                    })
                  : const Center(
                      child: Text("Nincs megjelenítendő elem."),
                    ),
            ],
          ),
        ),
      ),
    );
  }
}
