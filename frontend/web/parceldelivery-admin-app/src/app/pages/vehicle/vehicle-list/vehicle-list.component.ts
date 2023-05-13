import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { PagedResult } from 'src/app/models/PagedResult';
import { Vehicle } from 'src/app/models/Vehicle';
import { VehicleService } from 'src/app/services/api/vehicle.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss'],
})
export class VehicleListComponent implements OnInit {
  constructor(public vehicleService: VehicleService) {}

  vehicles: PagedResult<Vehicle> | undefined;

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
    this.vehicleService.getVehicles(this.pageSize, this.pageNumber).subscribe({
      next: (data: PagedResult<Vehicle>) => (this.vehicles = data),
      error: (err) => console.error(err),
      complete: () => {
        this.vehicleService.loading = false;
      },
    });
  }

  onDelete(id: string) {
    this.vehicleService.deleteVehicle(id).subscribe({
      error: (err) => console.error(err),
      complete: () => {
        this.load();
      },
    });
  }
}
