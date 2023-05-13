import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { PagedResult } from 'src/app/models/PagedResult';
import { Observable, catchError, retry } from 'rxjs';
import { ShippingRequest } from 'src/app/models/ShippingRequest';
import { AcceptedShippingRequest } from 'src/app/models/AcceptedShippingRequest';

@Injectable({
  providedIn: 'root',
})
export class PackageService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlShippingRequestUrl = this.baseUrl + '/ShippingRequestDelivery';
  baseUrlAcceptedShippingRequestUrl = this.baseUrl + '/AcceptedShipRequest';

  getShippingRequests(
    pageSize: number,
    pageNumber: number
  ): Observable<PagedResult<ShippingRequest>> {
    return this.http
      .get<PagedResult<ShippingRequest>>(
        this.baseUrlShippingRequestUrl +
          `?&pageSize=${pageSize}&pageNumber=${pageNumber}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  getAcceptedShippingRequests(
    pageSize: number,
    pageNumber: number,
    byEmployeeId: boolean
  ): Observable<PagedResult<AcceptedShippingRequest>> {
    return byEmployeeId
      ? this.http
          .get<PagedResult<AcceptedShippingRequest>>(
            this.baseUrlAcceptedShippingRequestUrl +
              `/employee/${this.userId}?&pageSize=${pageSize}&pageNumber=${pageNumber}`,
            this.httpOptions
          )
          .pipe(retry(3), catchError(this.handleError))
      : this.http
          .get<PagedResult<AcceptedShippingRequest>>(
            this.baseUrlAcceptedShippingRequestUrl +
              `?&pageSize=${pageSize}&pageNumber=${pageNumber}`,
            this.httpOptions
          )
          .pipe(retry(3), catchError(this.handleError));
  }
}
