import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './users/login/login.component';
import { RegisterComponent } from './users/register/register.component';
import { UsersComponent } from './users/users.component';
import { CategoriesComponent } from './products/categories/categories.component';
import { CreateproductComponent } from './products/createproduct/createproduct.component';
import { ProductsComponent } from './products/products.component';
import { ProductComponent } from './products/product/product.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "users", component: UsersComponent },
  { path: "categories", component: CategoriesComponent },
  { path: "", component: ProductsComponent },
  { path: "products/product/:productId", component: ProductComponent },
  { path: "create-product", component: CreateproductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
