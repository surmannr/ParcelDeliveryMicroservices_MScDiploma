import { Address } from './Address';
import { Billing } from './Billing';
import { Package } from './Package';
import { PaymentOption } from './PaymentOption';
import { ShippingOption } from './ShippingOption';

export interface ShippingRequest {
  id: string;
  userId: string;
  courierId: string;
  addressFrom: Address;
  addressTo: Address;
  isExpress: boolean;
  isFinished: boolean;

  paymentOption: PaymentOption;
  shippingOption: ShippingOption;
  billing: Billing;
  packages: Package[];
}
