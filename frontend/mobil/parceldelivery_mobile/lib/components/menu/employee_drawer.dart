import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/common/top_image_widget.dart';
import 'package:parceldelivery_mobile/components/menu/common_menu_parts.dart';
import 'package:parceldelivery_mobile/components/menu/drawer_tile.dart';
import 'package:parceldelivery_mobile/screens/accepted_shipping_request/accepted_shipping_request_list.dart';
import 'package:parceldelivery_mobile/screens/vehicle_usage/vehicle_usage_list.dart';

class EmployeeDrawer extends Drawer {
  const EmployeeDrawer({super.key})
      : super(
          child: const SingleChildScrollView(
            child: Column(
              children: [
                SizedBox(
                  height: 20,
                ),
                TopImageWidget(
                    imagePath: 'assets/images/drawerimage.png',
                    blendMode: BlendMode.color),
                DrawerTile(
                  title: "Jármű használataim",
                  navigateToRouteName: VehicleUsageListScreen.routeName,
                ),
                DrawerTile(
                  title: "Hozzám rendelt csomagfeladások",
                  navigateToRouteName:
                      AcceptedShippingRequestListScreen.routeName,
                ),
                CommonMenuParts()
              ],
            ),
          ),
        );
}
