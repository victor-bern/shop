import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import IProduct from 'src/app/models/Product';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})
export class EditComponent implements OnInit {
  product: IProduct = {} as IProduct;
  images: string[] = [];
  id: string | null = '';
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
    private router: Router,
    private acRouter: ActivatedRoute
  ) {}

  async ngOnInit(): Promise<void> {
    this.id = this.acRouter.snapshot.paramMap.get('id');
    if (this.id == null) {
      this.router.navigate(['/']);
    }

    const product = await this.productService.getProductById(this.id);
    this.product = product;
  }

  async onSubmit() {
    console.log(this.productForm.value);
    await this.productService.editProduct(this.productForm.value, this.id);
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
