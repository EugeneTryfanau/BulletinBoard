import { Component, EventEmitter, Output } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { AuthService } from '../../services/auth.service';
import { CategoryService } from '../../services/category.service';
import { firstValueFrom } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-createproduct',
  templateUrl: './createproduct.component.html',
  styleUrls: ['./createproduct.component.css']
})
export class CreateproductComponent {

  progress: number = 0;
  message: string = "";
  @Output() public onUploadFinished = new EventEmitter();

  userId: any = null;
  productName: any;
  productDescription: any;
  productCategoryId: any = 1;
  productPrice: any = 0;
  conditionIsNew: any = true;

  productFile: any;

  categories: any = [];

  constructor(private http: HttpClient, private prodService: ProductService, private auth: AuthService, private categoryService: CategoryService) {

  }

  uploadFile = (files: FileList | null) => {
    if (files === null) {
      return;
    }
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, this.productName + "_" + this.userId + "." + fileToUpload.name.split('.')[1]);

    this.http.post("/api/upload", formData, { reportProgress: true, observe: 'events' })
      .subscribe({
        next: (event) => {
          if (event.type === HttpEventType.UploadProgress)
            this.progress = Math.round(100 * event.loaded / event.total!);
          else if (event.type === HttpEventType.Response) {
            this.message = 'Upload success.';
            this.onUploadFinished.emit(event.body);
          }
        },
        error: (err: HttpErrorResponse) => console.log(err)
      });
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
