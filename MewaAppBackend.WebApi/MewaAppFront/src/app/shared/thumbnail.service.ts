import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, throwError } from "rxjs";
import { NotificationService } from "./notification.service";

@Injectable({
    providedIn: "root"
})
export class ThumbnailService {

    constructor(private http: HttpClient, private notification: NotificationService) {}

    request(method: string, path: string, body: Object = {}): Observable<any> {
        return this.http.request(method, path, {
          body: JSON.stringify(body),
          observe: "response",
          responseType: "json",
          headers: new HttpHeaders({
            "Content-Type": "application/json-patch+json",
            "Accept": "text/plain",
            'Access-Control-Allow-Origin': "*",
          })
        }).pipe(catchError((err) => this.handleError(err)));
      }
    
      get(path: string): Observable<any> {
        return this.request("get", path);
      }
    
      handleError(error: any): Observable<never> {
        let errorMessage = '';
        if(error.error instanceof ErrorEvent){
          errorMessage = error.error.message 
        }
        else {
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        this.notification.showError(errorMessage);
    
        return throwError(() => error)
      }
}