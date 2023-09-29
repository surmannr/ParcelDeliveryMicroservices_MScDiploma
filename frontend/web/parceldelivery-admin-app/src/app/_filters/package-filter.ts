/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { SqlBaseFilter } from "./sql-base-filter";
import { Package } from "../_models/package";

export class PackageFilter extends SqlBaseFilter<Package> {
    minSizeX: number | undefined;
    maxSizeX: number | undefined;
    minSizeY: number | undefined;
    maxSizeY: number | undefined;
    minSizeZ: number | undefined;
    maxSizeZ: number | undefined;
    minWeight: number | undefined;
    maxWeight: number | undefined;
    isFragile: boolean | undefined;
}
