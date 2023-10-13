import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { PaymentOptionFilter } from '../_filters/payment-option-filter';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PaymentOptionDto } from '../_dtos/payment-option-dto';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class PaymentMethodService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlPaymentOption = this.baseUrl + '/PaymentOption';

  getPaymentOptions(
    filter: PaymentOptionFilter
  ): Observable<PagedResult<PaymentOptionDto>> {
    return this.http
      .get<PagedResult<PaymentOptionDto>>(
        this.baseUrlPaymentOption + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  savePaymentOption(
    paymentOption: PaymentOptionDto
  ): Observable<PaymentOptionDto> {
    return this.http
      .post<PaymentOptionDto>(
        this.baseUrlPaymentOption,
        paymentOption,
        this.httpOptions
      )
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deletePaymentOption(id: number) {
    return this.http
      .delete(this.baseUrlPaymentOption + `/${id}`)
      .pipe(catchError(this.handleError));
  }

  editPaymentOption(
    paymentOption: PaymentOptionDto
  ): Observable<PaymentOptionDto> {
    return this.http
      .put<PaymentOptionDto>(
        this.baseUrlPaymentOption,
        paymentOption,
        this.httpOptions
      )
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }
}
