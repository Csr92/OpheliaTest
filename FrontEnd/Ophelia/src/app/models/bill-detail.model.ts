import { BillModel } from "./bill.model"
import { ProductModel } from "./product.model"

export class BillDetailModel {
    public Id:number
        public IdProduct:number
        public  IdBill:number
        public  Qty:number
        public  Total:number
        public Bill:BillModel 
        public Product :ProductModel
}
