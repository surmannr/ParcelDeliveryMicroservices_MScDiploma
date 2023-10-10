import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { BaseService } from './base.service';
import { TimesheetFilter } from '../_filters/timesheet-filter';
import { Observable, catchError, retry, tap } from 'rxjs';
import { TimesheetDto } from '../_dtos/timesheet-dto';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class TimesheetService extends BaseService {
  constructor(private http: HttpClient, private oauthService: OAuthService) {
    super(oauthService);
  }

  baseUrlTimesheet = this.baseUrl + '/Timesheet';

  getTimesheets(
    filter: TimesheetFilter
  ): Observable<PagedResult<TimesheetDto>> {
    filter.userId = this.userId;

    return this.http
      .get<PagedResult<TimesheetDto>>(
        this.baseUrlTimesheet + `?${this.getFilterParams(filter)}`,
        this.httpOptions
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  saveTimesheet(timesheet: TimesheetDto): Observable<TimesheetDto> {
    timesheet.userId = this.userId;
    return this.http
      .post<TimesheetDto>(this.baseUrlTimesheet, timesheet, this.httpOptions)
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
