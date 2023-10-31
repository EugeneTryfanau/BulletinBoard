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
  currentSearchLine: string = "";
  searchLine: string = "";

  sizeInRow: number = 5;

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
    for (let i = 0; i < Math.ceil(prodarray.length / this.sizeInRow); i++) {
      this.productsOnPage[i] = prodarray.slice((i * this.sizeInRow), (i * this.sizeInRow) + this.sizeInRow);
    }
    console.log(this.productsOnPage);
  }

  async toPage(page: number = 1, category: number = 0, searchLine: string = "%" ) {
    this.currentPage = page;
    this.currentCategory = category;
    this.currentSearchLine = searchLine;

    if (category != 0 || searchLine != "%") {
      this.paginationArray = [];
      this.totalPages = await this.prod.getTotalCountOfPages(this.currentSearchLine, this.currentCategory);
      for (let i = 0; i < this.totalPages && i < 6; i++) {
        this.paginationArray[i] = i + 1;
      }
    }

    var prodarray = await this.prod.getProductsOnPage(this.currentSearchLine, this.currentCategory, this.currentPage);
    this.productsOnPage = [];
    for (let i = 0; i < Math.ceil(prodarray.length / this.sizeInRow); i++) {
      this.productsOnPage[i] = prodarray.slice((i * this.sizeInRow), (i * this.sizeInRow) + this.sizeInRow);
    }
    console.log(this.productsOnPage);
  }

  async searchProducts() {
    this.toPage(1, 0, this.searchLine);
    this.pageTitle = "Результаты поиска по запросу: " + this.searchLine;
  }
}
