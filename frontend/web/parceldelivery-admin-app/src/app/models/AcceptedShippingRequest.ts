import { ShippingRequest } from './ShippingRequest';

export interface AcceptedShippingRequest {
  id: string;
  employeeId: string;
  employeeName: string;
  shipping: ShippingRequest;
  isAllPackageTaken: boolean;
  readPackageIds: string[];
}
