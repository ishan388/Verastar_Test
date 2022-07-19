import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderItem } from '../models/order-item.model';
import { Response } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class OrderItemsService {
  apiPath: string = 'https://localhost:7245/api/OrderItem/';
  constructor(private http: HttpClient) {
  }

  saveImportedOrderItems(orderItems: OrderItem[]): Observable<Response<number>> {
    debugger;
    return this.http.post<Response<number>>(this.apiPath, orderItems);
  }

  getAllOrderItems(): Observable<Response<OrderItem>> {
    return this.http.get<Response<OrderItem>>(this.apiPath);
  }

}
