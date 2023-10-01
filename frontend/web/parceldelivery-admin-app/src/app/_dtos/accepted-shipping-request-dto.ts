/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { VehicleDto } from "./vehicle-dto";
import { PackageDto } from "./package-dto";
import { ShippingRequestDto } from "./shipping-request-dto";

export interface AcceptedShippingRequestDto {
    id: string | undefined;
    employeeId: string | undefined;
    employeeName: string | undefined;
    employeeEmail: string | undefined;
    vehicle: VehicleDto | undefined;
    packages: PackageDto[] | undefined;
    shippingRequests: ShippingRequestDto[] | undefined;
    isAllPackageTaken: boolean | undefined;
    isAssignedToEmployee: boolean | undefined;
    readPackageIds: string[] | undefined;
}
