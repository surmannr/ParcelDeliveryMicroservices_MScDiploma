import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { VehicleDto } from 'src/app/_dtos/vehicle-dto';
import { VehicleService } from 'src/app/apiservices/vehicle.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';

@Component({
  selector: 'app-add-new-vehicle',
  templateUrl: './add-new-vehicle.component.html',
  styleUrls: ['./add-new-vehicle.component.css'],
})
export class AddNewVehicleComponent {
  isNewRegistrationNumber: boolean = false;

  constructor(
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    private vehicleService: VehicleService,
    private router: Router
  ) {}
  newVehicleForm = new FormGroup({
    registrationNumber: new FormControl('', Validators.required),
    type: new FormControl('', Validators.required),
    year: new FormControl<number>(2000, [
      Validators.required,
      Validators.min(1),
    ]),
    technicalInspectionExpirationDate: new FormControl<Date>(
      new Date(),
      Validators.required
    ),
    seatingCapacity: new FormControl<number>(0, [
      Validators.required,
      Validators.min(1),
    ]),
    maxInternalSpaceX: new FormControl<number>(0, [
      Validators.required,
      Validators.min(1),
    ]),
    maxInternalSpaceY: new FormControl<number>(0, [
      Validators.required,
      Validators.min(1),
    ]),
    maxInternalSpaceZ: new FormControl<number>(0, [
      Validators.required,
      Validators.min(1),
    ]),
  });
  save() {
    const vehicle: VehicleDto = {
      id: '',
      registrationNumber: this.newVehicleForm.get('registrationNumber')?.value!,
      type: this.newVehicleForm.get('type')?.value!,
      year: this.newVehicleForm.get('year')?.value!,
      technicalInspectionExpirationDate: new Date(
        this.newVehicleForm.get('technicalInspectionExpirationDate')?.value!
      ),
      seatingCapacity: this.newVehicleForm.get('seatingCapacity')?.value!,
      maxInternalSpaceX: this.newVehicleForm.get('maxInternalSpaceX')?.value!,
      maxInternalSpaceY: this.newVehicleForm.get('maxInternalSpaceY')?.value!,
      maxInternalSpaceZ: this.newVehicleForm.get('maxInternalSpaceZ')?.value!,
    };
    console.log(vehicle);
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        this.vehicleService.saveVehicle(vehicle).subscribe({
          next: () => {},
          error: () => {
            this.snackBar.open('Nem sikerült felvenned a járművet.', 'Értem', {
              duration: 3000,
            });
          },
          complete: () => {
            this.snackBar.open('Sikeresen felvetted a járművet.', 'Értem', {
              duration: 3000,
            });
            this.router.navigate(['/vehicles']);
          },
        });
      }
    });
  }
}
