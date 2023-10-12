import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { NewVehicleUsageDto } from 'src/app/_dtos/new-vehicle-usage-dto';
import { VehicleDto } from 'src/app/_dtos/vehicle-dto';
import { VehicleUsageDto } from 'src/app/_dtos/vehicle-usage-dto';
import { VehicleFilter } from 'src/app/_filters/vehicle-filter';
import { VehicleService } from 'src/app/apiservices/vehicle.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';

@Component({
  selector: 'app-add-new-vehicleusage',
  templateUrl: './add-new-vehicleusage.component.html',
  styleUrls: ['./add-new-vehicleusage.component.css'],
})
export class AddNewVehicleusageComponent implements OnInit {
  constructor(
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private vehicleService: VehicleService,
    private router: Router
  ) {}

  ngOnInit(): void {
    let filter = new VehicleFilter();
    filter.pageSize = 0;
    this.vehicleService.getVehicles(filter).subscribe((pagedData) => {
      this.vehicles = pagedData.data;
    });
  }

  vehicles: VehicleDto[] = [];

  newVehicleUsageForm = new FormGroup({
    vehicleId: new FormControl('', [Validators.required]),
    dateFrom: new FormControl<Date>(new Date(), Validators.required),
    dateTo: new FormControl<Date>(new Date(), Validators.required),
    note: new FormControl(''),
  });

  save() {
    let vehicle = this.vehicles.find(
      (x) => x.id === this.newVehicleUsageForm.get('vehicleId')?.value!
    );
    const vehicleUsage: NewVehicleUsageDto = {
      id: '',
      dateFrom: new Date(this.newVehicleUsageForm.get('dateFrom')?.value!),
      dateTo: new Date(this.newVehicleUsageForm.get('dateTo')?.value!),
      note: this.newVehicleUsageForm.get('note')?.value!,
      vehicleId: this.newVehicleUsageForm.get('vehicleId')?.value!,
      employeeEmail: '',
      employeeId: '',
      employeeName: '',
    };
    console.log(vehicle);
    console.log(vehicleUsage);
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.vehicleService.saveVehicleUsage(vehicleUsage).subscribe({
          next: () => {},
          error: () => {
            this.snackBar.open(
              'Nem sikerült felvenned a járműhasználatot.',
              'Értem',
              {
                duration: 3000,
              }
            );
          },
          complete: () => {
            this.snackBar.open(
              'Sikeresen felvetted a járműhasználatot.',
              'Értem',
              {
                duration: 3000,
              }
            );
            this.router.navigate(['/vehicleUsages']);
          },
        });
      }
    });
  }
}
