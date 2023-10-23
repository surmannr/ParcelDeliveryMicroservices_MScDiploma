import 'package:flutter/material.dart';
import 'package:parceldelivery_mobile/frame.dart';

class TrackDetailScreen extends StatefulWidget {
  const TrackDetailScreen({this.id, super.key});

  static const routeName = '/track';
  final String? id;

  @override
  State<TrackDetailScreen> createState() => _TrackDetailScreenState();
}

class _TrackDetailScreenState extends State<TrackDetailScreen> {
  String? trackId;

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
