import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api.response';

@Injectable({
    providedIn: 'root',
})
export class GenericService<T, ID = number> {
    constructor(private http: HttpClient) { }

    read(apiUrl: string, route: string): Observable<ApiResponse<T[]>> {
        return this.http.get<ApiResponse<T[]>>(`${apiUrl}/${route}`);
    }

    getById(apiUrl: string, route: string, id: ID): Observable<T> {
        return this.http.get<T>(`${apiUrl}/${route}/${id}`);
    }

    create(apiUrl: string, route: string, entity: T): Observable<T> {
        return this.http.post<T>(`${apiUrl}/${route}`, entity);
    }

    update(apiUrl: string, route: string, id: ID, entity: T): Observable<T> {
        return this.http.put<T>(`${apiUrl}/${route}/${id}`, entity);
    }

    delete(apiUrl: string, route: string, id: ID): Observable<void> {
        return this.http.delete<void>(`${apiUrl}/${route}/${id}`);
    }

    markPayment(apiUrl: string, route: string, id: ID): Observable<T> {
        return this.http.patch<T>(`${apiUrl}/${route}/${id}/pay`, {});
    }
}
