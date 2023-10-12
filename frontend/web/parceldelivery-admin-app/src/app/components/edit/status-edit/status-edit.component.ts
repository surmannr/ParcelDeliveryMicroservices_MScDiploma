import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Status } from 'src/app/_dtos/status';

@Component({
  selector: 'app-status-edit',
  templateUrl: './status-edit.component.html',
  styleUrls: ['./status-edit.component.css'],
})
export class StatusEditComponent {
  @Input() status!: Status;
  @Output() statusChange = new EventEmitter<Status>();

  newStatus: Status = Status.Processing;

  availableStatus: Status[] = [
    Status.Processing,
    Status.Packing,
    Status.WaitingToPickup,
    Status.PickedUp,
    Status.Delivered,
    Status.Cancelled,
  ];

  save() {
    this.statusChange.emit(this.newStatus);
  }
}
