/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { Address } from "./address";
import { Status } from "./status";
import { PaymentOption } from "./payment-option";
import { ShippingOption } from "./shipping-option";
import { Billing } from "./billing";
import { Package } from "./package";

export class ShippingRequest {
    id: string | undefined;
    userId: string | undefined;
    name: string | undefined;
    email: string | undefined;
    courierId: string | undefined;
    addressFrom: Address | undefined;
    addressTo: Address | undefined;
    isExpress: boolean | undefined;
    isFinished: boolean | undefined;
    dateOfDispatch: Date | undefined;
    status: Status | undefined;
    paymentOptionId: number | undefined;
    paymentOption: PaymentOption | undefined;
    shippingOptionId: number | undefined;
    shippingOption: ShippingOption | undefined;
    billingId: string | undefined;
    billing: Billing | undefined;
    packages: Package[] | undefined;
}
