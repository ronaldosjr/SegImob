import { ProductHttpService } from './../../../services/product-http.service';
import { Product } from './../../../../entities/product';
import {BaseCrudEdit} from '../../../../shared/common/crud/base-crud-edit/base-crud-edit';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {LoaderService} from '../../../../shared/services/loader.service';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent extends BaseCrudEdit<Product> implements OnInit{

  public msk: any = {
    mask: Number,
    scale: 2,
    signed: false,
    thousandsSeparator: '.',
    radix: ',',
    normalizeZeros: true,
    padFractionalZeros: true
  };

  constructor(
    private httpThis: ProductHttpService,
    private routerThis: Router,
    private activatedRouteThis: ActivatedRoute,
    private loaderServiceThis: LoaderService,
    private snackBarThis: MatSnackBar,
  ) {
    super(httpThis, routerThis, activatedRouteThis, loaderServiceThis, snackBarThis);
  }

  ngOnInit() {
    if (this.idParam) {
      this.loadContent(this.idParam);
    }
  }

  formSubmited(){
    super.formSubmited((error: string) => {
      this.snackBar.open(error, '', this.config);
    });
  }
}
