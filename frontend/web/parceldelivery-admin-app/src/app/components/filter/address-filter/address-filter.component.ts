import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-address-filter',
  templateUrl: './address-filter.component.html',
  styleUrls: ['./address-filter.component.css'],
})
export class AddressFilterComponent {
  @Input() title!: string;
  @Output() filter = new EventEmitter();

  @Input() country!: string | undefined;
  @Output() countryChange = new EventEmitter<string>();

  @Input() zipCode!: number | undefined;
  @Output() zipCodeChange = new EventEmitter<number>();

  @Input() city!: string | undefined;
  @Output() cityChange = new EventEmitter<string>();

  @Input() street!: string | undefined;
  @Output() streetChange = new EventEmitter<string>();

  clear() {
    this.country = undefined;
    this.zipCode = undefined;
    this.city = undefined;
    this.street = undefined;
    this.filter.emit();
  }

  applyFilter() {
    this.countryChange.emit(this.country);
    this.zipCodeChange.emit(this.zipCode);
    this.cityChange.emit(this.city);
    this.streetChange.emit(this.street);
    this.filter.emit();
  }
}
