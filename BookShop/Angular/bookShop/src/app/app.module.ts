import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './component/book/book.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from './service/api.service';
import { HeaderComponent } from './component/header/header.component';
import { CartComponent } from './component/cart/cart.component';
import { OrderDetailFormComponent } from './component/order-detail-form/order-detail-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    HeaderComponent,
    CartComponent,
    OrderDetailFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [ApiService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
