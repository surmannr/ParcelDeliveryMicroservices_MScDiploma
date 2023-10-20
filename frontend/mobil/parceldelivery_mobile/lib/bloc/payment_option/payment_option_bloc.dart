import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/payment_options.api.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';
import 'package:parceldelivery_mobile/models/payment_option.dart';

part 'payment_option_event.dart';
part 'payment_option_state.dart';
part 'payment_option_bloc.freezed.dart';
part 'payment_option_bloc.g.dart';

class PaymentOptionBloc extends Bloc<PaymentOptionEvent, PaymentOptionState> {
  PaymentOptionBloc() : super(const _Loading()) {
    on<_GetAll>((event, emit) async {
      try {
        final pagedData = await PaymentOptionsApi.get();
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a lekérdezés során."));
      }
    });

    on<_Update>((event, emit) async {
      try {
        final result = await PaymentOptionsApi.update(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a módosítás során."));
      }
    });

    on<_Add>((event, emit) async {
      try {
        final result = await PaymentOptionsApi.add(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a hozzáadás során."));
      }
    });

    on<_Delete>((event, emit) async {
      try {
        final result = await PaymentOptionsApi.delete(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a törlés során."));
      }
    });
  }
}
