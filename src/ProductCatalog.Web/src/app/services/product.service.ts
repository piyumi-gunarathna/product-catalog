import { Injectable } from '@angular/core';
//import config from '../../assets/config.json'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../models/product';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  //private productApiUrl: string = config.ProductApiUrl;
  private productApiUrl: string = "http://localhost:7144/api/";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  constructor(private httpClient: HttpClient) { 
  }

  get(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${this.productApiUrl}product`)
      .pipe(map(product => product.map(p => { 
        return new Product(p.name, p.description, p.price, p.categoryId);
      })));
  }

  save(product: Product): Observable<object> {
    return this.httpClient.post(`${this.productApiUrl}product`,product, this.httpOptions);
  }

}
