import { SalesHttpService } from './../../../finances/services/sales-http.service';
import { Component, OnInit } from '@angular/core';
import { Sales } from 'src/app/modules/entities/sales';

export interface Comission{
  sellerName?: string;
  comission?: number;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public comissions: Comission[];
  public sales: Sales[];
  constructor(private salesHttpService: SalesHttpService) { }

  ngOnInit() {
    this.salesHttpService.comission((data: Comission[]) => {
      this.comissions = data;
    });

    this.salesHttpService.salesDay((data: Sales[]) => {
      this.sales = data;
    });
  }

}
