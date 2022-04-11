import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class MewaHttpService {
  private urlAddres: string = 'https://localhost:7097';
  
  constructor(private http: HttpClient, private notificationService: NotificationService) { }

  request(method: string, path: string, body: Object = {}): Observable<any> {
    return this.http.request(method, `${this.urlAddres}${path}`, {
      body: JSON.stringify(body),
      observe: "response",
      responseType: "json",
      headers: new HttpHeaders({
        "Content-Type": "application/json-patch+json",
        "Accept": "text/plain",
        'Access-Control-Allow-Origin': "*",
      })
    }).pipe(catchError((err) => this.handleError(err)), map(r => r.body));
  }

  get(path: string): Observable<any> {
    return this.request("get", path);
  }

  put(path: string, body: Object = {}) {
    return this.request("put", path, body);
  }

  post(path: string, body: Object = {}) {
    return this.request("post", path, body);
  }

  delete(path: string, body: Object = {}) {
    return this.request("delete", path, body);
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
