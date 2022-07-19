export class CustomersOrdersItems {
  customerId: number = 0;
  fullname: string = '';
  email: string = '';
  city: string = '';
  state: string = '';
  orderId: number | undefined;
  orderItemsId: number | undefined;
  itemId: number | undefined;
  listPrice: number | undefined = 0;
  discount: number | undefined = 0;
  discountVM: number | undefined = 0;
  finalPrice: number | undefined = 0;
}

export class CustomersOrdersItems1 {
  customerId: number = 0;
  fullname: string = '';
  email: string = '';
  state: string = '';
  orderId: number = 0;
  totalListPrice: number = 0;
  totalDiscount: number = 0;
  finalPrice: number = 0;
}
