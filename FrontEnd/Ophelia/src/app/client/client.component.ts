import { Component, OnInit } from '@angular/core';
import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';

import { DxDataGridModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { ClientService } from '../services/client.service';
import { ClientModel } from '../models/client.model';

if (!/localhost/.test(document.location.host)) {
  enableProdMode();
}
@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  dataSource: any = {};
  listClients: Array<ClientModel>;

  constructor(httpClient: HttpClient, private clientService:ClientService) {
    function isNotEmpty(value: any): boolean {
      return value !== undefined && value !== null && value !== "";
    }
    this.getClients();
    this.dataSource = new CustomStore({
      key: "OrderNumber",
      load: function (loadOptions: any) {
        let params: HttpParams = new HttpParams();
        [
          "skip",
          "take",
          "requireTotalCount",
          "requireGroupCount",
          "sort",
          "filter",
         "totalSummary",
          "group",
          "groupSummary"
        ].forEach(function (i) {
          if (i in loadOptions && isNotEmpty(loadOptions[i]))
            params = params.set(i, JSON.stringify(loadOptions[i]));
        });
        return httpClient.get('https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/orders', { params: params })
          .toPromise()
          .then((data: any) => {
            return {
              data: data.data,
              totalCount: data.totalCount,
              summary: data.summary,
              groupCount: data.groupCount
            };
          })
          .catch(error => { throw 'Data Loading Error' });
      }
    });
  }

  ngOnInit(): void {
  }

  getClients():void{
    this.clientService.getAll().subscribe((resp: ClientModel[]) => {
      this.listClients = resp;
    });
  }

  getById(id: number):void{
    this.clientService.getById(id).subscribe((resp: ClientModel) => {
      console.log(resp)
    });
  }

  add(model: ClientModel):void{
    this.clientService.add(model).subscribe((resp: any) => {
      console.log(resp)
    });
  }

  update(model: ClientModel):void{
    this.clientService.update(model).subscribe((resp: ClientModel) => {
      console.log(resp)
    });
  }

  delete(id: number):void{
    this.clientService.delete(id).subscribe((resp: any) => {
      console.log(resp)
    });
  }
}


