import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { BaseService } from './base.service';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PagedResult } from '../models/PagedResult';
import { VehicleDto } from '../_dtos/vehicle-dto';
import { VehicleUsageDto } from '../_dtos/vehicle-usage-dto';
import { VehicleFilter } from '../_filters/vehicle-filter';
import { VehicleUsageFilter } from '../_filters/vehicle-usage-filter';
import { NewVehicleUsageDto } from '../_dtos/new-vehicle-usage-dto';

@Injectable({
  providedIn: 'root',
})
export class VehicleService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlVehicle = this.baseUrl + '/Vehicle';
  baseUrlVehicleUsage = this.baseUrl + '/VehicleUsage';

  getVehicles(filter: VehicleFilter): Observable<PagedResult<VehicleDto>> {
    return this.http
      .get<PagedResult<VehicleDto>>(
        this.baseUrlVehicle + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  getVehicleUsages(
    filter: VehicleUsageFilter
  ): Observable<PagedResult<VehicleUsageDto>> {
    return this.http
      .get<PagedResult<VehicleUsageDto>>(
        this.baseUrlVehicleUsage +
          `/employee/${this.userId}` +
          `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveVehicle(vehicle: VehicleDto): Observable<VehicleDto> {
    return this.http
      .post<VehicleDto>(this.baseUrlVehicle, vehicle, this.httpOptions)
      .pipe(
        tap((data) => {
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

  saveVehicleUsage(
    vehicleUsage: NewVehicleUsageDto
  ): Observable<NewVehicleUsageDto> {
    vehicleUsage.employeeId = this.userId;
    vehicleUsage.employeeEmail = this.employeeEmail;
    vehicleUsage.employeeName = this.employeeName;
    return this.http
      .post<NewVehicleUsageDto>(
        this.baseUrlVehicleUsage,
        vehicleUsage,
        this.httpOptions
      )
      .pipe(
        tap((data) => {
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deleteVehicleUsage(id: string) {
    return this.http
      .delete(this.baseUrlVehicleUsage + `/${id}`)
      .pipe(catchError(this.handleError));
  }
}
