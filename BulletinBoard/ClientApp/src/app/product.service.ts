import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  products: any = [];
  currentPage: number = 1;
  pages: number = 0;

  constructor(private http: HttpClient) { }
  
  createProduct(createForm: any) {
    return this.http.post<any>("/api/products/create", createForm, { withCredentials: true })
      .subscribe(_ => {
        window.location.href = "/";
      })
  }

  async getTotalCountOfPages() {
    this.pages = await firstValueFrom(
      this.http.get<any>("/api/products/pages"));
    return this.pages;
  }

  async getProductsOnPage(page: number = 1) {
    this.products = await firstValueFrom(
      this.http.get<any>("/api/products/pages/" + page));
    return this.products;
  }

}
