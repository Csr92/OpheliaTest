import { Injectable } from "@angular/core";
import { ProductModel } from "../models/Product.model";
import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private urlServices = "http://localhost:8080/api/Product/";
  private getAllMethod = "GetAll/"
  private getByIdMethod = "GetById/"
  private addMethod = "Add/"
  private updateMethod = "Edit/"
  private deleteMethod = "Delete/"

  constructor(private http: HttpClient) { }

  public getAll(): Observable<any> {
    return this.http
      .get<ProductModel[]>(this.urlServices + this.getAllMethod).pipe(
        map(this.extractData),
        catchError(this.handleError)
      );
  }

  getById(id: number): Observable<any> {
    return this.http.get<ProductModel>(this.urlServices + this.getByIdMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  add(Product: any): Observable<any> {
    return this.http.post(this.urlServices + this.addMethod, Product).pipe(
      catchError(this.handleError)
    );
  }

  update(Product: ProductModel): Observable<any> {
    return this.http.put<ProductModel>(this.urlServices + this.updateMethod, Product).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete<ProductModel>(this.urlServices + this.deleteMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): any {
    console.error('An error occurred:', error.error.message);
  }

  private extractData(res: ProductModel[]): any {
    const body = res;
    return body || {};
  }
}
