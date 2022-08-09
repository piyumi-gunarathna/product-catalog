import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(
    private productService: ProductService
  ) { }

  products?: Product[];
  ngOnInit(): void {
    console.log("product-list");
    this.productService.get().subscribe(response => {
      this.products = response;
    });

  }

}
