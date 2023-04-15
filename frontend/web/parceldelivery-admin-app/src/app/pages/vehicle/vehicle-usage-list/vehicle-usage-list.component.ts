import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { VehicleUsage } from 'src/app/models/VehicleUsage';

@Component({
  selector: 'app-vehicle-usage-list',
  templateUrl: './vehicle-usage-list.component.html',
  styleUrls: ['./vehicle-usage-list.component.scss'],
})
export class VehicleUsageListComponent implements OnInit {
  vehicleUsages: VehicleUsage[] = [];

  clear(table: Table) {
    table.clear();
  }

  ngOnInit(): void {
    this.vehicleUsages = [
      {
        id: 'hee',
        dateFrom: new Date(2023, 3, 14),
        dateTo: new Date(2023, 3, 21),
        employeeId: 'vid',
        employeeName: 'Futár Ferdinánd',
        note: 'nooote',
        vehicle: {
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
      },
    ];
  }
}
