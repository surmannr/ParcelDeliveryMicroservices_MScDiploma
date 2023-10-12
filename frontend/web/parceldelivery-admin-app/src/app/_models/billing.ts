/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { Currency } from "./currency";
import { ShippingRequest } from "./shipping-request";

export class Billing {
    id: string | undefined;
    userId: string | undefined;
    name: string | undefined;
    totalDistance: number | undefined;
    totalAmount: number | undefined;
    currencyId: number | undefined;
    currency: Currency | undefined;
    shippingRequest: ShippingRequest | undefined;
}
