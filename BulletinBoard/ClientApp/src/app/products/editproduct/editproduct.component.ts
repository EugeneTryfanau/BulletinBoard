import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';

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

  slideIndex: number = 1;
  slideChanged: boolean = false;

  constructor(private route: ActivatedRoute, private prod: ProductService) {
  }

  async ngOnInit() {

    await this.route.paramMap.pipe(
      switchMap(params => params.getAll('productId')))
      .subscribe(data => this.productId = +data);

    this.product = await this.prod.getProductInfo(this.productId);
    this.pictures = this.product.pictures;
    for (let i = 0; i < this.pictures.length; i++) {
      this.picIndexes.push(i + 1);
    }
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
}
