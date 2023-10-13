import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { CurrencyDto } from 'src/app/_dtos/currency-dto';
import { CurrencyFilter } from 'src/app/_filters/currency-filter';
import { CurrencyService } from 'src/app/apiservices/currency.service';
import { CurrencyEditComponent } from 'src/app/components/edit/currency-edit/currency-edit.component';
import { DeleteDialogSheetComponent } from 'src/app/dialogs/delete-dialog-sheet/delete-dialog-sheet.component';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css'],
})
export class CurrencyComponent implements OnInit, AfterViewInit {
  constructor(
    public currencyService: CurrencyService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private dialog: MatDialog
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  currencies: PagedResult<CurrencyDto> | undefined;
  dataSource = new MatTableDataSource<CurrencyDto>(undefined);
  displayedColumns: string[] = ['id', 'name', 'other'];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: CurrencyFilter = new CurrencyFilter();

  get isLoading(): boolean {
    return this.currencyService.loading;
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
    this.currencyService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.currencyService.getCurrencies(this.filter).subscribe({
      next: (data: PagedResult<CurrencyDto>) => {
        this.currencies = data;

        this.dataSource = new MatTableDataSource<CurrencyDto>(
          this.currencies?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.currencyService.loading = false;
      },
    });
  }

  onDelete(id: number) {
    const dialog = this.bottomSheet.open(DeleteDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.currencyService.deleteCurrency(id).subscribe({
          complete: () => {
            this.load();
            this.snackBar.open('Sikeresen törölted a pénznemet.', 'Értem', {
              duration: 3000,
            });
          },
          error: () => {
            this.snackBar.open('Nem sikerült törölnöd a pénznemet.', 'Értem', {
              duration: 3000,
            });
          },
        });
      }
    });
  }

  openModification(element: CurrencyDto | undefined) {
    const dialogRef = this.dialog.open(CurrencyEditComponent, {
      data: { element: element },
      restoreFocus: false,
    });

    dialogRef.componentInstance.save.subscribe((res) => {
      this.load();
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.load();
    });
  }
}
