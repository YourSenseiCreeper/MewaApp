import { Inject, Injectable } from '@angular/core';
import { MewaHttpService } from './mewa-http.service';

@Injectable({ providedIn: 'any' })
export class UserService {
  private service: MewaHttpService;

  constructor(@Inject(MewaHttpService) service: MewaHttpService) {
      this.service = service;
  }

}