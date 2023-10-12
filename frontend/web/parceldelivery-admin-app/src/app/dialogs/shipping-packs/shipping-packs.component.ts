import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { PackageDto } from 'src/app/_dtos/package-dto';

@Component({
  selector: 'app-shipping-packs',
  templateUrl: './shipping-packs.component.html',
  styleUrls: ['./shipping-packs.component.css'],
})
export class ShippingPacksComponent implements OnInit {
  packages: PackageDto[] = [];
  dataSource = new MatTableDataSource<PackageDto>(undefined);
  displayedColumns: string[] = [
    'id',
    'sizeX',
    'sizeY',
    'sizeZ',
    'weight',
    'isFragile',
  ];

  constructor(
    public dialogRef: MatDialogRef<ShippingPacksComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.packages = this.data.packages;
    this.dataSource = new MatTableDataSource<PackageDto>(this.packages);
  }

  closeClick(): void {
    this.dialogRef.close();
  }
}
