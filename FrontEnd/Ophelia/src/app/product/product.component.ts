import { Component, OnInit } from '@angular/core';
import { ProductModel } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  dataSource: any = {};
  listproducts: Array<ProductModel>;
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
  }
  getproducts():void{
    this.productService.getAll().subscribe((resp: ProductModel[]) => {
      this.listproducts = resp;
    });
  }

  getById(id: number):void{
    this.productService.getById(id).subscribe((resp: ProductModel) => {
      console.log(resp)
    });
  }

  add(model: ProductModel):void{
    this.productService.add(model).subscribe((resp: any) => {
      console.log(resp)
    });
  }

  update(model: ProductModel):void{
    this.productService.update(model).subscribe((resp: ProductModel) => {
      console.log(resp)
    });
  }

  delete(id: number):void{
    this.productService.delete(id).subscribe((resp: any) => {
      console.log(resp)
    });
  }
}
