import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { AuthService } from '../../services/auth.service';
import { CategoryService } from '../../services/category.service';
import { firstValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { PicturesService } from '../../services/pictures.service';

@Component({
  selector: 'app-createproduct',
  templateUrl: './createproduct.component.html',
  styleUrls: ['./createproduct.component.css']
})
export class CreateproductComponent {

  emptyString: string = "";
  picturesData: any;

  userId: any = null;
  productName: string = "";
  productDescription: any = "";
  productCategoryId: any = 1;
  productPrice: any = 0;
  conditionIsNew: any = true;

  productPictures: any[] = [];

  categories: any = [];

  constructor(private http: HttpClient, private prodService: ProductService, private auth: AuthService,
    private categoryService: CategoryService, public pic: PicturesService) {
  }

  uploadFile = (files: FileList | null) => {
    if (files === null) {
      return;
    }
    if (files.length === 0) {
      return;
    }
    this.productPictures = Array.from(files);
    let filesToUpload: File[] = Array.from(files);
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, this.productName + "_" + this.userId + "_" + index + "." + file.name.split('.')[1]);
    });

    this.picturesData = formData;
  }

  async ngOnInit() {
    this.categories = await firstValueFrom(this.http.get<any>("/api/categories"));
    const user = await this.auth.loadUser();
    this.userId = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }

  async create() {
    await this.prodService.createProduct({
      userId: this.userId,
      productName: this.productName,
      productDescription: this.productDescription,
      productCategoryId: this.productCategoryId,
      productPrice: this.productPrice,
      conditionIsNew: this.conditionIsNew
    });
    let productId = await this.prodService.lastCreatedProductByUser(this.userId);
    await this.pic.uploadPicture(this.picturesData, productId);
  }
}
