import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/shipping_requests.api.dart';
import 'package:parceldelivery_mobile/constants.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/shipping_request.dart';
import 'package:shared_preferences/shared_preferences.dart';

part 'shipping_request_event.dart';
part 'shipping_request_state.dart';
part 'shipping_request_bloc.freezed.dart';
part 'shipping_request_bloc.g.dart';

class ShippingRequestBloc
    extends Bloc<ShippingRequestEvent, ShippingRequestState> {
  ShippingRequestBloc() : super(const _Loading()) {
    on<_GetAll>((event, emit) async {
      try {
        final preferences = await SharedPreferences.getInstance();
        final userId = preferences.getString(Constants.sharedPref.userIdTag);

        final pagedData = await ShippingRequestsApi.getByUserId(userId!);
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a lekérdezés során."));
      }
    });

    on<_Update>((event, emit) async {
      try {
        final result = await ShippingRequestsApi.update(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a módosítás során."));
      }
    });

    on<_Add>((event, emit) async {
      try {
        final result = await ShippingRequestsApi.add(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a hozzáadás során."));
      }
    });

    on<_Track>((event, emit) async {
      try {
        final result = await ShippingRequestsApi.track(event.id);

        PagedResult<ShippingRequest> pagedData = PagedResult(
            totalCount: 1,
            totalPages: 1,
            pageNumber: 1,
            pageSize: 1,
            data: [result]);
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a nyomkövetés során."));
      }
    });
  }
}
