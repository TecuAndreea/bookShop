import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  public books: any;
  public filteredBooks: any;
  public categories: any;
  public authors: any;
  searchKey: string = "";

  constructor(private service: ApiService, private cartService: CartService) { }

  ngOnInit(): void {
    this.refreshDepList();
  }

  refreshDepList() {
    this.service.getBooks().subscribe(data => {
      this.books = data;
      this.filteredBooks = data;
    });

    this.service.getCategories().subscribe(data => {
      this.categories = data;
    });

    this.service.getAuthors().subscribe(data => {
      this.authors = data;
    });

    this.cartService.search.subscribe((val: any) => {
      this.searchKey = val;
    })
  }

  addtocart(item: any) {
    this.cartService.addtoCart(item);
  }

  filter(category: string) {
    this.filteredBooks = this.books
      .filter((a: any) => {
        if (a.category.name == category || category == '') {
          return a;
        }
      })
  }
}
