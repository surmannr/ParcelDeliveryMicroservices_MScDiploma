import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { PagedResult } from 'src/app/models/PagedResult';
import { ShippingRequest } from 'src/app/models/ShippingRequest';
import { PackageService } from 'src/app/services/api/package.service';

@Component({
  selector: 'app-shipping-request-list',
  templateUrl: './shipping-request-list.component.html',
  styleUrls: ['./shipping-request-list.component.scss'],
})
export class ShippingRequestListComponent implements OnInit {
  constructor(public packageService: PackageService) {}

  shippingRequests: PagedResult<ShippingRequest> | undefined;
  dialogVisible: boolean = false;
  selectedShippingRequest: ShippingRequest | undefined;

  pageSize: number = 10;
  pageNumber: number = 1;

  ngOnInit(): void {
    this.load();
  }
  paging(event: any) {
    this.pageSize = event.rows;
    this.pageNumber = event.first / this.pageSize + 1;
    this.load();
  }

  load() {
    this.packageService.loading = true;
    this.packageService
      .getShippingRequests(this.pageSize, this.pageNumber)
      .subscribe({
        next: (data: PagedResult<ShippingRequest>) =>
          (this.shippingRequests = data),
        error: (err) => console.error(err),
        complete: () => {
          this.packageService.loading = false;
        },
      });
  }

  clear(table: Table) {
    table.clear();
  }

  showDialog(id: string) {
    this.dialogVisible = true;
    this.selectedShippingRequest = this.shippingRequests?.data.filter(
      (x) => x.id === id
    )[0];
  }

  onDialog(open: boolean) {
    this.dialogVisible = open;
  }
}
