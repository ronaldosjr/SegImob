import { SellerHttpService } from './../../../services/seller-http.service';
import { Seller } from './../../../../entities/seller';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoaderService } from 'src/app/modules/shared/services/loader.service';
import { MatSnackBar } from '@angular/material';
import { BaseCrudEdit } from 'src/app/modules/shared/common/crud/base-crud-edit/base-crud-edit';

@Component({
  selector: 'app-seller-edit',
  templateUrl: './seller-edit.component.html',
  styleUrls: ['./seller-edit.component.scss']
})
export class SellerEditComponent extends BaseCrudEdit<Seller> implements OnInit {

  constructor(
    private httpThis: SellerHttpService,
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
