import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { TimesheetDto } from 'src/app/_dtos/timesheet-dto';
import { TimesheetFilter } from 'src/app/_filters/timesheet-filter';
import { TimesheetService } from 'src/app/apiservices/timesheet.service';
import { PagedResult } from 'src/app/models/PagedResult';
import { merge } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { DeleteDialogSheetComponent } from 'src/app/dialogs/delete-dialog-sheet/delete-dialog-sheet.component';

@Component({
  selector: 'app-timesheet',
  templateUrl: './timesheet.component.html',
  styleUrls: ['./timesheet.component.css'],
})
export class TimesheetComponent implements OnInit, AfterViewInit {
  constructor(
    public timesheetService: TimesheetService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  timesheets: PagedResult<TimesheetDto> | undefined;
  dataSource = new MatTableDataSource<TimesheetDto>(undefined);
  displayedColumns: string[] = ['dateFrom', 'dateTo', 'days', 'note', 'id'];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: TimesheetFilter = new TimesheetFilter();

  get isLoading(): boolean {
    return this.timesheetService.loading;
  }

  ngOnInit(): void {
    this.load();
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;

    this.paginator._intl.itemsPerPageLabel = 'Egy oldalon lévő elemek száma:';

    this.paginator.page.subscribe((pageData) => {
      this.paging(pageData.pageSize, pageData.pageIndex + 1);
    });

    this.sort.sortChange.subscribe((sortData) => {
      this.paginator.pageIndex = 0;
      this.pageNumber = 1;
      this.filter.orderBy = sortData.active;
      this.filter.orderAscending = sortData.direction === 'asc';
    });

    merge(this.sort.sortChange, this.paginator.page).subscribe((data) => {
      this.load();
    });
  }

  paging(pagesize: number, pagenumber: number) {
    this.pageSize = pagesize;
    this.pageNumber = pagenumber;
    this.load();
  }

  load() {
    this.timesheetService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.timesheetService.getTimesheets(this.filter).subscribe({
      next: (data: PagedResult<TimesheetDto>) => {
        this.timesheets = data;

        this.dataSource = new MatTableDataSource<TimesheetDto>(
          this.timesheets?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.timesheetService.loading = false;
      },
    });
  }

  onDelete(id: string) {
    const dialog = this.bottomSheet.open(DeleteDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.timesheetService.deleteTimesheet(id).subscribe({
          complete: () => {
            this.load();
            this.snackBar.open('Sikeresen törölted a munkahetet.', 'Értem', {
              duration: 3000,
            });
          },
          error: () => {
            this.snackBar.open('Nem sikerült törölnöd a munkahetet.', 'Értem', {
              duration: 3000,
            });
          },
        });
      }
    });
  }
}
