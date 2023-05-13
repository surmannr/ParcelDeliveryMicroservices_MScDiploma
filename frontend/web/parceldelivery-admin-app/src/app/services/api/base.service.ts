import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  constructor(private oauth: OAuthService) {}

  protected baseUrl = environment.baseUrl;
  public loading = false;

  get userId() {
    const claims: any = jwt_decode(this.oauth.getAccessToken());
    return claims['sub'];
  }

  protected httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  protected handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
}
