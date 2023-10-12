import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-number-filter',
  templateUrl: './number-filter.component.html',
  styleUrls: ['./number-filter.component.css'],
})
export class NumberFilterComponent {
  @Input() title!: string;
  @Output() filter = new EventEmitter();

  @Input() minValue!: number | undefined;
  @Output() minValueChange = new EventEmitter<number>();

  @Input() maxValue!: number | undefined;
  @Output() maxValueChange = new EventEmitter<number>();

  clear() {
    this.minValue = undefined;
    this.maxValue = undefined;
    this.filter.emit();
  }

  applyFilter() {
    this.minValueChange.emit(this.minValue);
    this.maxValueChange.emit(this.maxValue);
    this.filter.emit();
  }
}
