import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-delete-modal',
  templateUrl: './delete-modal.component.html',
  styleUrls: ['./delete-modal.component.scss'],
})
export class DeleteModalComponent implements OnInit {
  @Input() showModal: boolean = false;
  @Input() id: number = 0;
  @Output() change = new EventEmitter();

  constructor(private productService: ProductService) {}

  ngOnInit(): void {}

  cancel() {
    this.showModal = false;
  }

  async delete() {
    await this.productService.deleteProduct(this.id);
    this.change.emit({
      update: true,
    });
    this.showModal = false;
  }
}
