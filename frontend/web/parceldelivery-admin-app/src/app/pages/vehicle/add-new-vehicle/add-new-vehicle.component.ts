import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Vehicle } from 'src/app/models/Vehicle';
import { VehicleService } from 'src/app/services/api/vehicle.service';

@Component({
  selector: 'app-add-new-vehicle',
  templateUrl: './add-new-vehicle.component.html',
  styleUrls: ['./add-new-vehicle.component.scss'],
})
export class AddNewVehicleComponent {
  isNewRegistrationNumber: boolean = false;
  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private vehicleService: VehicleService,
    private router: Router
  ) {}

  registrationNumber = new FormControl('', Validators.required);
  type = new FormControl('', Validators.required);
  year = new FormControl('', Validators.required);
  technicalInspectionExpirationDate = new FormControl('', Validators.required);
  seatingCapacity = new FormControl('', Validators.required);
  maxInternalSpaceX = new FormControl('', Validators.required);
  maxInternalSpaceY = new FormControl('', Validators.required);
  maxInternalSpaceZ = new FormControl('', Validators.required);

  save(event: Event) {
    this.confirmationService.confirm({
      target: event.target!,
      message: 'Biztos vagy benne, hogy felveszed a járművet?',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Igen',
      rejectLabel: 'Nem',
      accept: () => {
        const newVehicle: Vehicle = {
          id: '',
          registrationNumber: this.registrationNumber.value!,
          type: this.type.value!,
          year: parseInt(this.year.value!),
          technicalInspectionExpirationDate: new Date(
            this.technicalInspectionExpirationDate.value!
          ),
          seatingCapacity: parseInt(this.seatingCapacity.value!),
          maxInternalSpaceX: parseInt(this.maxInternalSpaceX.value!),
          maxInternalSpaceY: parseInt(this.maxInternalSpaceY.value!),
          maxInternalSpaceZ: parseInt(this.maxInternalSpaceZ.value!),
        };
        this.vehicleService.saveVehicle(newVehicle).subscribe({
          next: () => {},
          error: () => {
            this.messageService.add({
              severity: 'error',
              summary: 'Hiba',
              detail: 'Nem sikerült felvenni a járművet.',
            });
          },
          complete: () => {
            this.messageService.add({
              severity: 'info',
              summary: 'Felvéve',
              detail: 'Sikeresen felvetted a járművet.',
            });
            this.router.navigate(['/vehicles']);
          },
        });
      },
      reject: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Mégse',
          detail: 'Visszaléptél a jármű mentése során.',
        });
      },
    });
  }
}
