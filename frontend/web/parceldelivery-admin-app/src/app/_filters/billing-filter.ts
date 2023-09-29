/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { SqlBaseFilter } from "./sql-base-filter";
import { Billing } from "../_models/billing";

export class BillingFilter extends SqlBaseFilter<Billing> {
    minTotalDistance: number | undefined;
    maxTotalDistance: number | undefined;
    minTotalAmount: number | undefined;
    maxTotalAmount: number | undefined;
    name: string | undefined;
    statusName: string | undefined;
    currencyName: string | undefined;
    shippingOptionName: string | undefined;
    paymentOptionName: string | undefined;
    minDateOfDispatch: Date | undefined;
    maxDateOfDispatch: Date | undefined;
    isExpress: boolean | undefined;
    isFinished: boolean | undefined;
    street: string | undefined;
    city: string | undefined;
    zipCode: number | undefined;
    country: string | undefined;
}
