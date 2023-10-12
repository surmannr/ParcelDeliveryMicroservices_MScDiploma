import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BillingDto } from 'src/app/_dtos/billing-dto';

@Component({
  selector: 'app-billings',
  templateUrl: './billings.component.html',
  styleUrls: ['./billings.component.css'],
})
export class BillingsComponent implements OnInit {
  billing: BillingDto | undefined;

  constructor(
    public dialogRef: MatDialogRef<BillingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.billing = this.data.billing;
  }

  closeClick(): void {
    this.dialogRef.close();
  }
}
