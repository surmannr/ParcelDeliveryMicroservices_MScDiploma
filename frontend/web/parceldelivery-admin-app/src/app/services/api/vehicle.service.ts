import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PagedResult } from 'src/app/models/PagedResult';
import { Vehicle } from 'src/app/models/Vehicle';
import { VehicleUsage } from 'src/app/models/VehicleUsage';

@Injectable({
  providedIn: 'root',
})
export class VehicleService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlVehicle = this.baseUrl + '/Vehicle';
  baseUrlVehicleUsage = this.baseUrl + '/VehicleUsage';

  getVehicles(
    pageSize: number,
    pageNumber: number
  ): Observable<PagedResult<Vehicle>> {
    return this.http
      .get<PagedResult<Vehicle>>(
        this.baseUrlVehicle + `?&pageSize=${pageSize}&pageNumber=${pageNumber}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  getVehicleUsages(
    pageSize: number,
    pageNumber: number
  ): Observable<PagedResult<VehicleUsage>> {
    return this.http
      .get<PagedResult<VehicleUsage>>(
        this.baseUrlVehicleUsage +
          `/employee/${this.userId}?&pageSize=${pageSize}&pageNumber=${pageNumber}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.http
      .post<Vehicle>(this.baseUrlVehicle, vehicle, this.httpOptions)
      .pipe(
        tap((data) => {
          console.log(data);
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deleteVehicle(id: string) {
    return this.http
      .delete(this.baseUrlVehicle + `/${id}`)
      .pipe(catchError(this.handleError));
  }
}
