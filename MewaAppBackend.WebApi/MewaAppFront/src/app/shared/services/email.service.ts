import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  email: string = '';

  public getMessage(): string {
    return this.email;
  }

  public setMessage(message: string): void {
    this.email = message;
  }
}
