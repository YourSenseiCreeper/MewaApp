import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({ providedIn: 'any' })
export class MewaHttpService {
  urlAddres: string = 'https://localhost:7097/api';
  
  constructor(private http: HttpClient) {}

  request(method: string, path: string, body: Object = {}): Observable<any> {
    let token = localStorage.getItem('access_token'); // nie można tu ustawić consta z auth.service.ts -> to powoduje circular dependency
    let headers: HttpHeaders;
    if (token) {
      headers = new HttpHeaders({
        "Content-Type": "application/json-patch+json",
        "Accept": "text/plain",
        'Access-Control-Allow-Origin': "*",
        'Authorization': token as string
      });
    } else {
      headers = new HttpHeaders({
        "Content-Type": "application/json-patch+json",
        "Accept": "text/plain",
        'Access-Control-Allow-Origin': "*"
      });
    }
    
    return this.http.request(method, `${this.urlAddres}${path}`, {
      body: JSON.stringify(body),
      observe: "response",
      responseType: "json",
      headers: headers
    }).pipe(catchError((err) => this.handleError(err)), map(r => r.body));
  }

  get(path: string, args: Object = {}): Observable<any> {
    let requestArgs = [];
    for(let kv of Object.entries(args)) {
      requestArgs.push(`${kv[0]}=${kv[1]}`);
    }
    let requestPath = path + '?' + requestArgs.join('&');
    return this.request("get", requestPath);
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
    // this.notificationService.showError(errorMessage);

    return throwError(() => error)
  }
}
