import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderItemsComponent } from './components/order-items/order-items.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'order-items', component: OrderItemsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
