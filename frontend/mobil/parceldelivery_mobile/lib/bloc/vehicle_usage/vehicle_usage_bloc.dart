import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/vehicle_usages.api.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/vehicle_usage.dart';
import 'package:shared_preferences/shared_preferences.dart';

part 'vehicle_usage_event.dart';
part 'vehicle_usage_state.dart';
part 'vehicle_usage_bloc.freezed.dart';
part 'vehicle_usage_bloc.g.dart';

class VehicleUsageBloc extends Bloc<VehicleUsageEvent, VehicleUsageState> {
  VehicleUsageBloc() : super(const _Loading()) {
    on<_GetAll>((event, emit) async {
      try {
        final preferences = await SharedPreferences.getInstance();
        final userId = preferences.getString(Constants.sharedPref.userIdTag);

        final pagedData = await VehicleUsagesApi.getByEmployeeId(userId!);
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a lekérdezés során."));
      }
    });
  }
}
