import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { MewaHttpService } from './mewa-http.service';
import { Link } from './models';

@Injectable({
  providedIn: 'root'
})
export class MewaAppService {

  constructor(private service: MewaHttpService) { }

  getAllLinks(): Observable<Link[]> {
    return this.service.request("get", "https://localhost:7097/api/link").pipe(map(data => this.mapLinks(data)))
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

}
