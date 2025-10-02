import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardTransaction, DisputeStatus } from '../../models/card-transaction.model';
import { DisputeService } from '../../services/dispute.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-address-book',
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
  templateUrl: './dispute.component.html',
  styleUrl: './dispute.component.css'
})
export class Dispute {
  transaction: CardTransaction | null = null;
  reason = '';
  submitting = false;
  error = '';

  constructor(private service: DisputeService, private router: Router) {
    const nav = this.router.currentNavigation();
    this.transaction = nav?.extras?.state?.['transaction'] ?? null;
  }

  submit() {
    if (!this.transaction) { this.error = 'No transaction selected'; return; }

    this.submitting = true;

    const payload: Partial<CardTransaction> = {
      disputeReason: this.reason,
      disputeStatus: DisputeStatus.Pending,
      disputeCreatedAt: new Date().toISOString()
    };

    this.service.updateDispute(this.transaction.id, payload).subscribe({
      next: res => { this.submitting = false; this.router.navigate(['/']); },
      error: err => { this.error = err.message || err; this.submitting = false; }
    });
  }

  goBack() {
    this.router.navigate(['/transactions']);
  }
}
