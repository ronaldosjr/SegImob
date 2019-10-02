import { SellerEditComponent } from './pages/seller/seller-edit/seller-edit.component';
import { SellerListComponent } from './pages/seller/seller-list/seller-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CrudRoutingModule } from './crud-routing.module';
import { CoreModule} from '../core/core.module';
import { SharedModule} from '../shared/shared.module';
import { CrudIndexComponent} from './crud-index.component';

import { ProductListComponent } from './pages/product/product-list/product-list.component';
import { ProductEditComponent } from './pages/product/product-edit/product-edit.component';

@NgModule( {
  imports: [
    CommonModule,
    CrudRoutingModule,
    CoreModule,
    SharedModule,
  ],
  declarations: [
    CrudIndexComponent,
    SellerListComponent,
    SellerEditComponent,
    ProductListComponent,
    ProductEditComponent]
})
export class CrudModule { }
