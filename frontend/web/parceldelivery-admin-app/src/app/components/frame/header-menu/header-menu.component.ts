import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-header-menu',
  templateUrl: './header-menu.component.html',
  styleUrls: ['./header-menu.component.scss'],
})
export class HeaderMenuComponent implements OnInit {
  constructor(public oauthService: OAuthService) {}

  login() {
    this.oauthService.initCodeFlow();
  }

  logout() {
    this.oauthService.logOut();
  }

  menuItemsLoggedIn: MenuItem[] = [];
  menuItemsLoggedOut: MenuItem[] = [];

  ngOnInit() {
    this.menuItemsLoggedIn = [
      {
        label: 'Munka',
        icon: 'pi pi-fw pi-file',
        items: [
          {
            label: 'Új ráfordítás',
            icon: 'pi pi-fw pi-plus',
            routerLink: 'add-working-days',
          },
          {
            label: 'Munkanapló',
            icon: 'pi pi-fw pi-list',
            routerLink: 'timesheet',
          },
        ],
      },
      {
        label: 'Jármű',
        icon: 'pi pi-fw pi-file',
        items: [
          {
            label: 'Új jármű',
            icon: 'pi pi-fw pi-plus',
            routerLink: 'add-new-vehicle',
          },
          {
            label: 'Járművek',
            icon: 'pi pi-fw pi-list',
            routerLink: 'vehicles',
          },
          {
            label: 'Járműhasználat',
            icon: 'pi pi-fw pi-list',
            routerLink: 'vehicleUsages',
          },
        ],
      },
      {
        label: 'Csomagok',
        icon: 'pi pi-fw pi-file',
        items: [
          {
            label: 'Feladott csomagok',
            icon: 'pi pi-fw pi-list',
            routerLink: 'shipping-requests',
          },
          {
            label: 'Futárok nyomonkövetése',
            icon: 'pi pi-fw pi-list',
            routerLink: 'accepted-shipping-requests',
          },
        ],
      },
      {
        label: 'Kijelentkezés',
        icon: 'pi pi-fw pi-sign-out',
        command: () => this.logout(),
      },
    ];

    this.menuItemsLoggedOut = [
      {
        label: 'Bejelentkezés',
        icon: 'pi pi-fw pi-sign-in',
        command: () => this.login(),
      },
    ];
  }
}
