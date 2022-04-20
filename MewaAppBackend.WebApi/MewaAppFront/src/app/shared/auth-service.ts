import { Injectable } from '@angular/core';

const userTokenKeyName: string = "access_token";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() { }

  getUserToken(): string | null {
    return localStorage.getItem(userTokenKeyName);
  }

  setUserToken(token: string): void {
    if (localStorage.getItem(userTokenKeyName))
        localStorage.removeItem(userTokenKeyName);
    
    localStorage.setItem(userTokenKeyName, token);
  }
}