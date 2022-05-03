import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { MewaHttpService } from './mewa-http.service';

@Injectable({ providedIn: 'any' })
export class UserService {
  private service: MewaHttpService;

    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
    }

  exists(userName: string): Observable<boolean> {
    return this.service.get("/User/Exists", { userName: userName});
  }
}