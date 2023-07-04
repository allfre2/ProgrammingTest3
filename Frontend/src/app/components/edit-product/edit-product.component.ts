import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/model/product';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit, OnDestroy {

  productId?: number;
  product?: Product;
  sub?: Subscription;


  constructor(private route: ActivatedRoute,
    private apiService: ApiService) {}

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe((params : ParamMap) => {
      console.log(params.get('id'));
      
      this.apiService.getProduct(Number(params.get('id'))).subscribe(product => {
        console.log('product', product);
        this.product = product;
      });
    });

  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
}
