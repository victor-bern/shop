import { Injectable } from '@angular/core';
import axios from 'axios';
import IProduct from './models/Product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor() {}

  async getProducts() {
    const response = await axios.get<IProduct[]>(
      'https://localhost:7030/v1/products/getall'
    );
    return response.data;
  }

  async getProductById(id: string | null) {
    const response = await axios.get<IProduct>(
      'https://localhost:7030/v1/products/byid/' + id
    );
    return response.data;
  }

  async createProduct(product: IProduct) {
    const response = await axios.post<IProduct>(
      'https://localhost:7030/v1/products/create',
      product
    );
    return response.data;
  }

  async editProduct(product: IProduct, id: string | null) {
    const response = await axios.put<IProduct>(
      'https://localhost:7030/v1/products/update/' + id,
      product
    );
    return response.data;
  }

  async deleteProduct(id: number) {
    await axios.delete(`https://localhost:7030/v1/products/delete/${id}`);
  }
}
