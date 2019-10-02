import { environment } from './../../../../../environments/environment';
import {HttpClient} from '@angular/common/http';


export abstract class BaseHttp<T> {
  
  public static _server = environment.server_address + '/api/';
  protected readonly path: string;

  static handleCallBack(callBack, data) {
    if (callBack) {
      callBack(data);
    }
  }

  static handleErroCallBack(callBack, error) {
    if (callBack) {
      let msg = error.error ? error.error : error;
      if (error['status'] === 0) {
        msg = 'Não foi possível se conectar ao servidor';
      }
      callBack(msg);
    }
  }

  protected constructor(
    protected http: HttpClient,
    private endPoint: string
  ) {
    this.path = BaseHttp._server + endPoint;
  }

  getAll(callBackSuccess?, callBackError?) {
    this.http.get<T[]>(this.path).subscribe(
      (data: T[]) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  add(obj, callBackSuccess?, callBackError?) {
    return this.http.post<T>(this.path, obj).subscribe(
      (data: T) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  update(obj, callBackSuccess?, callBackError?) {
    this.http.put<T>(this.path, obj).subscribe(
      (data: T) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  delete(obj, callBackSuccess?, callBackError?) {
    this.http.delete(this.path + obj).subscribe(
      (data?: any) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  get(obj: number, callBackSuccess?, callBackError?) {
    this.http.get<T>(this.path + obj).subscribe(
      (data: T) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));
  }

  validateDelete(id: number, callBackSuccess?, callBackError?) {
    this.http.get<boolean>(this.path + `validate/delete/${id}`).subscribe(
      (data: boolean) => BaseHttp.handleCallBack(callBackSuccess, data),
      (error) => BaseHttp.handleErroCallBack(callBackError, error));

  }

}
