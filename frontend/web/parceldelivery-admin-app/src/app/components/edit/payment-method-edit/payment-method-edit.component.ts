import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PaymentOptionDto } from 'src/app/_dtos/payment-option-dto';
import { PaymentMethodService } from 'src/app/apiservices/payment-method.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';

@Component({
  selector: 'app-payment-method-edit',
  templateUrl: './payment-method-edit.component.html',
  styleUrls: ['./payment-method-edit.component.css'],
})
export class PaymentMethodEditComponent implements OnInit {
  paymentOption!: PaymentOptionDto;

  @Output() save = new EventEmitter<boolean>();

  constructor(
    public dialogRef: MatDialogRef<PaymentMethodEditComponent>,
    public paymentMethodService: PaymentMethodService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    if (this.data.element === undefined) {
      this.paymentOption = new PaymentOptionDto();
      this.paymentOption.id = 0;
    } else {
      this.paymentOption = this.data.element;
    }
  }

  closeClick(): void {
    this.dialogRef.close(false);
  }

  editOrAdd(element: PaymentOptionDto) {
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        if (element.id === 0) {
          this.paymentMethodService.savePaymentOption(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült felvenned a fizetési módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open(
                'Sikeresen felvetted a fizetési módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
          });
        } else {
          this.paymentMethodService.editPaymentOption(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült módosítanod a fizetési módot.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open(
                'Sikeresen módosítottad a fizetési módot.',
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
