import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { OrderItemsComponent } from './components/order-items/order-items.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CustomersComponent } from './components/customers/customers.component';
import { XLSXService } from './services/xlsx.service';
import { CustomersOrdersItemsComponent } from './components/customers-orders-items/customers-orders-items.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OrderItemsComponent,
    OrdersComponent,
    CustomersComponent,
    CustomersOrdersItemsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [XLSXService],
  bootstrap: [AppComponent]
})
export class AppModule { }
