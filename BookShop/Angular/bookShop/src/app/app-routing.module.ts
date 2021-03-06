import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './component/book/book.component';
import { CartComponent } from './component/cart/cart.component';
import { OrderDetailFormComponent } from './component/order-detail-form/order-detail-form.component';

const routes: Routes = [
  {path:'', component: BookComponent, pathMatch:'full'},
  {path:'book', component: BookComponent},
  {path:'cart', component: CartComponent},
  {path:'order-form', component: OrderDetailFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
