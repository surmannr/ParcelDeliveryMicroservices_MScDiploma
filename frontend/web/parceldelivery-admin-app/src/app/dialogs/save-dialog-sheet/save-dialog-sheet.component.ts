import { Component } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';

@Component({
  selector: 'app-save-dialog-sheet',
  templateUrl: './save-dialog-sheet.component.html',
  styleUrls: ['./save-dialog-sheet.component.css'],
})
export class SaveDialogSheetComponent {
  constructor(
    private bottomSheetRef: MatBottomSheetRef<SaveDialogSheetComponent>
  ) {}

  save(value: boolean) {
    this.bottomSheetRef.dismiss(value);
  }
}
