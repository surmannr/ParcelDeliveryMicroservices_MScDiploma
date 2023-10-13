import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ShippingOptionDto } from 'src/app/_dtos/shipping-option-dto';
import { ShippingMethodService } from 'src/app/apiservices/shipping-method.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';

@Component({
  selector: 'app-shipping-method-edit',
  templateUrl: './shipping-method-edit.component.html',
  styleUrls: ['./shipping-method-edit.component.css'],
})
export class ShippingMethodEditComponent implements OnInit {
  shippingOption!: ShippingOptionDto;

  @Output() save = new EventEmitter<boolean>();

  constructor(
    public dialogRef: MatDialogRef<ShippingMethodEditComponent>,
    public shippingService: ShippingMethodService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    if (this.data.element === undefined) {
      this.shippingOption = new ShippingOptionDto();
      this.shippingOption.id = 0;
    } else {
      this.shippingOption = this.data.element;
    }
  }

  closeClick(): void {
    this.dialogRef.close(false);
  }

  editOrAdd(element: ShippingOptionDto) {
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        if (element.id === 0) {
          this.shippingService.saveShippingOption(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült felvenned a szállítási módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open(
                'Sikeresen felvetted a szállítási módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
          });
        } else {
          this.shippingService.editShippingOption(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült módosítanod a szállítási módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open(
                'Sikeresen módosítottad a szállítási módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
          });
        }
      }
    });

    this.dialogRef.close(true);
  }
}
