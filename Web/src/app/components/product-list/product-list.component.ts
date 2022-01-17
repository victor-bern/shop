import { Component, OnInit } from '@angular/core';
import IProduct from 'src/app/models/Product';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
  products: IProduct[] = [];
  constructor(private productService: ProductService) {}

  async ngOnInit(): Promise<void> {
    const response = await this.productService.getProducts();

    this.products = response;
    console.log(this.products);
  }

  async onProductChange(event: Event) {
    const response = await this.productService.getProducts();

    this.products = response;
  }
}
