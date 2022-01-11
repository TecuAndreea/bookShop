import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  public Books: any;

  constructor(private service: ApiService, private cartService: CartService) { }

  ngOnInit(): void {
    this.refreshDepList();
  }

  refreshDepList() {
    this.service.getBooks().subscribe(data => {
      this.Books = data;
      this.Books.forEach((a:any) => {
        Object.assign(a,{quantity:1,total:a.price});
      });
    });
  }

  addtocart(item: any){
    this.cartService.addtoCart(item);
  }
}
