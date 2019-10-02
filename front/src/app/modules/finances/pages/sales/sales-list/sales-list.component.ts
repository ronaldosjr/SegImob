import { SalesHttpService } from './../../../services/sales-http.service';
import { Sales } from './../../../../entities/sales';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseCrudList } from 'src/app/modules/shared/common/crud/base-crud-list/base-crud-list';
import { MatSort, MatDialog, MatSnackBar, MatTableDataSource } from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
import { LoaderService } from 'src/app/modules/shared/services/loader.service';

export interface SalesDataTable {
  id: number;
  total: number;
  seller: string;
}

@Component({
  selector: 'app-sales-list',
  templateUrl: './sales-list.component.html',
  styleUrls: ['./sales-list.component.scss']
})
export class SalesListComponent extends BaseCrudList<Sales, SalesDataTable> implements OnInit {

  @ViewChild(MatSort)
  sort: MatSort;

  constructor(
    private httpThis: SalesHttpService,
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
    this.dataSource = new MatTableDataSource<SalesDataTable>([]);

    this.entities.forEach(p => {
      this.materialDataSource.push({
        id: p.id,
        total: p.total,
        seller: p.seller.name
      });
    });

    this.dataSource = new MatTableDataSource<SalesDataTable>(this.materialDataSource);
    this.displayedColumns = ['seller', 'total', 'id'];
    this.dataSource.sort = this.sort;
  }

  delete(id: number){
    this.materialDataSource.splice(this.materialDataSource.findIndex(x => x.id === id),1);
    this.dataSource = new MatTableDataSource<SalesDataTable>(this.materialDataSource);
    this.httpThis.delete(id);
  }

}
