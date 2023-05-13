import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { PagedResult } from 'src/app/models/PagedResult';
import { VehicleUsage } from 'src/app/models/VehicleUsage';
import { VehicleService } from 'src/app/services/api/vehicle.service';

@Component({
  selector: 'app-vehicle-usage-list',
  templateUrl: './vehicle-usage-list.component.html',
  styleUrls: ['./vehicle-usage-list.component.scss'],
})
export class VehicleUsageListComponent implements OnInit {
  constructor(public vehicleService: VehicleService) {}

  vehicleUsages: PagedResult<VehicleUsage> | undefined;

  clear(table: Table) {
    table.clear();
  }

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
    this.vehicleService.loading = true;
    this.vehicleService
      .getVehicleUsages(this.pageSize, this.pageNumber)
      .subscribe({
        next: (data: PagedResult<VehicleUsage>) => (this.vehicleUsages = data),
        error: (err) => console.error(err),
        complete: () => {
          this.vehicleService.loading = false;
        },
      });
  }
}
