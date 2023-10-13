import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { ShippingOptionDto } from 'src/app/_dtos/shipping-option-dto';
import { ShippingOptionFilter } from 'src/app/_filters/shipping-option-filter';
import { ShippingMethodService } from 'src/app/apiservices/shipping-method.service';
import { ShippingMethodEditComponent } from 'src/app/components/edit/shipping-method-edit/shipping-method-edit.component';
import { DeleteDialogSheetComponent } from 'src/app/dialogs/delete-dialog-sheet/delete-dialog-sheet.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-shipping-method',
  templateUrl: './shipping-method.component.html',
  styleUrls: ['./shipping-method.component.css'],
})
export class ShippingMethodComponent implements OnInit, AfterViewInit {
  constructor(
    public shippingService: ShippingMethodService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private dialog: MatDialog
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  shippingOptions: PagedResult<ShippingOptionDto> | undefined;
  dataSource = new MatTableDataSource<ShippingOptionDto>(undefined);
  displayedColumns: string[] = ['id', 'name', 'price', 'other'];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: ShippingOptionFilter = new ShippingOptionFilter();

  get isLoading(): boolean {
    return this.shippingService.loading;
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
    this.shippingService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.shippingService.getShippingOptions(this.filter).subscribe({
      next: (data: PagedResult<ShippingOptionDto>) => {
        this.shippingOptions = data;

        this.dataSource = new MatTableDataSource<ShippingOptionDto>(
          this.shippingOptions?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.shippingService.loading = false;
      },
    });
  }

  onDelete(id: number) {
    const dialog = this.bottomSheet.open(DeleteDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.shippingService.deleteShippingOption(id).subscribe({
          complete: () => {
            this.load();
            this.snackBar.open(
              'Sikeresen törölted a szállítási módot.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
          error: () => {
            this.snackBar.open(
              'Nem sikerült törölnöd a szállítási módot.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
        });
      }
    });
  }

  openModification(element: ShippingOptionDto | undefined) {
    const dialogRef = this.dialog.open(ShippingMethodEditComponent, {
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
