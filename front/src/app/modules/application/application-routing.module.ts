import { HomeComponent } from './pages/home/home.component';
import {RouterModule} from '@angular/router';
import { NgModule, Component } from '@angular/core';
import {DashboardComponent} from './pages/dashboard/dashboard.component';

const routesPainel = [
  { path : '', component: DashboardComponent, children : [
      { path : '', component: HomeComponent},
      { path : 'crud', loadChildren: '../crud/crud.module#CrudModule'},
      { path : 'finances', loadChildren: '../finances/finances.module#FinancesModule'},
   ]},

];
@NgModule({
  imports: [
    RouterModule.forChild(routesPainel)
  ],
  exports: [RouterModule]
})
export class ApplicationRoutingModule {

}
