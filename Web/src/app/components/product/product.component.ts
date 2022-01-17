import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import IProduct from 'src/app/models/Product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  showModal: boolean = false;
  @Input() product: IProduct = {} as IProduct;
  @Output() event = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  toggleModal() {
    this.showModal = !this.showModal;
  }

  onProductChange(event: Event) {
    this.event.emit(event);
  }
}
