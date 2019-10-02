import { SalesEditComponent } from './pages/sales/sales-edit/sales-edit.component';
import { SalesListComponent } from './pages/sales/sales-list/sales-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {FinancesIndexComponent} from './finances-index.component';

const routes: Routes = [
  { path: '', component: FinancesIndexComponent},
  { path: 'sales', component: SalesListComponent },
  { path: 'sales/edit', component: SalesEditComponent },
  { path: 'sales/edit/:id', component: SalesEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FinancesRoutingModule { }
