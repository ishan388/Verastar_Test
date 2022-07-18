import { Order } from "./order.model";

export class OrderItem {
  id: number = 0;
  orderId: number = 0;
  itemId: number = 0;
  listPrice: number = 0;
  discount: number = 0;

  constructor(id: number = 0, orderId: number = 0, itemId: number = 0, listPrice: number = 0, discount: number = 0) {
    this.id = id;
    this.orderId = orderId;
    this.itemId = itemId;
    this.listPrice = listPrice;
    this.discount = discount;
  }

  order: Order = new Order();
}
