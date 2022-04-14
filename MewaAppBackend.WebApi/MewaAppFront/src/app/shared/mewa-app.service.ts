import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { MewaHttpService } from './mewa-http.service';
import { Link, LoginCommand, LoginCommandResult, RegisterCommand, RegisterCommandResult } from './models';

@Injectable({
  providedIn: 'root'
})
export class MewaAppService {

  constructor(private service: MewaHttpService) { }

  getAllLinks(): Observable<Link[]> {
    return this.service.get("/link").pipe(map(data => this.mapLinks(data)))
  }

  mapLinks(links: any[]): Link[] {
    return links.map(l => this.mapLink(l));
  }

  mapLink(rawLink: any) {
    let link = {
      id: rawLink.id,
      url: rawLink.url,
      name: rawLink.name,
      description: rawLink.desciption ? rawLink.desciption : null,
      expiryDate: rawLink.expiryDate ? rawLink.expiryDate : null,
      userId: rawLink.userId,
      thumbnailId: rawLink.thumbnailId ? rawLink.thumbnailId : null,
    } as Link;
    return link;
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
}
