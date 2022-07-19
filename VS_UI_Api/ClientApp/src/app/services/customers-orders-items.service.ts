import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomersOrdersItems1 } from '../models/customers-orders-items.model';
import { Response } from '../models/response.model';
import { OrderItem } from '../models/order-item.model';
import { Observable } from 'rxjs';
import { OrderItemsService } from './order-items.service';

@Injectable({
  providedIn: 'root'
})
export class CustomersOrdersItemsService {

  
  apiPath: string = 'https://localhost:7245/api/CustomersOrdersItems/';
  constructor(private http: HttpClient, private oiSvc: OrderItemsService) {
  }

  getAllData(): Observable<Response<CustomersOrdersItems1>>{
    return this.http.get<Response<CustomersOrdersItems1>>(this.apiPath);
  }

  applyDiscounts(items: OrderItem[]): Observable<Response<number>> {
    return this.oiSvc.updateBulkOrderItems(items);
  }

}
