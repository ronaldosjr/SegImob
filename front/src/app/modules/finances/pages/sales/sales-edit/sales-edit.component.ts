import { SalesHttpService } from './../../../services/sales-http.service';
import { Sales } from './../../../../entities/sales';
import { Component, OnInit } from '@angular/core';
import { BaseCrudEdit } from 'src/app/modules/shared/common/crud/base-crud-edit/base-crud-edit';
import { Router, ActivatedRoute } from '@angular/router';
import { LoaderService } from 'src/app/modules/shared/services/loader.service';
import { MatSnackBar } from '@angular/material';
import { Product } from 'src/app/modules/entities/product';
import { FormControl } from '@angular/forms';
import { Seller } from 'src/app/modules/entities/seller';
import { ProductHttpService } from 'src/app/modules/crud/services/product-http.service';
import { SellerHttpService } from 'src/app/modules/crud/services/seller-http.service';

@Component({
  selector: 'app-sales-edit',
  templateUrl: './sales-edit.component.html',
  styleUrls: ['./sales-edit.component.scss']
})
export class SalesEditComponent extends BaseCrudEdit<Sales> implements OnInit {
 
  public product: Product;
  public amount: number;
  public searchPerson: FormControl = new FormControl();
  public searchProduct: FormControl = new FormControl();
  public products: Product[];
  public sellers: Seller[];
  
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
    private httpThis: SalesHttpService,
    private routerThis: Router,
    private activatedRouteThis: ActivatedRoute,
    private loaderServiceThis: LoaderService,
    private snackBarThis: MatSnackBar,
    private httpProduct: ProductHttpService,
    private httpSeller: SellerHttpService
  ) {
    super(httpThis, routerThis, activatedRouteThis, loaderServiceThis, snackBarThis);

    this.searchProduct.valueChanges
      .subscribe(text => {
        if (!text) {
          this.products = [];
          return;
        }
        this.httpProduct.getByName(text, (data: Product[]) => this.products = data);
      });

    this.searchPerson.valueChanges
      .subscribe(text => {
        if (!text) {
          this.sellers = [];
          return;
        }
        this.httpSeller.getByName(text, (data: Seller[]) => this.sellers = data);
      });

    this.entity.salesItem = [];
    this.entity.total = 0;
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

  addOnSalesItem(product: Product){
    this.entity.salesItem.push({ amount: this.amount, product: this.product, total: product.price * this.amount });
    this.product = null;
    this.amount = null;
    this.searchProduct.setValue(null);
    this.setTotal();
  }

  setTotal() {
    this.entity.total = 0;
    this.entity.salesItem.forEach(x => this.entity.total += x.total);
  }

  delete(i: number){
    this.entity.salesItem.splice(i, 1);
  }
  

}
