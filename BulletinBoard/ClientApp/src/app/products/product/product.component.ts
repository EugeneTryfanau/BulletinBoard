import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  productId!: number;
  private sub: any;
  product: any;

  constructor(private route: ActivatedRoute, private prod: ProductService) {
  }

  async ngOnInit() {

    this.route.paramMap.pipe(
      switchMap(params => params.getAll('productId')))
      .subscribe(data => this.productId = +data);

    this.product = await this.prod.getProductInfo(this.productId);
    console.log(this.product);
  }

}
