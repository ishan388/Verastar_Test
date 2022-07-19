import { Order } from "./order.model";

export class OrderItem {
  id: number = 0;
  orderId: number = 0;
  itemId: number = 0;
  listPrice: number = 0;
  discount: number = 0;

  constructor(orderId: number = 0, itemId: number = 0, listPrice: number = 0, discount: number = 0) {
    this.orderId = orderId;
    this.itemId = itemId;
    this.listPrice = listPrice;
    this.discount = discount;
  }
}
