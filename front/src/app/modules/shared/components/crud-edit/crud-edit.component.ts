import {AfterViewInit, Component, ContentChild, Input, OnInit, Output, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {ChangeTitleService} from '../../../application/services/change-title.service';

@Component({
  selector: 'app-crud-edit',
  templateUrl: './crud-edit.component.html',
  styleUrls: ['./crud-edit.component.scss']
})
export class CrudEditComponent implements AfterViewInit {

  @Input()
  public promiseGravar: Promise<any>;

  @ContentChild('crudEditContent') Content: Component | any;

  @Input()
  formSubmited: Function;

  @Input()
  backToList: Function;

  @Input()
  titlePage: string;

  @Input()
  f: NgForm;

  constructor(private changeTitle: ChangeTitleService) {

  }

  ngAfterViewInit() {
    this.changeTitle.changeTitle(this.titlePage);
  }

}
