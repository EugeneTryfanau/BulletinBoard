import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './users/register/register.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './users/login/login.component';
import { FormsModule } from '@angular/forms';
import { ProductsComponent } from './products/products.component';
import { UsersComponent } from './users/users.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CategoriesComponent } from './products/categories/categories.component';
import { CreateproductComponent } from './products/createproduct/createproduct.component';
import { CategoryService } from './services/category.service';
import { ProductService } from './services/product.service';
import { ProductComponent } from './products/product/product.component';
import { UserComponent } from './users/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProductsComponent,
    UsersComponent,
    NavBarComponent,
    CategoriesComponent,
    CreateproductComponent,
    ProductComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthService, CategoryService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
