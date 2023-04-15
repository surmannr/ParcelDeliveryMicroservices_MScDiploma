import { Vehicle } from './Vehicle';

export interface VehicleUsage {
  id: string;
  dateFrom: Date;
  dateTo: Date;
  employeeId: string;
  employeeName: string;
  note: string;
  vehicle: Vehicle;
}
