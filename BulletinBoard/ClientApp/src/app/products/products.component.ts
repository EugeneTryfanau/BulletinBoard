import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {

  elements: any = document.getElementsByClassName("column");
  pageTitle: any = "Главная страница";
  currentPage: number = 1;
  currentCategory: number = 0;
  totalPages: number = 1;
  paginationArray: any = [];
  productsOnPage: any = [];

  isCurrent: string = "active";
  notCurrent: string = "notcurrent";

  constructor(private http: HttpClient, private prod: ProductService) {
  }

  async ngOnInit() {
    this.totalPages = await this.prod.getTotalCountOfPages();
    for (let i = 0; i < this.totalPages && i < 6; i++) {
      this.paginationArray[i] = i + 1;
    }

    var prodarray = await this.prod.getProductsOnPage();
    let size = 5;
    for (let i = 0; i < Math.ceil(prodarray.length / size); i++) {
      this.productsOnPage[i] = prodarray.slice((i * size), (i * size) + size);
    }
    console.log(this.productsOnPage);
  }

  async toPage(page: number, category: number = 0) {
    this.currentPage = page;
    this.currentCategory = category;

    if (category != 0) {
      this.paginationArray = [];
      this.totalPages = await this.prod.getTotalCountOfPages(category);
      for (let i = 0; i < this.totalPages && i < 6; i++) {
        this.paginationArray[i] = i + 1;
      }
    }

    var prodarray = await this.prod.getProductsOnPage(page, category);
    let size = 5;
    this.productsOnPage = [];
    for (let i = 0; i < Math.ceil(prodarray.length / size); i++) {
      this.productsOnPage[i] = prodarray.slice((i * size), (i * size) + size);
    }
  }

}
