import { Component, OnInit } from '@angular/core';
import { CustomersOrdersItems1 } from '../../models/customers-orders-items.model';
import { OrderItem } from '../../models/order-item.model';
import { CustomersOrdersItemsService } from '../../services/customers-orders-items.service';
import { OrderItemsService } from '../../services/order-items.service';

@Component({
  selector: 'customers-orders-items',
  templateUrl: './customers-orders-items.component.html',
  styleUrls: ['./customers-orders-items.component.css']
})
export class CustomersOrdersItemsComponent implements OnInit {

  allData: CustomersOrdersItems1[] = [];
  buttonStatus: number = 1; //1 - Filter, 2 - Apply Discount, 3 - Refresh
  orderItemsForDiscount: OrderItem[] = [];
  constructor(private service: CustomersOrdersItemsService, private oiSvc: OrderItemsService) { }

  ngOnInit(): void {
    this.cancel();
  }

  getAllData() {
    this.service.getAllData().subscribe(res => {
      this.allData = res.dataList;
    });
  }

  filterData() {
    this.allData = this.allData.filter(e => e.state.trim().toLowerCase() == "ca");
    this.buttonStatus = 2;
  }

  applyDiscounts() {
    if (this.allData?.length > 0) {
      this.allData.forEach(data => {
        data.totalDiscount += (data.finalPrice * 0.05);
        data.finalPrice -= (data.finalPrice * 0.05);
      });
      this.buttonStatus = 3;
    }
  }

  saveChanges() {
    //this.service.applyDiscounts(this.orderItemsForDiscount).subscribe(res => {
    //  this.cancel();
    //});
  }

  cancel() {
    this.buttonStatus = 1;
    this.orderItemsForDiscount = [];
    this.getAllData();
  }


}
