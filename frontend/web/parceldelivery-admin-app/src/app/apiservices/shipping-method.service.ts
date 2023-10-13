import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { ShippingOptionFilter } from '../_filters/shipping-option-filter';
import { ShippingOptionDto } from '../_dtos/shipping-option-dto';
import { PagedResult } from '../models/PagedResult';
import { Observable, catchError, retry, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ShippingMethodService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlShippingOption = this.baseUrl + '/ShippingOption';

  getShippingOptions(
    filter: ShippingOptionFilter
  ): Observable<PagedResult<ShippingOptionDto>> {
    return this.http
      .get<PagedResult<ShippingOptionDto>>(
        this.baseUrlShippingOption + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveShippingOption(
    shippingOption: ShippingOptionDto
  ): Observable<ShippingOptionDto> {
    return this.http
      .post<ShippingOptionDto>(
        this.baseUrlShippingOption,
        shippingOption,
        this.httpOptions
      )
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deleteShippingOption(id: number) {
    return this.http
      .delete(this.baseUrlShippingOption + `/${id}`)
      .pipe(catchError(this.handleError));
  }

  editShippingOption(
    shippingOption: ShippingOptionDto
  ): Observable<ShippingOptionDto> {
    return this.http
      .put<ShippingOptionDto>(
        this.baseUrlShippingOption,
        shippingOption,
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
