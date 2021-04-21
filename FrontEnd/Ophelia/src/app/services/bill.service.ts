import { Injectable } from "@angular/core";
import { BillModel } from "../models/Bill.model";
import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  private urlServices = "http://localhost:8080/api/Bill/";
  private getAllMethod = "GetAll/"
  private getByIdMethod = "GetById/"
  private addMethod = "Add/"
  private updateMethod = "Edit/"
  private deleteMethod = "Delete/"

  constructor(private http: HttpClient) { }

  public getAll(): Observable<any> {
    return this.http
      .get<BillModel[]>(this.urlServices + this.getAllMethod).pipe(
        map(this.extractData),
        catchError(this.handleError)
      );
  }

  getById(id: number): Observable<any> {
    return this.http.get<BillModel>(this.urlServices + this.getByIdMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  add(Bill: any): Observable<any> {
    return this.http.post(this.urlServices + this.addMethod, Bill).pipe(
      catchError(this.handleError)
    );
  }

  update(Bill: BillModel): Observable<any> {
    return this.http.put<BillModel>(this.urlServices + this.updateMethod, Bill).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete<BillModel>(this.urlServices + this.deleteMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): any {
    console.error('An error occurred:', error.error.message);
  }

  private extractData(res: BillModel[]): any {
    const body = res;
    return body || {};
  }
}
