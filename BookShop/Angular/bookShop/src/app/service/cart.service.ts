import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList : any = [];
  public bookList = new BehaviorSubject<any>([]);
  public search = new BehaviorSubject<string>("");

  constructor(private apiService: ApiService) { }

  getBooks(){
    return this.bookList.asObservable();
  }

  setBook(book : any){
    this.cartItemList.push(...book);
    this.bookList.next(book);
  }
  addtoCart(product : any){
    this.cartItemList.push(product);
    this.bookList.next(this.cartItemList);
    this.getTotalPrice();
    console.log(this.cartItemList)
  }
  getTotalPrice() : number{
    let grandTotal = 0;
    this.cartItemList.map((a:any)=>{
      grandTotal += a.total;
    })
    return grandTotal;
  }
  removeCartItem(product: any){
    this.cartItemList.map((a:any, index:any)=>{
      if(product.id=== a.id){
        this.cartItemList.splice(index,1);
      }
    })
    this.bookList.next(this.cartItemList);
  }
  removeAllCart(){
    this.cartItemList = []
    this.bookList.next(this.cartItemList);
  }
}
