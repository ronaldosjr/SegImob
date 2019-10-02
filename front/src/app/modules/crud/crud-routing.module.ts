import { SellerEditComponent } from './pages/seller/seller-edit/seller-edit.component';
import { SellerListComponent } from './pages/seller/seller-list/seller-list.component';
import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CrudIndexComponent} from './crud-index.component';
import { ProductListComponent } from './pages/product/product-list/product-list.component';
import { ProductEditComponent } from './pages/product/product-edit/product-edit.component';

const routes: Routes = [
  {path: '', component: CrudIndexComponent},  
  {path: 'seller', component: SellerListComponent},
  {path: 'seller/edit', component: SellerEditComponent},
  {path: 'seller/edit/:id', component: SellerEditComponent},
  {path: 'product', component: ProductListComponent},
  {path: 'product/edit', component: ProductEditComponent},
  {path: 'product/edit/:id', component: ProductEditComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CrudRoutingModule {
}
