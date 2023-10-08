/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { MongoBaseFilter } from "./mongo-base-filter";
import { AcceptedShippingRequest } from "../_models/accepted-shipping-request";

export class AcceptedShippingRequestFilter extends MongoBaseFilter<AcceptedShippingRequest> {
    employeeName: string | undefined;
    employeeId: string | undefined;
    isAssignedToEmployee: boolean | undefined;
    isAllPackageTaken: boolean | undefined;
}
