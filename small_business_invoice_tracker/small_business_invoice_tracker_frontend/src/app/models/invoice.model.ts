export interface Invoice {
  id: number;
  customerName: string;
  issueDate: string; 
  dueDate: string;     
  total: number;
  description: string;
  price: number;
  status: 'Pending' | 'Paid' | 'Overdue'; 
  createdDate?: string;
  modifiedDate?: string;
}
