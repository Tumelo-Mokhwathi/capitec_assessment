import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CardTransaction  } from '../models/card-transaction.model';
import { Observable } from 'rxjs';
import { environment } from '../../environment';
import { ApiResponse } from '../models/api.response';

@Injectable({
  providedIn: 'root'
})
export class DisputeService {
  private base = environment.API_URL;
  
  constructor(private http: HttpClient) {}

  getTransactions(): Observable<ApiResponse<CardTransaction[]>> {
    return this.http.get<ApiResponse<CardTransaction[]>>(`${this.base}/cardtransactions`);
  }

  getTransaction(id: number): Observable<ApiResponse<CardTransaction>> {
    return this.http.get<ApiResponse<CardTransaction>>(`${this.base}/cardtransactions/${id}`);
  }

  createTransaction(transaction: Partial<CardTransaction>): Observable<ApiResponse<CardTransaction>> {
    return this.http.post<ApiResponse<CardTransaction>>(`${this.base}/cardtransactions`, transaction);
  }

  updateDispute(id: number, transaction: Partial<CardTransaction>): Observable<ApiResponse<CardTransaction>> {
    return this.http.put<ApiResponse<CardTransaction>>(`${this.base}/cardtransactions/${id}/dispute`, transaction);
  }
}