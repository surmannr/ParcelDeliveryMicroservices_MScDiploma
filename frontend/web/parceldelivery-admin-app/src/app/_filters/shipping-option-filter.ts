/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { SqlBaseFilter } from "./sql-base-filter";
import { ShippingOption } from "../_models/shipping-option";

export class ShippingOptionFilter extends SqlBaseFilter<ShippingOption> {
    shippingOptionName: string | undefined;
    minShippingOptionPrice: number | undefined;
    maxShippingOptionPrice: number | undefined;
}
