import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { DisputeService } from '../../services/dispute.service';
import { Router } from '@angular/router';
import { CardTransaction } from '../../models/card-transaction.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-transaction',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatCardModule,
    MatButtonModule,
    MatChipsModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressBarModule
  ],
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css'
})
export class Transaction implements OnInit {
  transactions: CardTransaction[] = [];
  isLoading = false;
  error = '';

  constructor(private service: DisputeService, private router: Router, private cd: ChangeDetectorRef) { }

  ngOnInit() {
    this.loadTransactions();
  }

  loadTransactions() {
    this.isLoading = true;
    this.service.getTransactions().subscribe({
      next: data => {
        this.transactions = data.result;
        this.isLoading = false;
        this.error = '';
        this.cd.detectChanges(); 
      },
      error: err => {
        this.error = err.message || err;
        this.isLoading = false;
        this.cd.detectChanges(); 
      }
    });
  }

  createDispute(transaction: CardTransaction) {
    this.router.navigate(['/dispute/new'], { state: { transaction } });
  }
}
