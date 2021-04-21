import { Component, OnInit } from '@angular/core';
import { BillModel } from '../models/Bill.model';
import { BillService } from '../services/bill.service';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.scss']
})
export class BillComponent implements OnInit {
  dataSource: any = {};
  listBills: Array<BillModel>;
  constructor(private billService:BillService) { }

  ngOnInit(): void {
  }
  getBills():void{
    this.billService.getAll().subscribe((resp: BillModel[]) => {
      this.listBills = resp;
    });
  }

  getById(id: number):void{
    this.billService.getById(id).subscribe((resp: BillModel) => {
      console.log(resp)
    });
  }

  add(model: BillModel):void{
    this.billService.add(model).subscribe((resp: any) => {
      console.log(resp)
    });
  }

  update(model: BillModel):void{
    this.billService.update(model).subscribe((resp: BillModel) => {
      console.log(resp)
    });
  }

  delete(id: number):void{
    this.billService.delete(id).subscribe((resp: any) => {
      console.log(resp)
    });
  }
}
