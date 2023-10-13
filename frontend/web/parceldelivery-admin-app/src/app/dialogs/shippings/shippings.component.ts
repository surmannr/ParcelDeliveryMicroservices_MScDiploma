import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ShippingRequestDto } from 'src/app/_dtos/shipping-request-dto';

@Component({
  selector: 'app-shippings',
  templateUrl: './shippings.component.html',
  styleUrls: ['./shippings.component.css'],
})
export class ShippingsComponent {
  shippingRequests: ShippingRequestDto[] = [];
  dataSource = new MatTableDataSource<ShippingRequestDto>(undefined);
  displayedColumns: string[] = [
    'id',
    'name',
    'addressFrom',
    'addressTo',
    'isExpress',
    'isFinished',
    'status',
    'paymentOption',
    'shippingOption',
  ];

  constructor(
    public dialogRef: MatDialogRef<ShippingsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.shippingRequests = this.data.shippingRequests;
    this.dataSource = new MatTableDataSource<ShippingRequestDto>(
      this.shippingRequests
    );
  }

  closeClick(): void {
    this.dialogRef.close();
  }
}
