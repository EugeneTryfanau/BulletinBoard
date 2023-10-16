import { Component } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  categories: any = [];

  constructor(private http: HttpClient, private categoryService: CategoryService) {

  }

  async ngOnInit() {
    this.categories = await this.categoryService.getCategories();
  }

}
