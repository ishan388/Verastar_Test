import { Customer } from "./customer.model";
import { OrderItem } from "./order-item.model";

export interface Order {
  id: number;
  customerId: number;
  status: number;
  orderDate: Date;
  requiredDate: Date;
  shippedDate: Date;

  customer: Customer | undefined;
  orderItems: OrderItem[] | undefined;
}
