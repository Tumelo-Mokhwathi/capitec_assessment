import { Routes } from '@angular/router';
import { Overview } from './components/overview/overview.component';

export const routes: Routes = [
  { path: '', redirectTo: 'summary', pathMatch: 'full' },
  { path: 'summary', component: Overview }
];

