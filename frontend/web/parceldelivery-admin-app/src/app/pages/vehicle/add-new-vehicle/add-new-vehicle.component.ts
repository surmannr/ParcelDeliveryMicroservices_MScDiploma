import { Component } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-new-vehicle',
  templateUrl: './add-new-vehicle.component.html',
  styleUrls: ['./add-new-vehicle.component.scss'],
})
export class AddNewVehicleComponent {
  isNewRegistrationNumber: boolean = false;
  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {}
  save(event: Event) {
    this.confirmationService.confirm({
      target: event.target!,
      message: 'Biztos vagy benne, hogy felveszed a járművet?',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Igen',
      rejectLabel: 'Nem',
      accept: () => {
        this.messageService.add({
          severity: 'info',
          summary: 'Felvéve',
          detail: 'Sikeresen felvetted a járművet.',
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
