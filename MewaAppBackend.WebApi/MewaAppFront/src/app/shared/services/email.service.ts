import { Injectable } from '@angular/core';

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
