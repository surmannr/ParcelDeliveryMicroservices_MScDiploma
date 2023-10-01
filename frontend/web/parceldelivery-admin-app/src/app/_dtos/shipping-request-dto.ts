/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { AddressDto } from "./address-dto";
import { Status } from "./status";
import { PaymentOptionDto } from "./payment-option-dto";
import { ShippingOptionDto } from "./shipping-option-dto";
import { BillingDto } from "./billing-dto";
import { PackageDto } from "./package-dto";

export class ShippingRequestDto {
    id: string | undefined;
    userId: string | undefined;
    name: string | undefined;
    email: string | undefined;
    courierId: string | undefined;
    addressFrom: AddressDto | undefined;
    addressTo: AddressDto | undefined;
    isExpress: boolean | undefined;
    isFinished: boolean | undefined;
    status: Status | undefined;
    paymentOption: PaymentOptionDto | undefined;
    shippingOption: ShippingOptionDto | undefined;
    billing: BillingDto | undefined;
    packages: PackageDto[] | undefined;
}
