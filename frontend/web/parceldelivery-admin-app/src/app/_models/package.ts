/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { ShippingRequest } from "./shipping-request";

export class Package {
    id: string | undefined;
    userId: string | undefined;
    sizeX: number | undefined;
    sizeY: number | undefined;
    sizeZ: number | undefined;
    weight: number | undefined;
    isFragile: boolean | undefined;
    shippingRequestId: string | undefined;
    shippingRequest: ShippingRequest | undefined;
}
