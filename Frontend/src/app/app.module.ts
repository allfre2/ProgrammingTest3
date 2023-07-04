import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductViewComponent } from './components/products/product-view/product-view.component';
import { UserViewComponent } from './components/users/user-view/user-view.component';
import { LoginViewComponent } from './components/login/login-view/login-view.component';
import { ApiService } from './services/api.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductViewComponent,
    UserViewComponent,
    LoginViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
