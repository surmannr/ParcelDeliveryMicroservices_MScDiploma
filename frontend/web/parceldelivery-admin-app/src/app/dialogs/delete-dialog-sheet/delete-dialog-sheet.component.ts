import { Component } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';

@Component({
  selector: 'app-delete-dialog-sheet',
  templateUrl: './delete-dialog-sheet.component.html',
  styleUrls: ['./delete-dialog-sheet.component.css'],
})
export class DeleteDialogSheetComponent {
  constructor(
    private bottomSheetRef: MatBottomSheetRef<DeleteDialogSheetComponent>
  ) {}

  save(value: boolean) {
    this.bottomSheetRef.dismiss(value);
  }
}
