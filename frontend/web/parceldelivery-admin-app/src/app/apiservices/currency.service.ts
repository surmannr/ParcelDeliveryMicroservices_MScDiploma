import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { CurrencyFilter } from '../_filters/currency-filter';
import { CurrencyDto } from '../_dtos/currency-dto';
import { PagedResult } from '../models/PagedResult';
import { Observable, catchError, retry, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlCurrency = this.baseUrl + '/Currency';

  getCurrencies(filter: CurrencyFilter): Observable<PagedResult<CurrencyDto>> {
    return this.http
      .get<PagedResult<CurrencyDto>>(
        this.baseUrlCurrency + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveCurrency(currency: CurrencyDto): Observable<CurrencyDto> {
    return this.http
      .post<CurrencyDto>(this.baseUrlCurrency, currency, this.httpOptions)
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deleteCurrency(id: number) {
    return this.http
      .delete(this.baseUrlCurrency + `/${id}`)
      .pipe(catchError(this.handleError));
  }

  editCurrency(currency: CurrencyDto): Observable<CurrencyDto> {
    return this.http
      .put<CurrencyDto>(this.baseUrlCurrency, currency, this.httpOptions)
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }
}
