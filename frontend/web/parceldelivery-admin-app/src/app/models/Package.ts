export interface Package {
  id: string;
  userId: string;
  ShippingRequestId: string;
  sizeX: number;
  sizeY: number;
  sizeZ: number;
  weight: number;
  isFragile: boolean;
}
