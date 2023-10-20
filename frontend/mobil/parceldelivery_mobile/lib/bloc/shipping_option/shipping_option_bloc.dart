import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/shipping_options.api.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/shipping_option.dart';

part 'shipping_option_event.dart';
part 'shipping_option_state.dart';
part 'shipping_option_bloc.freezed.dart';
part 'shipping_option_bloc.g.dart';

class ShippingOptionBloc
    extends Bloc<ShippingOptionEvent, ShippingOptionState> {
  ShippingOptionBloc() : super(const _Loading()) {
    on<_GetAll>((event, emit) async {
      try {
        final pagedData = await ShippingOptionsApi.get();
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a lekérdezés során."));
      }
    });

    on<_Update>((event, emit) async {
      try {
        final result = await ShippingOptionsApi.update(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a módosítás során."));
      }
    });

    on<_Add>((event, emit) async {
      try {
        final result = await ShippingOptionsApi.add(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a hozzáadás során."));
      }
    });

    on<_Delete>((event, emit) async {
      try {
        final result = await ShippingOptionsApi.delete(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a törlés során."));
      }
    });
  }
}
