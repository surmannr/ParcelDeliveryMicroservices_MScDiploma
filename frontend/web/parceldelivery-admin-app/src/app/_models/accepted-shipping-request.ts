/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { Vehicle } from "./vehicle";
import { Package } from "./package";
import { ShippingRequest } from "./shipping-request";

export interface AcceptedShippingRequest {
    id: string | undefined;
    employeeId: string | undefined;
    employeeName: string | undefined;
    employeeEmail: string | undefined;
    vehicle: Vehicle | undefined;
    packages: Package[] | undefined;
    shippingRequests: ShippingRequest[] | undefined;
    isAllPackageTaken: boolean | undefined;
    isAssignedToEmployee: boolean | undefined;
    readPackageIds: string[] | undefined;
}
