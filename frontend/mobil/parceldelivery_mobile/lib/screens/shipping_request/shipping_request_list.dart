import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_request/shipping_request_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/shipping_request_tile.dart';

class ShippingRequestListScreen extends StatefulWidget {
  const ShippingRequestListScreen({super.key});

  static const routeName = '/shipping-requests';

  @override
  State<ShippingRequestListScreen> createState() =>
      _ShippingRequestListScreenState();
}

class _ShippingRequestListScreenState extends State<ShippingRequestListScreen> {
  @override
  void initState() {
    super.initState();
    getAll();
  }

  getAll() {
    BlocProvider.of<ShippingRequestBloc>(context).add(
      const ShippingRequestEvent.getAll(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: null,
      child: BlocBuilder<ShippingRequestBloc, ShippingRequestState>(
        builder: (context, state) {
          return state.when(
            modified: (result) {
              if (result) {
                getAll();
              }
              return const Center(
                child: Text("Sikertelen művelet."),
              );
            },
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
            loaded: (pagedData) {
              return SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: Column(
                    children: [
                      const Text(
                        "Csomagfeladásaim:",
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
                            return ShippingRequestTile(
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
