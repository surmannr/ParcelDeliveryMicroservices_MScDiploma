/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { MongoBaseFilter } from "./mongo-base-filter";
import { Vehicle } from "../_models/vehicle";

export class VehicleFilter extends MongoBaseFilter<Vehicle> {
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
