/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { CurrencyDto } from "./currency-dto";

export interface BillingDto {
    id: string | undefined;
    userId: string | undefined;
    name: string | undefined;
    totalDistance: number | undefined;
    totalAmount: number | undefined;
    currency: CurrencyDto | undefined;
}
