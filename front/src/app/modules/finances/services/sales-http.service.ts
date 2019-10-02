import { Sales } from './../../entities/sales';
import { Injectable } from '@angular/core';
import { BaseHttp } from '../../core/services/common/BaseHttp';
import { HttpClient } from '@angular/common/http';

const endPoint = 'sales/';

@Injectable({
  providedIn: 'root'
})
export class SalesHttpService extends BaseHttp<Sales>  {

  constructor(private httpClient: HttpClient) {
    super(httpClient, endPoint);
  }

  comission(callBackSuccess?, callBackError?) {
    this.http.get<Sales[]>(this.path + 'comissions').subscribe(
      (data: Sales[]) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  salesDay(callBackSuccess?, callBackError?) {
    this.http.get<Sales[]>(this.path + 'sales/day').subscribe(
      (data: Sales[]) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  } 

}
