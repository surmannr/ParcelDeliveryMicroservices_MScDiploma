import 'package:flex_color_scheme/flex_color_scheme.dart';
import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/components/menu/drawer_tile.dart';
import 'package:parceldelivery_mobile/components/menu/theme_switch_button.dart';
import 'package:parceldelivery_mobile/main.dart';
import 'package:parceldelivery_mobile/screens/currency/currency_list.dart';

class CommonMenuParts extends StatefulWidget {
  const CommonMenuParts({
    super.key,
  });

  @override
  State<CommonMenuParts> createState() => _CommonMenuPartsState();
}

class _CommonMenuPartsState extends State<CommonMenuParts> {
  @override
  Widget build(BuildContext context) {
    final ThemeData theme = Theme.of(context);
    final bool isDark = theme.brightness == Brightness.dark;

    final myApp = MyApp.of(context);

    return Column(
      children: [
        const SizedBox(
          height: 20,
        ),
        const DrawerTile(
          title: "Valuták",
          navigateToRouteName: CurrencyListScreen.routeName,
        ),
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Card(
            elevation: 7,
            child: ListTile(
              contentPadding: EdgeInsets.zero,
              title: const Padding(
                padding: EdgeInsets.only(left: 15.0),
                child: Text('Theme mode'),
              ),
              subtitle: Padding(
                padding: const EdgeInsets.only(left: 15.0),
                child: Text('Theme '
                    '${myApp.themeMode.toString().dotTail}'),
              ),
              trailing: Padding(
                padding: const EdgeInsets.only(right: 15.0),
                child: ThemeSwitchButton(
                  themeMode: myApp.themeMode,
                  onChanged: myApp.changeTheme,
                ),
              ),
              onTap: () {
                if (isDark) {
                  myApp.changeTheme(ThemeMode.light);
                } else {
                  myApp.changeTheme(ThemeMode.dark);
                }
              },
            ),
          ),
        ),
      ],
    );
  }
}
