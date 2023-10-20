import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/shipping_option/shipping_option_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';
import 'package:parceldelivery_mobile/screens/shipping_option/shipping_option_dialog.dart';
import 'package:parceldelivery_mobile/screens/shipping_option/shipping_option_tile.dart';

class ShippingOptionListScreen extends StatefulWidget {
  const ShippingOptionListScreen({super.key});

  static const routeName = '/shipping-options';

  @override
  State<ShippingOptionListScreen> createState() =>
      _ShippingOptionListScreenState();
}

class _ShippingOptionListScreenState extends State<ShippingOptionListScreen> {
  @override
  void initState() {
    super.initState();
    getAll();
  }

  getAll() {
    BlocProvider.of<ShippingOptionBloc>(context).add(
      const ShippingOptionEvent.getAll(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: () => showDialog(
          context: context,
          builder: (BuildContext context) {
            return const ShippingOptionDialog(
              entity: ShippingOption(id: 0, name: "", price: 0),
            );
          },
        ),
        child: const Icon(Icons.add),
      ),
      child: BlocBuilder<ShippingOptionBloc, ShippingOptionState>(
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
                      const Text(
                        "Fizetési opciók:",
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
                            return ShippingOptionTile(
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
