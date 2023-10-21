import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/frame.dart';

class TrackDetailScreen extends StatefulWidget {
  const TrackDetailScreen({super.key});

  static const routeName = '/track';

  @override
  State<TrackDetailScreen> createState() => _TrackDetailScreenState();
}

class _TrackDetailScreenState extends State<TrackDetailScreen> {
  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return const FrameScaffold(
      floatingActionButton: null,
      child: Column(
        children: [],
      ),
    );
  }
}
