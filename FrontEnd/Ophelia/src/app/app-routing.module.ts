import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BillComponent } from './bill/bill.component';
import { ClientComponent } from './client/client.component';
import { MenuComponent } from './menu/menu.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  {
    path: 'app-menu',
    component: MenuComponent, 
    },
    {
      path: 'app-bill', 
      component: BillComponent    
    },
    {
      path: 'app-client',
      component: ClientComponent, 
    },
    {
      path: 'app-product',
      component: ProductComponent, 
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
