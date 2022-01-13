import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  readonly APIUrl = "http://localhost:5717/api";

  constructor(private http: HttpClient) { }

  getBooks(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/book')
      .pipe(map((res: any) => {
        return res;
      }));
  }

  getCategories(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/category')
      .pipe(map((res: any) => {
        return res;
      }));
  }

  getAuthors(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/author')
      .pipe(map((res: any) => {
        return res;
      }));
  }

  postOrder(order: any, cart: any = []): any {
    return this.http.post<any>(this.APIUrl + "/order", order)
      .subscribe((result) => {
        for(let index = 0; index < cart.length; index++) {
          this.http.post<any>(this.APIUrl + "/orderBook", {"orderId": result.orderId, "bookId": cart[index].bookId})
          .subscribe((res) => {
            console.log(res);
          })
        }
      });
  }
}
