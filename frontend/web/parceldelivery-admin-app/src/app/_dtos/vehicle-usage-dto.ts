/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { VehicleDto } from "./vehicle-dto";

export interface VehicleUsageDto {
    id: string | undefined;
    employeeId: string | undefined;
    employeeName: string | undefined;
    employeeEmail: string | undefined;
    vehicle: VehicleDto | undefined;
    dateFrom: Date | undefined;
    dateTo: Date | undefined;
    note: string | undefined;
}
