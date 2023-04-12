import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { Timesheet } from 'src/app/models/Timesheet';

@Component({
  selector: 'app-timesheet',
  templateUrl: './timesheet.component.html',
  styleUrls: ['./timesheet.component.scss'],
})
export class TimesheetComponent implements OnInit {
  timesheets: Timesheet[] = [];

  ngOnInit(): void {
    this.timesheets = [
      {
        dateFrom: new Date(2023, 3, 10),
        dateTo: new Date(2023, 3, 17),
        id: 'a',
        days: [0, 1, 2, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 18),
        dateTo: new Date(2023, 3, 25),
        id: 'a',
        days: [3, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 26),
        dateTo: new Date(2023, 4, 3),
        id: 'a',
        days: [4, 6],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 4, 4),
        dateTo: new Date(2023, 4, 11),
        id: 'a',
        days: [0, 1],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 10),
        dateTo: new Date(2023, 3, 17),
        id: 'a',
        days: [0, 1, 2, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 18),
        dateTo: new Date(2023, 3, 25),
        id: 'a',
        days: [3, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 26),
        dateTo: new Date(2023, 4, 3),
        id: 'a',
        days: [4, 6],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 4, 4),
        dateTo: new Date(2023, 4, 11),
        id: 'a',
        days: [0, 1],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 10),
        dateTo: new Date(2023, 3, 17),
        id: 'a',
        days: [0, 1, 2, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 18),
        dateTo: new Date(2023, 3, 25),
        id: 'a',
        days: [3, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 26),
        dateTo: new Date(2023, 4, 3),
        id: 'a',
        days: [4, 6],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 4, 4),
        dateTo: new Date(2023, 4, 11),
        id: 'a',
        days: [0, 1],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 10),
        dateTo: new Date(2023, 3, 17),
        id: 'a',
        days: [0, 1, 2, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 18),
        dateTo: new Date(2023, 3, 25),
        id: 'a',
        days: [3, 5],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 3, 26),
        dateTo: new Date(2023, 4, 3),
        id: 'a',
        days: [4, 6],
        note: 'hello',
        userId: 'me',
      },
      {
        dateFrom: new Date(2023, 4, 4),
        dateTo: new Date(2023, 4, 11),
        id: 'a',
        days: [0, 1],
        note: 'hello',
        userId: 'me',
      },
    ];
  }

  clear(table: Table) {
    table.clear();
  }
}
