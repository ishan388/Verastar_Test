import { Order } from "./order.model";

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  street: string;
  city: string;
  state: string;
  zipCode: string;

  orders: Order[] | undefined;
}
