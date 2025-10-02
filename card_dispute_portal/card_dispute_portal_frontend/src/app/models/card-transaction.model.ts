export enum DisputeStatus {
  NotSubmitted = 'NotSubmitted',
  Pending = 'Pending',
  Reviewed = 'Reviewed',
  Approved = 'Approved',
  Rejected = 'Rejected',
  Closed = 'Closed'
}

export interface CardTransaction {
  id: number;
  date: string;     
  amount: number;
  merchant: string;
  cardLast4?: string;
  description?: string;
  createdDate: string;       
  disputeReason?: string;
  disputeStatus?: DisputeStatus;
  disputeCreatedAt?: string;
}
