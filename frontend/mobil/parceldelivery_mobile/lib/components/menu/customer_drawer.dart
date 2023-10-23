import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/common/top_image_widget.dart';
import 'package:parceldelivery_mobile/components/menu/common_menu_parts.dart';
import 'package:parceldelivery_mobile/components/menu/drawer_tile.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/shipping_request_add.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/shipping_request_list.dart';

class CustomerDrawer extends Drawer {
  const CustomerDrawer({super.key})
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
                  title: "Csomagfeladásaim",
                  navigateToRouteName: ShippingRequestListScreen.routeName,
                ),
                DrawerTile(
                  title: "Csomagok feladása",
                  navigateToRouteName: ShippingRequestAddScreen.routeName,
                ),
                CommonMenuParts()
              ],
            ),
          ),
        );
}
