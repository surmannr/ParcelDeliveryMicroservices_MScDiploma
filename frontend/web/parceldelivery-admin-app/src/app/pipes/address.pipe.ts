import { Pipe, PipeTransform } from '@angular/core';
import { AddressDto } from '../_dtos/address-dto';

@Pipe({
  name: 'address',
})
export class AddressPipe implements PipeTransform {
  transform(value: AddressDto): string {
    return `${value.country} ${value.zipCode} ${value.city}, ${value.street}`;
  }
}
