import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { LoginViewComponent } from './components/login/login-view/login-view.component';
import { ProductViewComponent } from './components/products/product-view/product-view.component';
import { UserViewComponent } from './components/users/user-view/user-view.component';

const routes: Routes = [
  { path: 'users', component: UserViewComponent },
  { path: 'products', component: ProductViewComponent },
  { path: 'products/:id', component: EditProductComponent },
  { path: 'login', component: LoginViewComponent },
  { path: '', component: LoginViewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
