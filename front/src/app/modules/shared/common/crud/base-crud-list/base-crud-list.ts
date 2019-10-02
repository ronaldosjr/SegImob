import {BaseHttp} from '../../../../core/services/common/BaseHttp';
import {ActivatedRoute, Router} from '@angular/router';
import {MatDialog, MatSnackBar, MatTableDataSource, MatSnackBarConfig} from '@angular/material';
import {DialogComponent} from '../../../components/dialog/dialog.component';
import {LoaderService} from '../../../services/loader.service';
import { List } from 'linqts';

export abstract class BaseCrudList<TEntity, TColumnData> {

  public entities: TEntity[] = [];
  public displayedColumns = [];
  public dataSource = new MatTableDataSource<TColumnData>([]);
  public materialDataSource: TColumnData[] = [];
  public config: MatSnackBarConfig = new MatSnackBarConfig();

  protected constructor(private http: BaseHttp<TEntity>,
                        private router: Router,
                        private dialog: MatDialog,
                        private activatedRoute: ActivatedRoute,
                        public snackBar: MatSnackBar,
                        public loaderService: LoaderService) {
    this.config.duration = 3000;
  }

  newRecord() {
    this.router.navigate(['edit'], {relativeTo: this.activatedRoute});
  }

  editRecord(id: number) {
    this.router.navigate(['edit/' + id], {relativeTo: this.activatedRoute});
  }

  loadContent() {
    this.loaderService.isLoading = true;
    this.http.getAll(
      (data: TEntity[]) => {
        this.entities = data;
        if (this.entities[0] && this.entities[0]['id']) {
          this.entities = new List<TEntity>(data).OrderByDescending(i => i['id']).ToArray();
        }
        this.convertToDataTable();
        this.loaderService.isLoading = false;
      },
      (error) => {
        this.snackBar.open(error, '', this.config);
        this.loaderService.isLoading = false;
      }
    );
  }

  abstract convertToDataTable();

  deleteRecord(id: number, question?: string) {
    this.http.validateDelete(id, (hasRecords: boolean) => {
      if (!hasRecords) {
        const dialogRef = this.dialog.open(DialogComponent);
        dialogRef.componentInstance.titleRonaldo = 'Confirma exclusão?';
        dialogRef.componentInstance.question = question ? question : 'Esta operação não pode ser desfeita, tenha certeza de que realmente deseja excluir este registro?';
        dialogRef.afterClosed().subscribe(result => {
          if (result === true) {
            this.http.delete(id, () => {
                this.snackBar.open('Registro removido com sucesso', '', this.config);
                this.loadContent();
              },
              () => {
                this.snackBar.open('Não foi possível deletar o registro', '', this.config);
              });
          }
        });
      } else {
        this.snackBar.open('Não é possível deletar este registro porque ele está sendo utilizado por outro(s) registro(s).', '', this.config);
      }
    });

  }

  setFilter(filter: string) {
    this.dataSource.filter = filter.trim().toLocaleLowerCase();
  }

}
