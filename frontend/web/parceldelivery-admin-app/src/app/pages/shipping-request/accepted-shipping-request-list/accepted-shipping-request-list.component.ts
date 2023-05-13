import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { AcceptedShippingRequest } from 'src/app/models/AcceptedShippingRequest';
import { PagedResult } from 'src/app/models/PagedResult';
import { ShippingRequest } from 'src/app/models/ShippingRequest';
import { PackageService } from 'src/app/services/api/package.service';

@Component({
  selector: 'app-accepted-shipping-request-list',
  templateUrl: './accepted-shipping-request-list.component.html',
  styleUrls: ['./accepted-shipping-request-list.component.scss'],
})
export class AcceptedShippingRequestListComponent implements OnInit {
  constructor(public packageService: PackageService) {}

  acceptedShippingRequests: PagedResult<AcceptedShippingRequest> | undefined;
  dialogVisible: boolean = false;
  selectedShippingRequest: ShippingRequest | undefined;

  pageSize: number = 10;
  pageNumber: number = 1;
  byEmployeeId: boolean = false;

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
      .getAcceptedShippingRequests(
        this.pageSize,
        this.pageNumber,
        this.byEmployeeId
      )
      .subscribe({
        next: (data: PagedResult<AcceptedShippingRequest>) =>
          (this.acceptedShippingRequests = data),
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
    this.selectedShippingRequest = this.acceptedShippingRequests?.data.filter(
      (x) => x.id === id
    )[0].shipping;
  }

  onDialog(open: boolean) {
    this.dialogVisible = open;
  }
}
