import { Component, OnInit } from '@angular/core';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { TimesheetDto } from 'src/app/_dtos/timesheet-dto';
import { TimesheetFilter } from 'src/app/_filters/timesheet-filter';
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

  timesheets: PagedResult<TimesheetDto> | undefined;
  pageSize: number = 10;
  pageNumber: number = 1;

  filter: TimesheetFilter = new TimesheetFilter();

  ngOnInit(): void {
    this.load();
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
  }
  paging(event: any) {
    this.pageSize = event.rows;
    this.pageNumber = event.first / this.pageSize + 1;
    this.load();
  }

  load() {
    this.employeeService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.employeeService.getTimesheets(this.filter).subscribe({
      next: (data: PagedResult<TimesheetDto>) => (this.timesheets = data),
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
