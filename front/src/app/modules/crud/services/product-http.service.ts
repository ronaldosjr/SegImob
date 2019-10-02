import { Injectable } from '@angular/core';
import { BaseHttp } from '../../core/services/common/BaseHttp';
import { Product } from '../../entities/product';
import { HttpClient } from '@angular/common/http';

const endPoint = 'product/';

@Injectable({
  providedIn: 'root'
})
export class ProductHttpService extends BaseHttp<Product> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, endPoint);
  }

  getByName(name: string, callBackSucces?, callBackError?) {
    this.http.get<Product[]>(this.path + 'by/name/' + encodeURI(name) ).subscribe(
      (data: Product[]) =>  BaseHttp.handleCallBack(callBackSucces, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error) );
  }


}
