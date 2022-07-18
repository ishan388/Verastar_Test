import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';
import { Response } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  apiPath: string = 'https://localhost:7245/api/Order/';
  constructor(private http: HttpClient) {
  }

  saveImportedOrders(orders: Order[]): Observable<Response<number>> {
    return this.http.post<Response<number>>(this.apiPath, orders);
  }

  getAllOrders(): Observable<Response<Order>> {
    return this.http.get<Response<Order>>(this.apiPath);
  }

}
