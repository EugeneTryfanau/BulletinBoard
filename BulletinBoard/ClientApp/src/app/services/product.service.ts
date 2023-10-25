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

  newlyCreateId: number = -1;

  constructor(private http: HttpClient) { }
  
  async createProduct(createForm: any) {
    return await this.http.post<any>("/api/products/create", createForm, { withCredentials: true });
  }

  async lastCreatedProductByUser(userId: string) {
    return await firstValueFrom(this.http.get<any>("/api/products/product/last/" + userId));
  }

  async getProductInfo(productId: number) {
    return await firstValueFrom(
      this.http.get<any>("/api/products/product/" + productId)
    );
  }

  async getTotalCountOfPages(category: number = 0) {
    this.pages = await firstValueFrom(
      this.http.get<any>("/api/products/pages/" + category));
    return this.pages;
  }

  async getProductsOnPage(page: number = 1, category: number = 0) {
    this.currentPage = page;
    this.currentCategory = category;
    this.products = await firstValueFrom(
      this.http.get<any>("/api/products/pages/" + category + "/" + page));
    return this.products;
  }

  getCurrentPage() {
    return this.currentPage;
  }

  getCurrentCategory() {
    return this.currentCategory;
  }

  async getUsersProducts(userId: string) {
    return await firstValueFrom(this.http.get<any>("/api/user-profile/products/" + userId));
  }

  async deleteUserProductById(productId: number) {
    return this.http.get("/api/delete-product/" + productId)
      .subscribe(_ => {
        window.location.reload();
      });
  }

}
