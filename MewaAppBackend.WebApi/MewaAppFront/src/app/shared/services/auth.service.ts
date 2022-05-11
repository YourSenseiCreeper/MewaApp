import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { LoginCommand, LoginCommandResult, RegisterCommand, RegisterCommandResult } from '../models';
import { MewaHttpService } from './mewa-http.service';

@Injectable({ providedIn: 'any' })
export class AuthService {
  private service: MewaHttpService;
  private UserTokenKeyName: string = "access_token";

    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
    }

  register(command: RegisterCommand): Observable<RegisterCommandResult> {
    return this.service.post("/User/Create", command).pipe(map(data => this.mapRegisterResult(data)))
  }

  mapRegisterResult(rawResult: any): RegisterCommandResult {
    return rawResult as RegisterCommandResult;
  }

  login(command: LoginCommand): Observable<LoginCommandResult> {
    return this.service.post("/User/Login", command).pipe(map(data => this.mapLoginResult(data)))
  }

  mapLoginResult(rawResult: any): LoginCommandResult {
    return rawResult as LoginCommandResult;
  }
  
  getUserToken(): string | null {
    return localStorage.getItem(this.UserTokenKeyName);
  }

  setUserToken(token: string): void {
    if (localStorage.getItem(this.UserTokenKeyName))
        localStorage.removeItem(this.UserTokenKeyName);
    
    localStorage.setItem(this.UserTokenKeyName, token);
  }
}