import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CrudListComponent} from './components/crud-list/crud-list.component';
import {CrudEditComponent} from './components/crud-edit/crud-edit.component';
import {CoreModule} from '../core/core.module';
import {DialogComponent} from './components/dialog/dialog.component';
import {MatDialogModule, MatIconModule} from '@angular/material';
import {FlexLayoutModule} from '@angular/flex-layout';
import {LoadersCssModule} from 'angular2-loaders-css';
import {LoaderComponent} from './components/loader/loader.component';
import {Angular2PromiseButtonModule} from 'angular2-promise-buttons';
import { ValidadeValueDirective } from './directives/validade-value.directive';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    MatIconModule,
    FlexLayoutModule,
    LoadersCssModule,
    MatDialogModule,
    Angular2PromiseButtonModule.forRoot({
        // your custom config goes here
        spinnerTpl: '<span class="btn-spinner"></span>',
        // disable buttons when promise is pending
        disableBtn: true,
        // the class used to indicate a pending promise
        btnLoadingClass: 'is-loading',
        // only disable and show is-loading class for clicked button,
        // even when they share the same promise
        handleCurrentBtnOnly: false,
      }

    )
  ],
  entryComponents: [
    DialogComponent,
  ],
  exports: [
    DialogComponent,
    CrudEditComponent,
    CrudListComponent,
    FlexLayoutModule,
    LoaderComponent,
    MatDialogModule,
    ValidadeValueDirective
  ],
  declarations: [
    CrudListComponent,
    CrudEditComponent,
    DialogComponent,
    LoaderComponent,
    ValidadeValueDirective]
})
export class SharedModule {
}
