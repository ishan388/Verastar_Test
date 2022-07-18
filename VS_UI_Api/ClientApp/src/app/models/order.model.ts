import { Customer } from "./customer.model";
import { OrderItem } from "./order-item.model";

export class Order {
  id: number = 0;
  customerId: number = 0;
  status: number = 3;
  orderDate: Date = new Date();
  requiredDate: Date = new Date();
  shippedDate: Date = new Date();

  customer: Customer = new Customer();
  orderItems: OrderItem[] = [];
}
