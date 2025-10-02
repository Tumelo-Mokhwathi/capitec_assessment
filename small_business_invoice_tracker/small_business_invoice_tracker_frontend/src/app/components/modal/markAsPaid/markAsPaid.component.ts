import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { InvoiceService } from '../../../services/invoice.service';
import { Loader } from '../../../components/loader/loader.component';

@Component({
  selector: 'app-invoice-markAsPaid-modal',
  imports: [
    MatButton,
    Loader,
    CommonModule
  ],
  templateUrl: './markAsPaid.component.html',
  styleUrls: ['./markAsPaid.component.css']
})
export class MarkAsPaidModal {
  isLoading = false;

  constructor(
    private invoiceService: InvoiceService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<MarkAsPaidModal>
  ) { }

  closeModal(): void {
    this.dialogRef.close('removed');
  }

  markAsPaid() {
    this.isLoading = true;
    this.invoiceService.markAsPaid(this.data.id).subscribe({
      next: () => {
        this.closeModal();
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error marking invoice as paid:', error);
        this.isLoading = false;
      }
    });
  }
}
