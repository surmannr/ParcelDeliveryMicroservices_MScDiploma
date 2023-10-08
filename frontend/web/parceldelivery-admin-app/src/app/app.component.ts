import { Component } from '@angular/core';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { authCodeFlowConfig } from './auth/auth_config';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ParcelDelivery Admin Page';

  constructor(private oauthService: OAuthService) {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();

    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }
}
