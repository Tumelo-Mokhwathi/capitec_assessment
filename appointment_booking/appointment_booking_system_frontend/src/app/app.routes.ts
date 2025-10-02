import { Routes } from '@angular/router';
import { BookingFormComponent } from './components/booking/booking-form.component';
import { Overview } from './components/overview/overview.component';

export const routes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'bookings', component: BookingFormComponent },
  { path: 'summary', component: Overview }
];

