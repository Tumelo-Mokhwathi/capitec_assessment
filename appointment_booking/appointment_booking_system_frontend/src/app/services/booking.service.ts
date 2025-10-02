import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking.model';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = environment.API_URL;
  constructor(private http: HttpClient) { }

  getBookings(): Observable<any> {
    return this.http.get(`${this.apiUrl}/bookings`);
  }

  createBooking(booking: Booking): Observable<any> {
    return this.http.post(`${this.apiUrl}/bookings/create`, booking);
  }
}