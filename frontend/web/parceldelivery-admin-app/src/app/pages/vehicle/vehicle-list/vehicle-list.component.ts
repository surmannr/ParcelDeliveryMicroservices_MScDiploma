import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { Vehicle } from 'src/app/models/Vehicle';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss'],
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] = [];

  clear(table: Table) {
    table.clear();
  }

  ngOnInit(): void {
    this.vehicles = [
      {
        id: 'hee',
        registrationNumber: 'ABC-123',
        type: 'Suzuki',
        year: 2014,
        technicalInspectionExpirationDate: new Date(),
        seatingCapacity: 5,
        maxInternalSpaceX: 2.2,
        maxInternalSpaceY: 3.5,
        maxInternalSpaceZ: 6.3,
      },
      {
        id: 'hee',
        registrationNumber: 'DFG-123',
        type: 'Ford',
        year: 2018,
        technicalInspectionExpirationDate: new Date(),
        seatingCapacity: 4,
        maxInternalSpaceX: 2.2,
        maxInternalSpaceY: 3.5,
        maxInternalSpaceZ: 6.3,
      },
      {
        id: 'hee',
        registrationNumber: 'HRE-123',
        type: 'Bugatti',
        year: 2022,
        technicalInspectionExpirationDate: new Date(),
        seatingCapacity: 5,
        maxInternalSpaceX: 2.2,
        maxInternalSpaceY: 3.5,
        maxInternalSpaceZ: 6.3,
      },
    ];
  }
}
