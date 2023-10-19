import 'package:bloc/bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:meta/meta.dart';
import 'package:parceldelivery_mobile/api/currencies.api.dart';
import 'package:parceldelivery_mobile/models/currency.dart';
import 'package:parceldelivery_mobile/models/pagedresult.dart';

part 'currency_event.dart';
part 'currency_state.dart';
part 'currency_bloc.freezed.dart';
part 'currency_bloc.g.dart';

class CurrencyBloc extends Bloc<CurrencyEvent, CurrencyState> {
  CurrencyBloc() : super(const _Loading()) {
    on<_GetAll>((event, emit) async {
      try {
        final pagedData = await CurrenciesApi.get();
        emit(_Loaded(pagedData));
      } catch (e) {
        emit(const _Error("Hiba a lekérdezés során."));
      }
    });

    on<_Update>((event, emit) async {
      try {
        final result = await CurrenciesApi.update(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a módosítás során."));
      }
    });

    on<_Add>((event, emit) async {
      try {
        final result = await CurrenciesApi.add(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a hozzáadás során."));
      }
    });

    on<_Delete>((event, emit) async {
      try {
        final result = await CurrenciesApi.delete(event.entity);
        emit(_Modified(result));
      } catch (e) {
        emit(const _Error("Hiba a törlés során."));
      }
    });
  }
}
