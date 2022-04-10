import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class MewaHttpService {
  private urlAddres: string = '';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Access-Control-Allow-Origin': 'http://localhost:4200;http://localhost:5097',
      'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token'
    })
  };
  
  constructor(private http: HttpClient, private notificationService: NotificationService) { }

  get(path: string, params = {}): Observable<any> {
    return this.http.get<any>(
      `${this.urlAddres}${path}`, {
      headers: this.httpOptions.headers,
      params
    })
    .pipe(catchError((err) => this.handleError(err)))
  }

  put(path: string, body: Object = {}) {
    return this.http.put<any>(`${this.urlAddres}${path}`, body, this.httpOptions)
    .pipe(catchError((err) => this.handleError(err)))
  }

  post(path: string, body: Object = {}) {
    return this.http.post<any>(`${this.urlAddres}${path}`, body, this.httpOptions)
    .pipe(catchError((err) => this.handleError(err)))
  }

  delete(path: string, body: Object = {}) {
    return this.http.delete<any>(`${this.urlAddres}${path}`, {
      headers: this.httpOptions.headers,
      body
    })
    .pipe(catchError((err) => this.handleError(err)))
  }

  handleError(error: any): Observable<never> {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message 
    }
    else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    this.notificationService.showError(errorMessage);

    return throwError(() => error)
  }
}
