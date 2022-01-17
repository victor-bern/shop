import { Component, OnInit, Renderer2, ElementRef } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import IProduct from 'src/app/models/Product';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
})
export class AddComponent implements OnInit {
  images: string[] = [];
  show: boolean = true;
  productForm = this.form.group({
    productName: '',
    productCode: '',
    category: '',
    price: 0.0,
    promocionalPrice: 0.0,
    image: '',
  });

  constructor(
    private form: FormBuilder,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  async onSubmit() {
    await this.productService.createProduct(this.productForm.value);
    this.router.navigate(['/']);
  }

  onFileChange(event: Event) {
    const reader = new FileReader();
    const file = (event.target as HTMLInputElement).files;
    reader.readAsDataURL(file?.item(0) as File);
    reader.onload = (event) => {
      this.images.push(event.target?.result as string);
      this.productForm.get('image')?.setValue(event.target?.result as string);
    };
    this.show = false;
  }
}
