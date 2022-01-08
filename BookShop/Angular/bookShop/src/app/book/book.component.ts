import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  Books: any = [];

  constructor(private service: SharedService) { }

  ngOnInit(): void {
    this.refreshDepList();
  }

  refreshDepList() {
    this.service.getBooks().subscribe(data => {
      this.Books = data;
    });
  }

}
