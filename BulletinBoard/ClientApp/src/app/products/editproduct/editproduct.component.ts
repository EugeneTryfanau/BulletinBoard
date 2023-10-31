import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';
import { firstValueFrom, switchMap } from 'rxjs';
import { ProductInfo } from '../../services/models/productinfo';
import { CategoryService } from '../../services/category.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-editproduct',
  templateUrl: './editproduct.component.html',
  styleUrls: ['./editproduct.component.css']
})
export class EditproductComponent {

  productId!: number;
  product: any;
  pictures: any;
  picIndexes: number[] = [];
  categories: any = [];

  slideIndex: number = 1;
  slideChanged: boolean = false;

  productInfo: ProductInfo = new ProductInfo();

  constructor(private http: HttpClient, private route: ActivatedRoute, private prod: ProductService, private categoryService: CategoryService) {
  }

  async ngOnInit() {
    this.categories = await firstValueFrom(this.http.get<any>("/api/categories"));
    await this.route.paramMap.pipe(
      switchMap(params => params.getAll('productId')))
      .subscribe(data => this.productId = +data);

    this.product = await this.prod.getProductInfo(this.productId);
    this.pictures = this.product.pictures;
    for (let i = 0; i < this.pictures.length; i++) {
      this.picIndexes.push(i + 1);
    }
    console.log(this.product);
  }

  plusSlides(n: number) {
    this.showSlides(this.slideIndex += n);
  }

  currentSlide(n: number) {
    this.showSlides(this.slideIndex = n);
  }

  async showSlides(n: number) {
    var i;
    var slides = await Array.from(await document.getElementsByClassName('mySlides') as HTMLCollectionOf<HTMLElement>);
    console.log(slides);

    var dots = await Array.from(document.getElementsByClassName('dot') as HTMLCollectionOf<HTMLElement>);
    console.log(dots);
    if (n > slides.length) { this.slideIndex = 1 }
    if (n < 1) { this.slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[this.slideIndex - 1].style.display = "block";
    dots[this.slideIndex - 1].className += " active";
    this.slideChanged = true;
  }

  async sendChangedInfo() {
    this.productInfo.id = this.product.id;
    this.productInfo.categoryId = this.product.categoryId;
    this.productInfo.name = this.product.name;
    this.productInfo.price = this.product.price;
    this.productInfo.description = this.product.description;
    this.productInfo.conditionIsNew = this.product.conditionIsNew == "false" ? false : true;
    (await this.prod.changeProductInfo(this.productInfo))
      .subscribe(
        res => {
          window.location.href = "/user-profile";
        },
        err => {
          console.log(err);
        }
      );
  }
}
