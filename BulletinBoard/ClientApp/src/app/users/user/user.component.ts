import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ChangePassword } from '../../services/models/changepassword';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  userDetails: any;
  userId: any;
  userProducts: any;
  productsInGroups: any = [];

  passModel: ChangePassword = new ChangePassword;

  constructor(private router: Router, private auth: AuthService, private prod: ProductService) { }

  async ngOnInit() {
    const user = await this.auth.loadUser();
    this.userId = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    console.log(this.userId);
    this.userDetails = await this.auth.getUserProfile(this.userId);
    console.log(this.userDetails);
    this.resetForm();

    let size = 5;
    this.userProducts = await this.prod.getUsersProducts(this.userId);
    for (let i = 0; i < Math.ceil(this.userProducts.length / size); i++) {
      this.productsInGroups[i] = this.userProducts.slice((i * size), (i * size) + size);
    }
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.passModel = {
      userId: this.userId,
      newPassword: ""
    }
  }

  async changePassword(form: NgForm) {
    (await this.auth.changePassword(form.value))
    .subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    );
  }

  async deleteAccount(userId: string) {
    return this.auth.deleteAccount(userId);
  }

  async deleteUserProductById(productId: number) {
    return this.prod.deleteUserProductById(productId);
  }
}
