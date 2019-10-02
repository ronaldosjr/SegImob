import { ProductHttpService } from './../../../services/product-http.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseCrudList } from 'src/app/modules/shared/common/crud/base-crud-list/base-crud-list';
import { Product } from 'src/app/modules/entities/product';
import { MatSort, MatDialog, MatSnackBar, MatTableDataSource } from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
import { LoaderService } from 'src/app/modules/shared/services/loader.service';

export interface ResourceDataTable {
  id: number;
  name: string;
  price: number;
}

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent  extends BaseCrudList<Product, ResourceDataTable> implements OnInit {

  @ViewChild(MatSort)
  sort: MatSort;

  constructor(
    private httpThis: ProductHttpService,
    private routerThis: Router,
    private dialogThis: MatDialog,
    private activatedRouteThis: ActivatedRoute,
    public snackBarThis: MatSnackBar,
    private loaderServiceThis: LoaderService
  ) {
    super(httpThis, routerThis, dialogThis, activatedRouteThis, snackBarThis, loaderServiceThis);
  }

  ngOnInit() {
    this.loadContent();
  }

  convertToDataTable() {
    this.materialDataSource = [];
    this.dataSource = new MatTableDataSource<ResourceDataTable>([]);

    this.entities.forEach(p => {
      this.materialDataSource.push({
        id: p.id,
        name : p.name,
        price: p.price
      });
    });

    this.dataSource = new MatTableDataSource<ResourceDataTable>(this.materialDataSource);
    this.displayedColumns = ['name', 'price', 'id'];
    this.dataSource.sort = this.sort;
  }

}
