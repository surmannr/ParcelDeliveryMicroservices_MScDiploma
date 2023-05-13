import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  constructor(private oauthService: OAuthService) {}

  login() {
    this.oauthService.initCodeFlow();
  }

  logout() {
    this.oauthService.logOut();
  }

  get givenName() {
    if (this.oauthService.hasValidAccessToken()) {
      const claims: any = jwt_decode(this.oauthService.getAccessToken());
      if (!claims) {
        return null;
      }
      return claims['name'];
    }
  }
}
