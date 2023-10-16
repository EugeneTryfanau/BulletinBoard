import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  categories: any = [];

  constructor(private http: HttpClient) {
  }

  async getCategories() {
    const categories = await firstValueFrom(this.http.get<any>("/api/categories"));
    return categories;
  }
}
