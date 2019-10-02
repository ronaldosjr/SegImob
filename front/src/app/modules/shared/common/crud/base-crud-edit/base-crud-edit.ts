import {ContentChild, ContentChildren, OnInit, ViewChild} from '@angular/core';
import {BaseHttp} from '../../../../core/services/common/BaseHttp';
import {ActivatedRoute, Router} from '@angular/router';
import {CrudEditComponent} from '../../../../shared/components/crud-edit/crud-edit.component';
import {LoaderService} from '../../../services/loader.service';
import { MatSnackBarConfig, MatSnackBar } from '@angular/material';

export class BaseCrudEdit<T> implements OnInit {

  public entity: T = {} as T;
  public isEditing = false;
  public idParam: number;
  public error: string;
  public promiseGravar: Promise<any>;
  public config: MatSnackBarConfig = new MatSnackBarConfig();

  @ViewChild(CrudEditComponent) crudEditor: CrudEditComponent;

  constructor(
    protected http: BaseHttp<T>,
    protected router: Router,
    protected activatedRoute: ActivatedRoute,
    protected loaderService: LoaderService,
    protected snackBar: MatSnackBar
  ) {
    if (this.activatedRoute.snapshot.params['id']) {
      this.idParam = this.activatedRoute.snapshot.params['id'];
      this.isEditing = true;
    }
    this.config.duration = 3000;
  }

  public loadContent(id: number, callBackSuccess?) {
    this.loaderService.isLoading = true;
    this.http.get(id,
      (data: T) => {
        this.entity = data;
        if (callBackSuccess) {
          callBackSuccess();
        }
        this.loaderService.isLoading = false;
      },
      (error) => {
        this.loaderService.isLoading = false;
        this.snackBar.open(error, '', this.config);
      });
  }

  public formSubmited(onError?: any) {

    this.promiseGravar = new Promise((resolve, reject) => {
      const error = (erros: any) => {
        this.error = erros;

        if (onError) {
          onError(this.error);
        }
        reject();
      };

      const saveOk = (data: T) => {
        resolve();
        this.backToList();
      };

      this.isEditing
        ? this.http.update(this.entity, saveOk, error)
        : this.http.add(this.entity, saveOk, error);
    });


  }

  public backToList() {
    this.isEditing
      ? this.router.navigate(['../..'], { relativeTo : this.activatedRoute})
      : this.router.navigate(['..'], {relativeTo : this.activatedRoute});
  }

  ngOnInit() {
    if (this.isEditing) {
      this.loadContent(this.idParam);
    }
  }


}
