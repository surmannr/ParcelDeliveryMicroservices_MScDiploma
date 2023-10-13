import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CurrencyDto } from 'src/app/_dtos/currency-dto';
import { CurrencyService } from 'src/app/apiservices/currency.service';
import { SaveDialogSheetComponent } from 'src/app/dialogs/save-dialog-sheet/save-dialog-sheet.component';

@Component({
  selector: 'app-currency-edit',
  templateUrl: './currency-edit.component.html',
  styleUrls: ['./currency-edit.component.css'],
})
export class CurrencyEditComponent implements OnInit {
  currency!: CurrencyDto;

  @Output() save = new EventEmitter<boolean>();

  constructor(
    public dialogRef: MatDialogRef<CurrencyEditComponent>,
    public currencyService: CurrencyService,
    private snackBar: MatSnackBar,
    private bottomSheet: MatBottomSheet,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    if (this.data.element === undefined) {
      this.currency = new CurrencyDto();
      this.currency.id = 0;
    } else {
      this.currency = this.data.element;
    }
  }

  closeClick(): void {
    this.dialogRef.close(false);
  }

  editOrAdd(element: CurrencyDto) {
    const dialog = this.bottomSheet.open(SaveDialogSheetComponent);

    dialog.afterDismissed().subscribe((result) => {
      if (result) {
        if (element.id === 0) {
          this.currencyService.saveCurrency(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült felvenned a pénznemet.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open('Sikeresen felvetted a pénznemet.', 'Értem', {
                duration: 3000,
              });
            },
          });
        } else {
          this.currencyService.editCurrency(element).subscribe({
            next: () => {},
            error: () => {
              this.snackBar.open(
                'Nem sikerült módosítanod a pénznemet.',
                'Értem',
                {
                  duration: 3000,
                }
              );
            },
            complete: () => {
              this.save.emit(true);
              this.snackBar.open(
                'Sikeresen módosítottad a pénznemet.',
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
