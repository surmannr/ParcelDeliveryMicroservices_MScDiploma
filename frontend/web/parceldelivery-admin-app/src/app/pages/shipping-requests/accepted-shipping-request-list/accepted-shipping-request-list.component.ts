import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { AcceptedShippingRequestDto } from 'src/app/_dtos/accepted-shipping-request-dto';
import { AcceptedShippingRequestFilter } from 'src/app/_filters/accepted-shipping-request-filter';
import { ShippingService } from 'src/app/apiservices/shipping.service';
import { ShippingPacksComponent } from 'src/app/dialogs/shipping-packs/shipping-packs.component';
import { ShippingsComponent } from 'src/app/dialogs/shippings/shippings.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-accepted-shipping-request-list',
  templateUrl: './accepted-shipping-request-list.component.html',
  styleUrls: ['./accepted-shipping-request-list.component.css'],
})
export class AcceptedShippingRequestListComponent
  implements OnInit, AfterViewInit
{
  constructor(
    public shippingService: ShippingService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private dialog: MatDialog
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  acceptedShippingRequests: PagedResult<AcceptedShippingRequestDto> | undefined;
  dataSource = new MatTableDataSource<AcceptedShippingRequestDto>(undefined);
  displayedColumns: string[] = [
    'id',
    'employeeName',
    'employeeEmail',
    'vehicle',
    'packages',
    'shippingRequests',
    'isAllPackageTaken',
    'isAssignedToEmployee',
    'readPackageIds',
  ];

  pageSize: number = 10;
  pageNumber: number = 1;
  byEmployeeId: boolean = true;

  filter: AcceptedShippingRequestFilter = new AcceptedShippingRequestFilter();

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
    this.shippingService
      .getAcceptedShippingRequests(this.filter, this.byEmployeeId)
      .subscribe({
        next: (data: PagedResult<AcceptedShippingRequestDto>) => {
          this.acceptedShippingRequests = data;

          this.dataSource = new MatTableDataSource<AcceptedShippingRequestDto>(
            this.acceptedShippingRequests?.data
          );
        },
        error: (err) => console.error(err),
        complete: () => {
          this.shippingService.loading = false;
        },
      });
  }

  openPackages(element: AcceptedShippingRequestDto) {
    const dialogRef = this.dialog.open(ShippingPacksComponent, {
      data: { packages: element.packages },
    });
  }

  openShippings(element: AcceptedShippingRequestDto) {
    const dialogRef = this.dialog.open(ShippingsComponent, {
      data: { shippingRequests: element.shippingRequests },
    });
  }
}
