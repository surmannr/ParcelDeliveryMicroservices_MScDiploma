import 'package:flutter/material.dart';

class DrawerTile extends StatelessWidget {
  const DrawerTile({
    required this.title,
    required this.navigateToRouteName,
    super.key,
  });

  final String title;
  final String navigateToRouteName;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Card(
        elevation: 7,
        child: ListTile(
          title: Text(
            title,
            style: const TextStyle(
              fontSize: 14,
              fontWeight: FontWeight.bold,
            ),
          ),
          onTap: () async {
            await Navigator.of(context)
                .pushReplacementNamed(navigateToRouteName);
          },
        ),
      ),
    );
  }
}
