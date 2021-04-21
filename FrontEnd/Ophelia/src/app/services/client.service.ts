import { Injectable } from "@angular/core";
import { ClientModel } from "../models/client.model";
import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private urlServices = "http://localhost:8080/api/Client/";
  private getAllMethod = "GetAll/"
  private getByIdMethod = "GetById/"
  private addMethod = "Add/"
  private updateMethod = "Edit/"
  private deleteMethod = "Delete/"

  constructor(private http: HttpClient) { }

  public getAll(): Observable<any> {
    return this.http
      .get<ClientModel[]>(this.urlServices + this.getAllMethod).pipe(
        map(this.extractData),
        catchError(this.handleError)
      );
  }

  getById(id: number): Observable<any> {
    return this.http.get<ClientModel>(this.urlServices + this.getByIdMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  add(client: any): Observable<any> {
    return this.http.post(this.urlServices + this.addMethod, client).pipe(
      catchError(this.handleError)
    );
  }

  update(client: ClientModel): Observable<any> {
    return this.http.put<ClientModel>(this.urlServices + this.updateMethod, client).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete<ClientModel>(this.urlServices + this.deleteMethod + id).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): any {
    console.error('An error occurred:', error.error.message);
  }

  private extractData(res: ClientModel[]): any {
    const body = res;
    return body || {};
  }
}
