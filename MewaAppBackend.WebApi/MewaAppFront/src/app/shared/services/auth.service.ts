import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { LoginCommand, RegisterCommand, RegisterCommandResult, TokenDTO } from '../models';
import { CurrentUserService } from './current-user.service';
import { MewaHttpService } from './mewa-http.service';

@Injectable({ providedIn: 'any' })
export class AuthService {
  private service: MewaHttpService;
  private currentUserService: CurrentUserService;
  private UserTokenKeyName: string = "access_token";


  constructor(
    @Inject(MewaHttpService) service: MewaHttpService,
    @Inject(CurrentUserService) currentUserService: CurrentUserService) {
      this.service = service;
      this.currentUserService = currentUserService;
  }

  register(command: RegisterCommand): Observable<RegisterCommandResult> {
    return this.service.post("/User/Create", command).pipe(map(data => this.mapRegisterResult(data)))
  }

  mapRegisterResult(rawResult: any): RegisterCommandResult {
    return rawResult as RegisterCommandResult;
  }

  login(command: LoginCommand): Observable<TokenDTO> {
    return this.service.post("/User/Login", command);
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