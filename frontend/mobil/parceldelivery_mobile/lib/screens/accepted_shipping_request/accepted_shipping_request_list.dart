import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/accepted_ship_request/accepted_ship_request_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/screens/accepted_shipping_request/accepted_shipping_request_tile.dart';

class AcceptedShippingRequestListScreen extends StatefulWidget {
  const AcceptedShippingRequestListScreen({super.key});

  static const routeName = '/accepted-shipping-request';

  @override
  State<AcceptedShippingRequestListScreen> createState() =>
      _AcceptedShippingRequestListScreenScreenState();
}

class _AcceptedShippingRequestListScreenScreenState
    extends State<AcceptedShippingRequestListScreen> {
  @override
  void initState() {
    super.initState();
    getAll();
  }

  getAll() {
    BlocProvider.of<AcceptedShipRequestBloc>(context).add(
      const AcceptedShipRequestEvent.getAll(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: null,
      child: BlocBuilder<AcceptedShipRequestBloc, AcceptedShipRequestState>(
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
              if (result) {
                getAll();
              }
              return const Center(
                child: Text("Sikertelen művelet."),
              );
            },
            loaded: (pagedData) {
              return SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: Column(
                    children: [
                      const SizedBox(
                        height: 10,
                      ),
                      const Text(
                        "Hozzám rendelt csomagfeladások:",
                        style: TextStyle(
                          fontSize: 22,
                        ),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      ListView.builder(
                          shrinkWrap: true,
                          physics: const NeverScrollableScrollPhysics(),
                          itemCount: pagedData.totalCount,
                          itemBuilder: (BuildContext context, int index) {
                            return AcceptedShippingRequestTile(
                              entity: pagedData.data[index],
                            );
                          }),
                    ],
                  ),
                ),
              );
            },
          );
        },
      ),
    );
  }
}
