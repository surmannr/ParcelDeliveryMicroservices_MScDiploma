import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Timesheet } from 'src/app/models/Timesheet';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PagedResult } from 'src/app/models/PagedResult';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlTimesheet = this.baseUrl + '/Timesheet';

  getTimesheets(
    pageSize: number,
    pageNumber: number
  ): Observable<PagedResult<Timesheet>> {
    return this.http
      .get<PagedResult<Timesheet>>(
        this.baseUrlTimesheet +
          `?userId=${this.userId}&pageSize=${pageSize}&pageNumber=${pageNumber}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveTimesheet(timesheet: Timesheet): Observable<Timesheet> {
    timesheet.userId = this.userId;
    return this.http
      .post<Timesheet>(this.baseUrlTimesheet, timesheet, this.httpOptions)
      .pipe(
        tap((data) => {
          console.log(data);
          return data;
        }),
        catchError(this.handleError)
      );
  }

  deleteTimesheet(id: string) {
    return this.http
      .delete(this.baseUrlTimesheet + `/${id}`)
      .pipe(catchError(this.handleError));
  }
}
