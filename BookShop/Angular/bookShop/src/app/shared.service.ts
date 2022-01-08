import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:5717/api";

  constructor(private http:HttpClient) { }

  getBooks():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/book');
  }
}
