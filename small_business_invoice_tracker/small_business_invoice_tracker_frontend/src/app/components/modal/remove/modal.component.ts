import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { InvoiceService } from '../../../services/invoice.service';
import { Loader } from '../../../components/loader/loader.component';

@Component({
  selector: 'app-invoice-remove-modal',
  imports: [
    MatButton,
    Loader,
    CommonModule
  ],
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class RemoveModal {
  isLoading = false;

  constructor(
    private invoiceService: InvoiceService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<RemoveModal>
  ) { }

  closeModal(): void {
    this.dialogRef.close('removed');
  }

  removeInvoice() {
    this.isLoading = true;
    this.invoiceService.deleteInvoice(this.data.id).subscribe({
      next: () => {
        this.closeModal();
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error removing invoice:', error);
        this.isLoading = false;
      }
    });
  }
}
