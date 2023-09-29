/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { MongoBaseFilter } from "./mongo-base-filter";
import { ShippingRequest } from "../_models/shipping-request";

export class ShippingRequestMongoFilter extends MongoBaseFilter<ShippingRequest> {
    statusName: string | undefined;
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
