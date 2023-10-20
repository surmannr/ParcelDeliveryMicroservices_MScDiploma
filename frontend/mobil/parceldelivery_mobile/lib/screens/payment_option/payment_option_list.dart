import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/payment_option/payment_option_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';
import 'package:parceldelivery_mobile/screens/payment_option/payment_option_dialog.dart';
import 'package:parceldelivery_mobile/screens/payment_option/payment_option_tile.dart';

class PaymentOptionListScreen extends StatefulWidget {
  const PaymentOptionListScreen({super.key});

  static const routeName = '/payment-options';

  @override
  State<PaymentOptionListScreen> createState() =>
      _PaymentOptionListScreenState();
}

class _PaymentOptionListScreenState extends State<PaymentOptionListScreen> {
  @override
  void initState() {
    super.initState();
    getAll();
  }

  getAll() {
    BlocProvider.of<PaymentOptionBloc>(context).add(
      const PaymentOptionEvent.getAll(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: () => showDialog(
          context: context,
          builder: (BuildContext context) {
            return const PaymentOptionDialog(
              entity: PaymentOption(id: 0, name: ""),
            );
          },
        ),
        child: const Icon(Icons.add),
      ),
      child: BlocBuilder<PaymentOptionBloc, PaymentOptionState>(
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
                            return PaymentOptionTile(
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
