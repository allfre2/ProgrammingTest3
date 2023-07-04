import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/model/product';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit, OnDestroy {

  products: Product[] = [];
  subscripcion1: Subscription | undefined;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.subscripcion1 = this.apiService.getAllProducts().subscribe(products => {
      this.products = products;
    });
  }

  ngOnDestroy(): void {
    this.subscripcion1?.unsubscribe();
  }
}
