import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PagedResult } from '../models/PagedResult';
import { ShippingRequestDto } from '../_dtos/shipping-request-dto';
import { ShippingRequestFilter } from '../_filters/shipping-request-filter';
import { AcceptedShippingRequestDto } from '../_dtos/accepted-shipping-request-dto';
import { AcceptedShippingRequestFilter } from '../_filters/accepted-shipping-request-filter';

@Injectable({
  providedIn: 'root',
})
export class ShippingService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlShippingRequestUrl = this.baseUrl + '/ShippingRequestDelivery';
  baseUrlAcceptedShippingRequestUrl = this.baseUrl + '/AcceptedShipRequest';

  getShippingRequests(
    filter: ShippingRequestFilter
  ): Observable<PagedResult<ShippingRequestDto>> {
    return this.http
      .get<PagedResult<ShippingRequestDto>>(
        this.baseUrlShippingRequestUrl + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  getAcceptedShippingRequests(
    filter: AcceptedShippingRequestFilter,
    byEmployeeId: boolean
  ): Observable<PagedResult<AcceptedShippingRequestDto>> {
    return byEmployeeId
      ? this.http
          .get<PagedResult<AcceptedShippingRequestDto>>(
            this.baseUrlAcceptedShippingRequestUrl +
              `/employee/${this.userId}` +
              `?${this.getFilterParams(filter)}`,
            this.httpOptions
          )
          .pipe(retry(3), catchError(this.handleError))
      : this.http
          .get<PagedResult<AcceptedShippingRequestDto>>(
            this.baseUrlAcceptedShippingRequestUrl +
              `?${this.getFilterParams(filter)}`,
            this.httpOptions
          )
          .pipe(retry(3), catchError(this.handleError));
  }

  editShippingRequest(
    shipReq: ShippingRequestDto
  ): Observable<ShippingRequestDto> {
    return this.http
      .put<ShippingRequestDto>(
        this.baseUrlShippingRequestUrl,
        shipReq,
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
