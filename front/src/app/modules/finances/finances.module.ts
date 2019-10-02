import { SalesEditComponent } from './pages/sales/sales-edit/sales-edit.component';
import { SalesListComponent } from './pages/sales/sales-list/sales-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FinancesRoutingModule } from './finances-routing.module';
import {CoreModule} from '../core/core.module';
import {SharedModule} from '../shared/shared.module';
import {FinancesIndexComponent} from './finances-index.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    FinancesRoutingModule,
  ],
  declarations: [
    FinancesIndexComponent,
    SalesListComponent,
    SalesEditComponent
  ]
})
export class FinancesModule { }
