import { Component, OnInit } from '@angular/core';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { PagedResult } from 'src/app/models/PagedResult';
import { Timesheet } from 'src/app/models/Timesheet';
import { EmployeeService } from 'src/app/services/api/employee.service';

@Component({
  selector: 'app-timesheet',
  templateUrl: './timesheet.component.html',
  styleUrls: ['./timesheet.component.scss'],
})
export class TimesheetComponent implements OnInit {
  constructor(public employeeService: EmployeeService) {}

  timesheets: PagedResult<Timesheet> | undefined;
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
    this.employeeService.loading = true;
    this.employeeService
      .getTimesheets(this.pageSize, this.pageNumber)
      .subscribe({
        next: (data: PagedResult<Timesheet>) => (this.timesheets = data),
        error: (err) => console.error(err),
        complete: () => {
          this.employeeService.loading = false;
        },
      });
  }

  onDelete(id: string) {
    this.employeeService.deleteTimesheet(id).subscribe({
      error: (err) => console.error(err),
      complete: () => {
        this.load();
      },
    });
  }

  clear(table: Table) {
    table.clear();
  }
}
