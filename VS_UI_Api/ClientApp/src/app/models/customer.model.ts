import { Order } from "./order.model";

export class Customer {
  id: number = 0;
  firstname: string = '';
  lastname: string = '';
  email: string = '';
  phone: string = '';
  street: string = '';
  city: string = '';
  state: string = '';
  zipCode: string = '';

  constructor(
    fnm: string = '',
    lnm: string = '',
    eml: string = '',
    phn: string = '',
    str: string = '',
    ct: string = '',
    st: string = '',
    zip: string = '') {
    this.firstname = fnm;
    this.lastname = lnm;
    this.email = eml;
    this.phone = phn;
    this.street = str;
    this.city = ct;
    this.state = st;
    this.zipCode = zip.toString();
  };

  orders: Order[] = [];
}
