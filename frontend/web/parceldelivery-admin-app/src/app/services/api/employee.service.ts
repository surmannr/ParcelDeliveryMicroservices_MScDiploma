import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Timesheet } from 'src/app/models/Timesheet';
import { Observable, catchError, retry, tap } from 'rxjs';
import { PagedResult } from 'src/app/models/PagedResult';
import { OAuthService } from 'angular-oauth2-oidc';
import { TimesheetDto } from 'src/app/_dtos/timesheet-dto';
import { TimesheetFilter } from 'src/app/_filters/timesheet-filter';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService extends BaseService {
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
