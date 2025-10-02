import { AfterViewInit, Component, ViewChild, ChangeDetectorRef } from '@angular/core';
import {
  MatPaginator,
  MatPaginatorModule
} from '@angular/material/paginator';
import {
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { BookingService } from '../../services/booking.service';
import { Loader } from '../../components/loader/loader.component';

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    Loader
  ],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.css'
})
export class Overview implements AfterViewInit {
  bookings: any[] = [];
  displayedColumns: string[] = ['id', 'name', 'branch', 'date', 'timeSlot', 'email', 'address'];
  dataSource = new MatTableDataSource<any>(this.bookings);
  isLoading = false;

  constructor(
    private bookingService: BookingService,
    private cdr: ChangeDetectorRef) { }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit() {
    this.getBookings();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getBookings() {
    this.isLoading = true;
    this.bookingService.getBookings().subscribe({
      next: (response) => {
        this.bookings = response?.result ?? [];
        this.dataSource.data = this.bookings;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.bookings = [];
        this.dataSource.data = [];
        this.isLoading = false;
      }
    });
  }
}
