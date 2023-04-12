import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-header-menu',
  templateUrl: './header-menu.component.html',
  styleUrls: ['./header-menu.component.scss'],
})
export class HeaderMenuComponent implements OnInit {
  menuItems: MenuItem[] = [];

  ngOnInit() {
    this.menuItems = [
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
    ];
  }
}
