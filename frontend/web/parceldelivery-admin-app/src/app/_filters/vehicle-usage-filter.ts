/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { MongoBaseFilter } from "./mongo-base-filter";
import { VehicleUsage } from "../_models/vehicle-usage";

export class VehicleUsageFilter extends MongoBaseFilter<VehicleUsage> {
    minDateFrom: Date | undefined;
    maxDateFrom: Date | undefined;
    minDateTo: Date | undefined;
    maxDateTo: Date | undefined;
    note: string | undefined;
    employeeId: string | undefined;
    registrationNumber: string | undefined;
    type: string | undefined;
    minYear: number | undefined;
    maxYear: number | undefined;
    minTechnicalInspectionExpirationDate: Date | undefined;
    maxTechnicalInspectionExpirationDate: Date | undefined;
    minSeatingCapacity: number | undefined;
    maxSeatingCapacity: number | undefined;
    min_MaxInternalSpaceX: number | undefined;
    max_MaxInternalSpaceX: number | undefined;
    min_MaxInternalSpaceY: number | undefined;
    max_MaxInternalSpaceY: number | undefined;
    min_MaxInternalSpaceZ: number | undefined;
    max_MaxInternalSpaceZ: number | undefined;
    min_MaxWeight: number | undefined;
    max_MaxWeight: number | undefined;
}
