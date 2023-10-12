import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../_dtos/status';

@Pipe({
  name: 'status',
})
export class StatusPipe implements PipeTransform {
  transform(value: Status): string {
    switch (value) {
      case Status.Processing:
        return 'Feldolgozás alatt';
      case Status.Packing:
        return 'Csomagolás alatt';
      case Status.WaitingToPickup:
        return 'Futár felvételre vár';
      case Status.PickedUp:
        return 'Futárnál';
      case Status.Delivered:
        return 'Kézbesítve';
      case Status.Cancelled:
        return 'Visszavont';

      default:
        return 'N/A';
    }
  }
}
