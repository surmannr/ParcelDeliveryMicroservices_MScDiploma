import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
})
export class DateFilterComponent {
  @Input() title!: string;
  @Output() filter = new EventEmitter();

  @Input() minDate!: Date | undefined;
  @Output() minDateChange = new EventEmitter<Date>();
  @Input() maxDate!: Date | undefined;
  @Output() maxDateChange = new EventEmitter<Date>();

  clear() {
    this.minDate = undefined;
    this.maxDate = undefined;
    this.filter.emit();
  }

  applyFilter() {
    this.minDateChange.emit(this.minDate);
    this.maxDateChange.emit(this.maxDate);
    this.filter.emit();
  }
}
