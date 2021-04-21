import { ClientModel } from "./client.model"
import { CompanyModel } from "./company.model"

export class BillModel {
    public Id :number
    public  IdClient :number
    public  IdCompany :number
    public  PurchaseDate :Date
    public  Total :number
    public  Client: ClientModel
    public  Company:CompanyModel
    public BillDetails :number
}