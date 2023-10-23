import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:parceldelivery_mobile/api/accepted_ship_requests.api.dart';
import 'package:parceldelivery_mobile/frame.dart';
import 'package:parceldelivery_mobile/models/accepted_ship_request.dart';
import 'package:parceldelivery_mobile/screens/welcome/employee_welcome.dart';

class AcceptedShippingRequestDetail extends StatefulWidget {
  const AcceptedShippingRequestDetail({required this.entity, super.key});

  final AcceptedShipRequest entity;

  @override
  State<AcceptedShippingRequestDetail> createState() =>
      _AcceptedShippingRequestDetailState();
}

class _AcceptedShippingRequestDetailState
    extends State<AcceptedShippingRequestDetail> {
  final MaterialStateProperty<Icon?> thumbIcon =
      MaterialStateProperty.resolveWith<Icon?>(
    (Set<MaterialState> states) {
      if (states.contains(MaterialState.selected)) {
        return const Icon(Icons.check);
      }
      return const Icon(Icons.close);
    },
  );
  AcceptedShipRequest? entity;

  @override
  void initState() {
    entity = widget.entity;
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final dateFormat = DateFormat('yyyy-MM-dd');
    return FrameScaffold(
      floatingActionButton: null,
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            const SizedBox(
              height: 15,
            ),
            Text(
              "#${entity?.id} kézbesítés",
              style: const TextStyle(
                fontSize: 22,
              ),
              textAlign: TextAlign.start,
            ),
            const SizedBox(
              height: 10,
            ),
            SizedBox(
              width: double.infinity,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.end,
                children: [
                  Text(
                    "Munkatárs neve: ${entity?.employeeName}",
                    style: const TextStyle(
                      fontSize: 15,
                    ),
                    textAlign: TextAlign.start,
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Text(
                    "Munkatárs email címe: ${entity?.employeeEmail}",
                    style: const TextStyle(
                      fontSize: 15,
                    ),
                    textAlign: TextAlign.end,
                  ),
                ],
              ),
            ),
            const SizedBox(
              height: 15,
            ),
            SizedBox(
              width: double.infinity,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text(
                    "Kézbesítéshez rendelt jármű adatai:",
                    style: TextStyle(
                      fontSize: 18,
                    ),
                    textAlign: TextAlign.start,
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 15.0),
                    child: Text(
                      "- Rendszám: ${entity?.vehicle.registrationNumber}",
                      style: const TextStyle(
                        fontSize: 15,
                      ),
                      textAlign: TextAlign.start,
                    ),
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 15.0),
                    child: Text(
                      "- Típus: ${entity?.vehicle.type}",
                      style: const TextStyle(
                        fontSize: 15,
                      ),
                      textAlign: TextAlign.end,
                    ),
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 15.0),
                    child: Text(
                      "- Ülések száma: ${entity?.vehicle.seatingCapacity} db",
                      style: const TextStyle(
                        fontSize: 15,
                      ),
                      textAlign: TextAlign.end,
                    ),
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 15.0),
                    child: Text(
                      "- Csomagtér mérete: ${entity?.vehicle.maxInternalSpaceX} x ${entity?.vehicle.maxInternalSpaceY} x ${entity?.vehicle.maxInternalSpaceZ} m",
                      style: const TextStyle(
                        fontSize: 15,
                      ),
                      textAlign: TextAlign.end,
                    ),
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 15.0),
                    child: Text(
                      "- Műszaki lejárta: ${dateFormat.format(entity?.vehicle.technicalInspectionExpirationDate ?? DateTime.now())}",
                      style: const TextStyle(
                        fontSize: 15,
                      ),
                      textAlign: TextAlign.end,
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(
              height: 15,
            ),
            SizedBox(
              width: double.infinity,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text(
                    "Csomagok:",
                    style: TextStyle(
                      fontSize: 18,
                    ),
                    textAlign: TextAlign.start,
                  ),
                  const SizedBox(
                    height: 5,
                  ),
                  ...(entity?.packages ?? []).map(
                    (e) {
                      return ListTile(
                        title: Text(
                          "${e.sizeX} x ${e.sizeY} x ${e.sizeZ} m, ${e.weight} kg",
                          style: const TextStyle(
                            fontSize: 15,
                          ),
                        ),
                        subtitle: Text(
                          e.isFragile ? "Törékeny" : "",
                          style: const TextStyle(
                            fontSize: 15,
                          ),
                        ),
                        trailing: Switch(
                          thumbIcon: thumbIcon,
                          value: entity?.readPackageIds.contains(e.id) ?? false,
                          onChanged: (bool value) {
                            setState(() {
                              if (value) {
                                List<String> readPackageIds = [
                                  ...entity?.readPackageIds ?? []
                                ];
                                readPackageIds.add(e.id);
                                entity = entity?.copyWith(
                                    readPackageIds: readPackageIds);
                              } else {
                                List<String> readPackageIds = [
                                  ...entity?.readPackageIds ?? []
                                ];
                                readPackageIds.removeWhere(
                                  (element) => element == e.id,
                                );
                                entity = entity?.copyWith(
                                    readPackageIds: readPackageIds);
                              }
                            });
                          },
                        ),
                      );
                    },
                  ),
                  const SizedBox(
                    height: 15,
                  ),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed: entity != null
                          ? () {
                              entity = entity?.copyWith(
                                  isAllPackageTaken: entity?.packages.length ==
                                      entity?.readPackageIds.length);
                              AcceptedShipRequestsApi.update(entity!);
                              Navigator.of(context)
                                  .pushNamed(WelcomeEmployee.routeName);
                            }
                          : null,
                      clipBehavior: Clip.hardEdge,
                      child: const Text('Mentés'),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
