import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  public titleRonaldo: string;
  public question: string;
  constructor(
    public dialogRef: MatDialogRef<DialogComponent>
  ) { }

  ngOnInit() {
  }

}
