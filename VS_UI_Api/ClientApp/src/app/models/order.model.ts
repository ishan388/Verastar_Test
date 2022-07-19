import { Customer } from "./customer.model";
import { OrderItem } from "./order-item.model";

const regExpr = /(\d{2})-(\d{2})-(\d{4})/;
const replaceStr = "$2/$1/$3";

export class Order {
  id: number = 0;
  customerId: number = 0;
  status: number = 3;
  orderDate: Date = new Date();
  requiredDate: Date = new Date();
  shippedDate: Date | null;

  constructor(id: number = 0, custId: number = 0, status: number = 3,
    oDate: string = '', reqDate: string = '', shipDate: string = '') {
    this.id = id;
    this.customerId = custId;
    this.status = status;
    this.orderDate = (oDate?.length > 0) ? this.castStringToDate(oDate) : new Date();
    this.requiredDate = (reqDate?.length > 0) ? this.castStringToDate(reqDate) : new Date();
    this.shippedDate = (shipDate?.length > 0) ? this.castStringToDate(shipDate) : null;
  }

  castStringToDate(str: string) {
    const [day, month, year] = str.split('/');
    const date = new Date(+year, (month as unknown as number) - 1, +day);
    return date;
  }
  //customer: Customer = new Customer();
  //orderItems: OrderItem[] = [];
}


