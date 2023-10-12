import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { VehicleDto } from 'src/app/_dtos/vehicle-dto';
import { VehicleFilter } from 'src/app/_filters/vehicle-filter';
import { VehicleService } from 'src/app/apiservices/vehicle.service';
import { DeleteDialogSheetComponent } from 'src/app/dialogs/delete-dialog-sheet/delete-dialog-sheet.component';
import { PagedResult } from 'src/app/models/PagedResult';

@Component({
  selector: 'app-vehicles-list',
  templateUrl: './vehicles-list.component.html',
  styleUrls: ['./vehicles-list.component.css'],
})
export class VehiclesListComponent implements OnInit, AfterViewInit {
  constructor(
    public vehicleService: VehicleService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet
  ) {}

  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  vehicles: PagedResult<VehicleDto> | undefined;
  dataSource = new MatTableDataSource<VehicleDto>(undefined);
  displayedColumns: string[] = [
    'registrationNumber',
    'type',
    'year',
    'technicalInspectionExpirationDate',
    'seatingCapacity',
    'maxInternalSpaceX',
    'maxInternalSpaceY',
    'maxInternalSpaceZ',
    'id',
  ];

  pageSize: number = 10;
  pageNumber: number = 1;

  filter: VehicleFilter = new VehicleFilter();

  get isLoading(): boolean {
    return this.vehicleService.loading;
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
    this.vehicleService.loading = true;
    this.filter.pageSize = this.pageSize;
    this.filter.pageNumber = this.pageNumber;
    this.vehicleService.getVehicles(this.filter).subscribe({
      next: (data: PagedResult<VehicleDto>) => {
        this.vehicles = data;

        this.dataSource = new MatTableDataSource<VehicleDto>(
          this.vehicles?.data
        );
      },
      error: (err) => console.error(err),
      complete: () => {
        this.vehicleService.loading = false;
      },
    });
  }

  onDelete(id: string) {
    const dialog = this.bottomSheet.open(DeleteDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.vehicleService.deleteVehicle(id).subscribe({
          complete: () => {
            this.load();
            this.snackBar.open('Sikeresen törölted a járművet.', 'Értem', {
              duration: 3000,
            });
          },
          error: () => {
            this.snackBar.open('Nem sikerült törölnöd a járművet.', 'Értem', {
              duration: 3000,
            });
          },
        });
      }
    });
  }
}
