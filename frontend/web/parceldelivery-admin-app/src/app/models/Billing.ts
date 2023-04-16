import { Currency } from './Currency';

export interface Billing {
  id: string;
  userId: string;
  name: string;
  totalDistance: number;
  totalAmount: number;

  currency: Currency;
}
