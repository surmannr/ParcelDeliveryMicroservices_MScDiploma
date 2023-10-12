import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { ShippingRequestDto } from 'src/app/_dtos/shipping-request-dto';
import { Status } from 'src/app/_dtos/status';
import { ShippingRequestFilter } from 'src/app/_filters/shipping-request-filter';
import { ShippingService } from 'src/app/apiservices/shipping.service';
import { BillingsComponent } from 'src/app/dialogs/billings/billings.component';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';
import { ShippingPacksComponent } from 'src/app/dialogs/shipping-packs/shipping-packs.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-shipping-request-list',
  templateUrl: './shipping-request-list.component.html',
  styleUrls: ['./shipping-request-list.component.css'],
})
export class ShippingRequestListComponent implements OnInit, AfterViewInit {
  constructor(
    public shippingService: ShippingService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private dialog: MatDialog
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  shippingRequests: PagedResult<ShippingRequestDto> | undefined;
  dataSource = new MatTableDataSource<ShippingRequestDto>(undefined);
  displayedColumns: string[] = [
    'id',
    'name',
    'addressFrom',
    'addressTo',
    'isExpress',
    'isFinished',
    'status',
    'paymentOption',
    'shippingOption',
    'billing',
    'packages',
  ];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: ShippingRequestFilter = new ShippingRequestFilter();

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
    this.shippingService.getShippingRequests(this.filter).subscribe({
      next: (data: PagedResult<ShippingRequestDto>) => {
        this.shippingRequests = data;

        this.dataSource = new MatTableDataSource<ShippingRequestDto>(
          this.shippingRequests?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.shippingService.loading = false;
      },
    });
  }

  openBilling(element: ShippingRequestDto) {
    const dialogRef = this.dialog.open(BillingsComponent, {
      data: { billing: element.billing },
    });
  }

  openPackages(element: ShippingRequestDto) {
    const dialogRef = this.dialog.open(ShippingPacksComponent, {
      data: { packages: element.packages },
    });
  }

  editStatus(element: ShippingRequestDto, status: Status) {
    element.status = status;

    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.shippingService.editShippingRequest(element).subscribe({
          next: () => {},
          error: () => {
            this.snackBar.open(
              'Nem sikerült módosítanod a státuszt.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
          complete: () => {
            this.snackBar.open('Sikeresen módosítottad a státuszt.', 'Értem', {
              duration: 3000,
            });
            this.load();
          },
        });
      }
    });
  }
}
