import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { AcceptedShippingRequest } from 'src/app/models/AcceptedShippingRequest';
import { ShippingRequest } from 'src/app/models/ShippingRequest';

@Component({
  selector: 'app-accepted-shipping-request-list',
  templateUrl: './accepted-shipping-request-list.component.html',
  styleUrls: ['./accepted-shipping-request-list.component.scss'],
})
export class AcceptedShippingRequestListComponent implements OnInit {
  acceptedShippingRequests: AcceptedShippingRequest[] = [];
  dialogVisible: boolean = false;
  selectedShippingRequest: ShippingRequest | null = null;

  clear(table: Table) {
    table.clear();
  }

  showDialog(id: string) {
    this.dialogVisible = true;
    this.selectedShippingRequest = this.acceptedShippingRequests.filter(
      (x) => x.id === id
    )[0].shipping;
  }

  onDialog(open: boolean) {
    this.dialogVisible = open;
  }

  ngOnInit(): void {
    this.acceptedShippingRequests = [
      {
        id: 'asrid',
        employeeId: 'me',
        employeeName: 'Futár Ferdinánd',
        isAllPackageTaken: false,
        readPackageIds: [],
        shipping: {
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
      },
    ];
  }
}
