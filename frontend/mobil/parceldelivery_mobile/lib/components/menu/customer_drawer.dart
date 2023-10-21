import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/common/top_image_widget.dart';
import 'package:parceldelivery_mobile/components/menu/common_menu_parts.dart';
import 'package:parceldelivery_mobile/components/menu/drawer_tile.dart';
import 'package:parceldelivery_mobile/screens/shipping_request/shipping_request_add.dart';

class CustomerDrawer extends Drawer {
  const CustomerDrawer({super.key})
      : super(
          child: const Column(
            children: [
              SizedBox(
                height: 20,
              ),
              TopImageWidget(
                  imagePath: 'assets/images/drawerimage.png',
                  blendMode: BlendMode.color),
              DrawerTile(
                title: "Új kézbesítés feladása",
                navigateToRouteName: ShippingRequestAddScreen.routeName,
              ),
              CommonMenuParts()
            ],
          ),
        );
}
