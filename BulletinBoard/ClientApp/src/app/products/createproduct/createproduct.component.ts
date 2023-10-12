import { Component } from '@angular/core';
import { ProductService } from '../../product.service';
import { AuthService } from '../../auth.service';
import { CategoryService } from '../../category.service';
import { firstValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-createproduct',
  templateUrl: './createproduct.component.html',
  styleUrls: ['./createproduct.component.css']
})
export class CreateproductComponent {

  userId: any = null;
  productName: any;
  productDescription: any;
  productCategoryId: any = 1;
  productPrice: any = 0;
  conditionIsNew: any = true;

  categories: any = [];

  constructor(private http: HttpClient, private prodService: ProductService, private auth: AuthService, private categoryService: CategoryService) {

  }

  async ngOnInit() {
    this.categories = await firstValueFrom(this.http.get<any>("/api/categories"));
    var user = this.auth
  }

  create() {
    return this.prodService.createProduct({
      /*userId: this.userId,*/
      productName: this.productName,
      productDescription: this.productDescription,
      productCategoryId: this.productCategoryId,
      productPrice: this.productPrice,
      conditionIsNew: this.conditionIsNew
    });
  }
}
