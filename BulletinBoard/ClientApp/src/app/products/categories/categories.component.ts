import { Component } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../../services/product.service';
import { ProductsComponent } from '../products.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  categories: any = [];

  constructor(private http: HttpClient, private categoryService: CategoryService, private products: ProductsComponent) {

  }

  async ngOnInit() {
    this.categories = await this.categoryService.getCategories();
  }

  filterOnCategory(id: number = 0) {
    this.products.toPage(1, id);
    this.products.pageTitle = this.categories[id - 1].categoryName;
    console.log(id);
  }
}
