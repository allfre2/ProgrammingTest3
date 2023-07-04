import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Product } from '../model/product';
import { DefaultConfig } from '../config/app-config';
import { Model } from '../model/model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  productsEndpoint = `${DefaultConfig.api}${DefaultConfig.port}${DefaultConfig.productsEndpoint}`;
  modelsEndpoint = `${DefaultConfig.api}${DefaultConfig.port}${DefaultConfig.modelsEndpoint}`;
  
  constructor(private httpClient: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.productsEndpoint).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  getProduct(n? : number): Observable<Product> {
    return this.httpClient.get<Product>(this.productsEndpoint + '/' + n).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  createProduct(product : Product) : Observable<Product> {
    return this.httpClient.post<Product>(this.productsEndpoint, product).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  updateProduct(product : Product) : Observable<Product> {
    return this.httpClient.put<Product>(this.productsEndpoint + '/' + product.id, product).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  deleteProduct(id : number) {
    return this.httpClient.delete(this.productsEndpoint + '/' + id);
  }

  getAllModels() : Observable<Model[]> {
    return this.httpClient.get<Model[]>(this.modelsEndpoint).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  getModel(id : number) : Observable<Model> {
    return this.httpClient.get<Model>(this.modelsEndpoint + '/single/' + id).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  createModel(model : Model) : Observable<Model> {
    return this.httpClient.post<Model>(this.modelsEndpoint, model).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  updateModel(model : Model) : Observable<Model> {
    return this.httpClient.put<Model>(this.modelsEndpoint + '/' + model.id, model).pipe(
      catchError((error : any) => {
        console.log('Ha ocurrido un error');
        console.error(error);

        return throwError(() => error);
      })
    );
  }

  deleteModel(id : number) {
    return this.httpClient.delete(this.modelsEndpoint + '/' + id);
  }
}
