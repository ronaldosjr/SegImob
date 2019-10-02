import {AfterViewInit, Component, Input, OnInit} from '@angular/core';
import {ChangeTitleService} from '../../../application/services/change-title.service';
import {CustomCrudButton} from '../../../types/block';

@Component({
  selector: 'app-crud-list',
  templateUrl: './crud-list.component.html',
  styleUrls: ['./crud-list.component.scss']
})
export class CrudListComponent implements OnInit, AfterViewInit {
  @Input()
  titleRonaldo: string;

  @Input()
  newButtonCaption: string;

  @Input()
  setFilter: Function;

  @Input()
  newRecord: Function;

  @Input()
  editRecord: Function;

  @Input()
  deleteRecord: Function;

  @Input()
  dataSource: any[];

  @Input()
  displayedColumns: any[];

  @Input()
  customButtons: CustomCrudButton[];

  @Input()
  showAddButton = true;

  constructor(private changeTitle: ChangeTitleService) {
    if (!this.customButtons) {
      this.customButtons = [];
    }
  }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.changeTitle.changeTitle(this.titleRonaldo);
  }

}
