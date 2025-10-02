import { AfterViewInit, Component, ViewChild, ChangeDetectorRef, TemplateRef } from '@angular/core';
import {
  MatPaginator,
  MatPaginatorModule
} from '@angular/material/paginator';
import {
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { InvoiceService } from '../../services/invoice.service';
import { ModalService } from '../../services/modal.service';
import { Loader } from '../../components/loader/loader.component';
import { Invoice } from '../../models/invoice.model';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [
    MatButton,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    Loader,
    CommonModule
  ],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.css'
})
export class Overview implements AfterViewInit {
  invoives: any[] = [];
  displayedColumns: string[] = [
    'id',
    'customerName',
    'issueDate',
    'dueDate',
    'description',
    'price',
    'total',
    'status',
    'actions'
  ];
  dataSource = new MatTableDataSource<any>(this.invoives);
  isLoading = false;

  constructor(
    private invoiceService: InvoiceService,
    private cdr: ChangeDetectorRef,
    private modalService: ModalService) { }

  @ViewChild('deleteConfirm') deleteConfirm!: TemplateRef<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit() {
    this.getInvoices();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getInvoices() {
    this.isLoading = true;
    this.invoiceService.readAll().subscribe({
      next: (response) => {
        this.invoives = response?.result ?? [];
        this.dataSource.data = this.invoives;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.invoives = [];
        this.dataSource.data = [];
        this.isLoading = false;
      }
    });
  }

  remove(element: object) {
    this.modalService.removeModal(element, 'remove').subscribe((result) => {
      if (result === 'removed') {
        this.getInvoices();
      }
    });
  }

  create() {
    this.modalService.createModal('create').subscribe((result) => {
      if (result === 'created') {
        this.getInvoices();
      }
    });
  }

  update(element: object) {
    this.modalService.updateModal(element, 'update').subscribe((result) => {
      if (result === 'updated') {
        this.getInvoices();
      }
    });
  }

  markAsPaid(element: object) {
    this.modalService.markAsPaid(element, 'markAsPaid').subscribe((result) => {
      if (result === 'updated') {
        this.getInvoices();
      }
    });
  }

  exportPdf(invoice: Invoice) {
    const doc = new jsPDF();

    doc.setFontSize(18);
    doc.text('Invoice', 14, 20);
    doc.setFontSize(12);
    doc.text(`Invoice ID: ${invoice.id}`, 14, 30);
    doc.text(`Customer: ${invoice.customerName}`, 14, 37);
    doc.text(`Issue Date: ${invoice.issueDate}`, 14, 44);
    doc.text(`Due Date: ${invoice.dueDate}`, 14, 51);
    doc.text(`Status: ${invoice.status}`, 14, 58);

    autoTable(doc, {
      startY: 65,
      head: [['Description', 'Price', 'Total']],
      body: [[invoice.description, invoice.price, invoice.total]]
    });

    doc.save(`Invoice_${invoice.id}.pdf`);
  }
}
