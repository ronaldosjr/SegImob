import { Seller } from './../../../../entities/seller';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseCrudList } from 'src/app/modules/shared/common/crud/base-crud-list/base-crud-list';
import { SellerHttpService } from '../../../services/seller-http.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatSnackBar, MatTableDataSource, MatSort } from '@angular/material';
import { LoaderService } from 'src/app/modules/shared/services/loader.service';

export interface ResourceDataTable {
  id: number;
  name: string;
}

@Component({
  selector: 'app-seller-list',
  templateUrl: './seller-list.component.html',
  styleUrls: ['./seller-list.component.scss']
})
export class SellerListComponent extends BaseCrudList<Seller, ResourceDataTable> implements OnInit {

  @ViewChild(MatSort)
  sort: MatSort;

  constructor(
    private httpThis: SellerHttpService,
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
        name : p.name
      });
    });

    this.dataSource = new MatTableDataSource<ResourceDataTable>(this.materialDataSource);
    this.displayedColumns = ['name', 'id'];
    this.dataSource.sort = this.sort;
  }

}

