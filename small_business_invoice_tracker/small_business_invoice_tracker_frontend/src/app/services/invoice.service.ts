import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './generic.service';
import { environment } from '../../environment';
import { Invoice } from '../models/invoice.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService extends GenericService<Invoice, number> {
  private apiUrl = environment.API_URL;
  private route = 'invoicetrackers';

  constructor(http: HttpClient) {
    super(http);
  }

  readAll() {
    return this.read(this.apiUrl, this.route);
  }

  getInvoiceById(id: number) {
    return this.getById(this.apiUrl, this.route, id);
  }

  createInvoice(invoice: Invoice) {
    return this.create(this.apiUrl, this.route, invoice);
  }

  updateInvoice(id: number, invoice: Invoice) {
    return this.update(this.apiUrl, this.route, id, invoice);
  }

  deleteInvoice(id: number) {
    return this.delete(this.apiUrl, this.route, id);
  }

  markAsPaid(id: number) {
    return this.markPayment(this.apiUrl, this.route, id);
  }
}