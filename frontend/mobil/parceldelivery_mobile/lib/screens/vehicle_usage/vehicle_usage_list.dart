import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:parceldelivery_mobile/bloc/vehicle_usage/vehicle_usage_bloc.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/screens/vehicle_usage/vehicle_usage_tile.dart';

class VehicleUsageListScreen extends StatefulWidget {
  const VehicleUsageListScreen({super.key});

  static const routeName = '/vehicle-usages';

  @override
  State<VehicleUsageListScreen> createState() => _VehicleUsageListScreenState();
}

class _VehicleUsageListScreenState extends State<VehicleUsageListScreen> {
  @override
  void initState() {
    super.initState();
    getAll();
  }

  getAll() {
    BlocProvider.of<VehicleUsageBloc>(context).add(
      const VehicleUsageEvent.getAll(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return FrameScaffold(
      floatingActionButton: null,
      child: BlocBuilder<VehicleUsageBloc, VehicleUsageState>(
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
            loaded: (pagedData) {
              return SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: Column(
                    children: [
                      const Text(
                        "Jármű használataim:",
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
                            return VehicleUsageTile(
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
