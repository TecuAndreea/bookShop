import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-order-detail-form',
  templateUrl: './order-detail-form.component.html',
  styleUrls: ['./order-detail-form.component.css']
})
export class OrderDetailFormComponent implements OnInit {

  orderDetails = new FormGroup({
    customerFullName : new FormControl(''),
    customerEmail : new FormControl(''),
    customerPhoneNumber : new FormControl(''),
    customerAddress: new FormGroup({
      street: new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      zip: new FormControl('')
    }),
    placementDate : new FormControl({value: new Date().toLocaleDateString(), disabled: true}),
    total : new FormControl({value : this.cart.getTotalPrice(), disabled: true}),
  });

  constructor(private cart: CartService, private apiService: ApiService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.orderDetails.value);
  }

}
