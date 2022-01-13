import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-order-detail-form',
  templateUrl: './order-detail-form.component.html',
  styleUrls: ['./order-detail-form.component.css']
})
export class OrderDetailFormComponent implements OnInit {

  orderDetails = new FormGroup({
    customerFullName: new FormControl('', [Validators.minLength(3)]),
    customerEmail: new FormControl('', [Validators.email]),
    customerPhoneNumber: new FormControl('', [Validators.maxLength(10), Validators.minLength(10), Validators.pattern(/[0-9]{10}/)]),
    customerAddress: new FormGroup({
      street: new FormControl('', [Validators.minLength(3)]),
      city: new FormControl('', [Validators.minLength(3)]),
      state: new FormControl('', [Validators.minLength(3)]),
      zip: new FormControl('', [Validators.minLength(3), Validators.pattern(/[0-9]{5}/)])
    }),
    placementDate: new FormControl({ value: new Date().toLocaleDateString(), disabled: true }),
    total: new FormControl({ value: this.cart.getTotalPrice(), disabled: true }),
  });

  constructor(private cart: CartService, private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit() {
    var order = {
      "customerFullName": this.orderDetails.get("customerFullName")?.value,
      "customerEmail": this.orderDetails.get("customerEmail")?.value,
      "customerPhoneNumber": this.orderDetails.get("customerPhoneNumber")?.value,
      "customerAddress": this.orderDetails.get("customerAddress.state")?.value + ", " + this.orderDetails.get("customerAddress.city")?.value + ", " + this.orderDetails.get("customerAddress.street")?.value + ", " + this.orderDetails.get("customerAddress.zip")?.value,
      "total": this.orderDetails.get("total")?.value,
    };

    this.apiService.postOrder(order, this.cart.cartItemList);

    this.cart.removeAllCart();

    this.router.navigate(['/book']);
  }
}
