import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  products: Product[] = [];
  constructor(private http: HttpClient)
  {

  }
  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products').subscribe({
      next: Response=> this.products = Response.data,//what do next
      error: error => console.log(error),//what to do in case of an error
      complete: () => {
        console.log('request completed');
        console.log('extra statment');
      }
    });
  }
}
