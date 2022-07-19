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

  constructor(custId: number
    , fnm: string
    , eml: string
    , ct: string
    , st: string
    , ordId: number | undefined
    , oiId: number | undefined
    , itmId: number | undefined
    , price: number | undefined
    , dis: number | undefined
    , final: number | undefined) {

    this.customerId = custId;
    this.fullname = fnm;
    this.email = eml;
    this.city = ct;
    this.state = st;
    this.orderId = ordId;
    this.orderItemsId = oiId;
    this.itemId = itmId;
    this.listPrice = price;
    this.discount = dis;
    this.finalPrice = final;
    this.discountVM = ((dis ?? 0) * 100);
  }

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
