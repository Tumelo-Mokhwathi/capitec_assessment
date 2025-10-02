export interface Booking {
  branch: string;
  timeSlot: string;
  date: Date;
  name: string;
  email: string;
  address?: string;
}