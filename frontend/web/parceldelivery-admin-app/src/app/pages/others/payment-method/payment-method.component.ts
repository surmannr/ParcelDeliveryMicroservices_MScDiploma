import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { PaymentOptionDto } from 'src/app/_dtos/payment-option-dto';
import { PaymentOptionFilter } from 'src/app/_filters/payment-option-filter';
import { PaymentMethodService } from 'src/app/apiservices/payment-method.service';
import { PaymentMethodEditComponent } from 'src/app/components/edit/payment-method-edit/payment-method-edit.component';
import { DeleteDialogSheetComponent } from 'src/app/dialogs/delete-dialog-sheet/delete-dialog-sheet.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-payment-method',
  templateUrl: './payment-method.component.html',
  styleUrls: ['./payment-method.component.css'],
})
export class PaymentMethodComponent implements OnInit, AfterViewInit {
  constructor(
    public paymentService: PaymentMethodService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private dialog: MatDialog
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  paymentOptions: PagedResult<PaymentOptionDto> | undefined;
  dataSource = new MatTableDataSource<PaymentOptionDto>(undefined);
  displayedColumns: string[] = ['id', 'name', 'other'];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: PaymentOptionFilter = new PaymentOptionFilter();

  get isLoading(): boolean {
    return this.paymentService.loading;
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
    this.paymentService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.paymentService.getPaymentOptions(this.filter).subscribe({
      next: (data: PagedResult<PaymentOptionDto>) => {
        this.paymentOptions = data;

        this.dataSource = new MatTableDataSource<PaymentOptionDto>(
          this.paymentOptions?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.paymentService.loading = false;
      },
    });
  }

  onDelete(id: number) {
    const dialog = this.bottomSheet.open(DeleteDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.paymentService.deletePaymentOption(id).subscribe({
          complete: () => {
            this.load();
            this.snackBar.open(
              'Sikeresen törölted a fizetési módot.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
          error: () => {
            this.snackBar.open(
              'Nem sikerült törölnöd a fizetési módot.',
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

  openModification(element: PaymentOptionDto | undefined) {
    const dialogRef = this.dialog.open(PaymentMethodEditComponent, {
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
