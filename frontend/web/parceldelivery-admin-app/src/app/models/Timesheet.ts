export interface Timesheet {
  id: string;
  dateFrom: Date;
  dateTo: Date;
  note: string;
  userId: string;
  days: number[];
}
