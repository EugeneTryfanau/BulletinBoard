import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { AuthService } from '../../services/auth.service';
import { CategoryService } from '../../services/category.service';
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
    const user = await this.auth.loadUser();
    this.userId = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }

  create() {
    return this.prodService.createProduct({
      userId: this.userId,
      productName: this.productName,
      productDescription: this.productDescription,
      productCategoryId: this.productCategoryId,
      productPrice: this.productPrice,
      conditionIsNew: this.conditionIsNew
    });
  }
}
