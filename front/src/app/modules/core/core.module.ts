import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MAT_DATE_LOCALE, MatAutocompleteModule,
  MatButtonModule, MatCardModule, MatCheckboxModule, MatDatepickerModule,
  MatDialogModule, MatFormFieldModule, MatGridListModule, MatIconModule,
  MatInputModule, MatListModule,
  MatMenuModule, MatOptionModule,
  MatPaginatorModule,
  MatProgressSpinnerModule, MatSelectModule, MatSidenavModule, MatSnackBarModule, MatSortModule,
  MatTableModule, MatToolbarModule, MatTooltipModule, MatTreeModule
} from '@angular/material';
import {LayoutModule} from '@angular/cdk/layout';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {IMaskModule} from 'angular-imask';
import {Ng2BRPipesModule} from 'ng2-brpipes';
import {MatMomentDateModule} from '@angular/material-moment-adapter';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IMaskModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSnackBarModule,
    MatTreeModule,
    MatSortModule,
    MatGridListModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatTooltipModule,
    MatAutocompleteModule,
    MatCheckboxModule,
    Ng2BRPipesModule
  ],
  exports : [
    ReactiveFormsModule,
    IMaskModule,
    MatCardModule,
    LayoutModule,
    MatTooltipModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSnackBarModule,
    MatTreeModule,
    MatSortModule,
    MatGridListModule,
    MatDatepickerModule,
    MatMomentDateModule,
    MatAutocompleteModule,
    MatCheckboxModule,
    Ng2BRPipesModule
  ],
  declarations: [],
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}
  ]
})
export class CoreModule { }
