import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Loader } from '../loader/loader.component';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { BookingService } from '../../services/booking.service';
import { Booking } from '../../models/booking.model';

@Component({
  selector: 'app-booking-form',
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    Loader,
    ReactiveFormsModule
  ],
  templateUrl: './booking-form.component.html',
  styleUrl: './booking-form.component.css'
})
export class BookingFormComponent {
  bookings: any[] = [];
  selectedContact?: any;
  isLoading = false;
  bookingForm: FormGroup;
  message: string = '';
  branches: { id: number, name: string }[] = [
    { id: 1, name: 'Cape Town Branch' },
    { id: 2, name: 'Midrand Branch' },
    { id: 3, name: 'Sandton Branch' },
    { id: 4, name: 'Pretoria Branch' },
    { id: 5, name: 'Centurion Branch' }
  ];
  timeSlots: { id: number, label: string }[] = [
    { id: 1, label: '09:00 - 10:00' },
    { id: 2, label: '10:00 - 11:00' },
    { id: 3, label: '11:00 - 12:00' },
    { id: 4, label: '12:00 - 13:00' },
    { id: 5, label: '13:00 - 14:00' },
    { id: 6, label: '14:00 - 15:00' },
    { id: 7, label: '15:00 - 16:00' },
    { id: 8, label: '16:00 - 17:00' }
  ];

  constructor(private fb: FormBuilder, private bookingService: BookingService) {
    this.bookingForm = this.fb.group({
      branch: [null, Validators.required],
      timeSlot: [null, Validators.required],
      date: ['', Validators.required],
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['']
    });
  }

  ngOnInit() {
    this.getBookings();
  }

  clearMessage() {
    this.message = '';
  }

  getBookings() {
    this.isLoading = true;
    this.bookingService.getBookings().subscribe({
      next: (response) => {
        this.bookings = response?.result ?? [];
        this.isLoading = false;
      },
      error: (err) => {
        this.bookings = [];
        this.isLoading = false;
      }
    });
  }

  submit() {
    if (this.bookingForm.invalid) return;

    const formValue = this.bookingForm.value;

    const branchId = Number(formValue.branch);
    const timeSlotId = Number(formValue.timeSlot);

    const branchName = this.branches.find(br => br.id === branchId)?.name;
    const timeSlotLabel = this.timeSlots.find(ts => ts.id === timeSlotId)?.label;

    const isBooked = this.bookings.some(b =>
      b.branch === branchName &&
      b.date === formValue.date &&
      b.timeSlot === timeSlotLabel
    );

    if (isBooked) {
      this.message = '❌ Slot already booked!';
      return;
    }

    this.isLoading = true;

    const booking: Booking = {
      branch: branchName!,
      timeSlot: timeSlotLabel!,
      date: formValue.date,
      name: formValue.name,
      email: formValue.email,
      address: formValue.address,
    };

    this.bookingService.createBooking(booking).subscribe({
      next: result => {
        this.message = 'Booking created successfully!';
        this.bookings.push(booking);
        this.bookingForm.reset();
        this.isLoading = false;
      },
      error: err => {
        this.message = 'Error creating booking.';
        this.isLoading = false;
      }
    });
  }
}
