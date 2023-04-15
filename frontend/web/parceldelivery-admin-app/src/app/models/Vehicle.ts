export interface Vehicle {
  id: string;
  registrationNumber: string;
  type: string;
  year: number;
  technicalInspectionExpirationDate: Date;
  seatingCapacity: number;
  maxInternalSpaceX: number;
  maxInternalSpaceY: number;
  maxInternalSpaceZ: number;
}
