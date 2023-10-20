import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/accepted_ship_requests.api.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/accepted_ship_request.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:shared_preferences/shared_preferences.dart';

part 'accepted_ship_request_event.dart';
part 'accepted_ship_request_state.dart';
part 'accepted_ship_request_bloc.freezed.dart';
part 'accepted_ship_request_bloc.g.dart';

class AcceptedShipRequestBloc
    extends Bloc<AcceptedShipRequestEvent, AcceptedShipRequestState> {
  AcceptedShipRequestBloc() : super(const _Loading()) {
    on<AcceptedShipRequestEvent>((event, emit) {
      on<_GetAll>((event, emit) async {
        try {
          final preferences = await SharedPreferences.getInstance();
          final userId = preferences.getString(Constants.sharedPref.userIdTag);

          final pagedData =
              await AcceptedShipRequestsApi.getByEmployeeId(userId!);
          emit(_Loaded(pagedData));
        } catch (e) {
          emit(const _Error("Hiba a lekérdezés során."));
        }
      });

      on<_Update>((event, emit) async {
        try {
          final result = await AcceptedShipRequestsApi.update(event.entity);
          emit(_Modified(result));
        } catch (e) {
          emit(const _Error("Hiba a módosítás során."));
        }
      });
    });
  }
}
