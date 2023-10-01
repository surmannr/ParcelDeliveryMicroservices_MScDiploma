/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { Vehicle } from "./vehicle";

export interface VehicleUsage {
    id: string | undefined;
    employeeId: string | undefined;
    employeeName: string | undefined;
    employeeEmail: string | undefined;
    vehicle: Vehicle | undefined;
    dateFrom: Date | undefined;
    dateTo: Date | undefined;
    note: string | undefined;
}
