import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { FormBuilder, FormArray, Validators } from '@angular/forms';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {


  productForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    category: ['', [Validators.required]],
    price: ['', [Validators.required]],
  });

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  @Input() product?: Product;


  ngOnInit(): void {
  }

  createProduct() {
    try {
      var product = new Product(
        this.productForm.value.name ?? '',
        this.productForm.value.description ?? '',
        parseInt(this.productForm.value.price ?? ''),
        parseInt(this.productForm.value.category ?? '')
      );
      console.log(product);
      this.productService.save(product).subscribe(response => {
        console.log(response);
        this.router.navigate(['product-list']);
      });
    } catch (error: any) {
      alert(error);
    }
  }

}
