import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-string-filter',
  templateUrl: './string-filter.component.html',
  styleUrls: ['./string-filter.component.css'],
})
export class StringFilterComponent {
  @Input() title!: string;
  @Output() filter = new EventEmitter();

  @Input() value!: string | undefined;
  @Output() valueChange = new EventEmitter<string>();

  clear() {
    this.value = undefined;
    this.filter.emit();
  }

  applyFilter() {
    this.valueChange.emit(this.value);
    this.filter.emit();
  }
}
