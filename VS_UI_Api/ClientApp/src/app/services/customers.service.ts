import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { Response } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  apiPath: string = 'https://localhost:7245/api/Customer/';
  constructor(private http: HttpClient) {
  }

  getAllCustomers(): Observable<Response<Customer>> {
    return this.http.get<Response<Customer>>(this.apiPath);
  }

  saveImportedCustomers(customers: Customer[]): Observable<Response<number>> {
    return this.http.post<Response<number>>(this.apiPath, customers);
  }

}
