import { Injectable } from '@angular/core';
import { BaseHttp } from '../../core/services/common/BaseHttp';
import { Seller } from '../../entities/seller';
import { HttpClient } from '@angular/common/http';

const endPoint = 'seller/';

@Injectable({
  providedIn: 'root'
})
export class SellerHttpService extends BaseHttp<Seller> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, endPoint);
  }

  getByName(name: string, callBackSucces?, callBackError?) {
    this.http.get<Seller[]>(this.path + 'by/name/' + encodeURI(name) ).subscribe(
      (data: Seller[]) =>  BaseHttp.handleCallBack(callBackSucces, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error) );
  }

}
