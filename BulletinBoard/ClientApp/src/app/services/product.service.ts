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
  currentCategory: number = 0;
  currentPagesize: number = 8;

  newlyCreateId: number = -1;

  constructor(private http: HttpClient) { }
  
  async createProduct(createForm: any) {
    return await this.http.post<any>("/api/products", createForm, { withCredentials: true });
  }

  lastCreatedProductByUser(userId: string) {
    return firstValueFrom(this.http.get<any>("/api/products/last/" + userId));
  }

  async getProductInfo(productId: number) {
    return await firstValueFrom(
      this.http.get<any>("/api/products/" + productId)
    );
  }

  async getTotalCountOfPages(category: number = 0, pagesize: number = 10) {
    this.pages = await firstValueFrom(
      this.http.get<any>("/api/products/pages/" + category + "/" + pagesize));
    return this.pages;
  }

  async getProductsOnPage(page: number = 1, category: number = 0, pagesize: number = 10) {
    this.currentPage = page;
    this.currentCategory = category;
    this.currentPagesize = pagesize;
    this.products = await firstValueFrom(
      this.http.get<any>("/api/products/pages/" + category + "/" + pagesize + "/" + page));
    return this.products;
  }

  getCurrentPage() {
    return this.currentPage;
  }

  getCurrentCategory() {
    return this.currentCategory;
  }

  async getUsersProducts(userId: string) {
    return await firstValueFrom(this.http.get<any>("/api/users/products/" + userId));
  }

  async deleteUserProductById(productId: number) {
    return this.http.delete("/api/products/" + productId)
      .subscribe(_ => {
        window.location.reload();
      });
  }

}
