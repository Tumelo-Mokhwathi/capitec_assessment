import { Routes } from '@angular/router';
import { Dispute } from './components/dispute/dispute.component';
import { Transaction } from './components//transaction/transaction.component';

export const routes: Routes = [
  { path: '', redirectTo: 'transactions', pathMatch: 'full' },
  { path: 'dispute', component: Dispute },
  { path: 'transactions', component: Transaction },
  { path: 'dispute/new', component: Dispute },
  { path: '**', redirectTo: 'transactions' }
];

