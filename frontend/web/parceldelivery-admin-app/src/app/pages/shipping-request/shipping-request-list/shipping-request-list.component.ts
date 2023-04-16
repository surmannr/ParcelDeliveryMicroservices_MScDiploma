import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { ShippingRequest } from 'src/app/models/ShippingRequest';

@Component({
  selector: 'app-shipping-request-list',
  templateUrl: './shipping-request-list.component.html',
  styleUrls: ['./shipping-request-list.component.scss'],
})
export class ShippingRequestListComponent implements OnInit {
  shippingRequests: ShippingRequest[] = [];
  dialogVisible: boolean = false;
  selectedShippingRequest: ShippingRequest | null = null;

  clear(table: Table) {
    table.clear();
  }

  showDialog(id: string) {
    this.dialogVisible = true;
    this.selectedShippingRequest = this.shippingRequests.filter(
      (x) => x.id === id
    )[0];
  }

  onDialog(open: boolean) {
    this.dialogVisible = open;
  }

  ngOnInit(): void {
    this.shippingRequests = [
      {
        id: 'sid',
        userId: 'me',
        courierId: 'notme',
        addressFrom: {
          street: 'Hős utca',
          city: 'Budapest',
          zipCode: 1081,
          country: 'Magyarország',
        },
        addressTo: {
          street: 'Hős utca',
          city: 'Budapest',
          zipCode: 1081,
          country: 'Magyarország',
        },
        isExpress: true,
        isFinished: false,
        paymentOption: {
          id: 1,
          name: 'Készpénz',
        },
        shippingOption: {
          id: 1,
          name: 'Drón',
          price: 2200,
        },
        billing: {
          id: 'bid',
          userId: 'me',
          name: 'Rudii Da',
          totalAmount: 23000,
          totalDistance: 200,
          currency: {
            id: 1,
            name: 'Ft',
          },
        },
        packages: [
          {
            id: 'pid',
            userId: 'me',
            ShippingRequestId: 'sid',
            sizeX: 2.2,
            sizeY: 1.1,
            sizeZ: 0.3,
            weight: 23,
            isFragile: true,
          },
        ],
      },
    ];
  }
}
