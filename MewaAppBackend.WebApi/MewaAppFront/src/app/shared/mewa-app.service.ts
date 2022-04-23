import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/internal/operators/map';
import { MewaHttpService } from './mewa-http.service';
import { AddGroup, AddLink, GroupDto, Link, LoginCommand, LoginCommandResult, RegisterCommand, RegisterCommandResult, SuccessResult, TagDto } from './models';

@Injectable({
  providedIn: 'root'
})
export class MewaAppService {

  constructor(private service: MewaHttpService) { }

  get(url: string): Observable<any> {
    return this.service.get(url);
  }
  
  getAllLinks(): Observable<Link[]> {
    return this.service.get("/link").pipe(map(data => this.mapLinks(data)))
  }

  addLink(newLink: AddLink): Observable<SuccessResult> {
    return this.service.post("/link/add", newLink);
  }

  editLink(existingLink: Link): Observable<SuccessResult> {
    return this.service.put('/link', existingLink);
  }

  deleteLink(id: number): Observable<any> {
    return this.service.delete("/link", { id: id });
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
      ownerId: rawLink.ownerId,
      thumbnailId: rawLink.thumbnailId ? rawLink.thumbnailId : null,
      thumbnailContent: rawLink.thumbnailContent ? rawLink.thumbnailContent : null,
      tags: rawLink.tags,
      groups: rawLink.groups
    } as Link;
    return link;
  }

  addGroup(newGroup: AddGroup): Observable<SuccessResult> {
    return this.service.post('/group', newGroup);
  }

  getAllGroups(): Observable<GroupDto[]> {
    return this.service.get('/group/getall');
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

  getAllTags(): Observable<TagDto[]> {
    return this.service.get('/tag').pipe(map(t => this.mapTags(t)))
  }

  private mapTags(tags: any[]): TagDto[] {
    return tags.map(t => this.mapTag(t));
  }

  private mapTag(rawTag: any): TagDto {
    let tag = {
      id: rawTag.id,
      name: rawTag.name,
      description: rawTag.desciption ? rawTag.desciption : null
    } as TagDto;
    return tag;
  }
}
