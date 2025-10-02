import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { InvoiceService } from '../../../services/invoice.service';
import { Invoice } from '../../../models/invoice.model';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { Loader } from '../../../components/loader/loader.component';

@Component({
  selector: 'app-invoice-create-modal',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButton,
    FormsModule,
    MatSelectModule,
    ReactiveFormsModule,
    Loader,
    CommonModule
  ],
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class CreateModal {
  invoice: Invoice = {
    id: 0,
    customerName: '',
    issueDate: new Date().toISOString().substring(0, 10),
    dueDate: new Date().toISOString().substring(0, 10),
    description: '',
    price: 0,
    total: 0,
    status: 'Pending',
    createdDate: '',
    modifiedDate: ''
  };

  isLoading = false;

  constructor(
    private invoiceService: InvoiceService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<CreateModal>
  ) { }

  closeModal(): void {
    this.dialogRef.close('created');
  }

  createInvoice() {
    this.isLoading = true;
    const newInvoice: Invoice = {
      ...this.invoice,
      id: 0,
      createdDate: new Date().toISOString(),
      modifiedDate: new Date().toISOString()
    };

    console.log('Creating invoice:', newInvoice);

    this.invoiceService.createInvoice(newInvoice).subscribe({
      next: () => {
        this.closeModal();
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error creating invoice:', error);
        this.isLoading = false;
      }
    });
  }
}

