import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { AddLinkToGroup, Link, MicroLink, SuccessResult } from "../models";
import { MewaHttpService } from "./mewa-http.service";

@Injectable({ providedIn: 'any' })
export class LinkService {
    private service: MewaHttpService;
    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
     }

    addLink(newLink: AddLinkToGroup): Observable<MicroLink> {
        return this.service.post("/link/AddLinkToGroup", newLink);
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
}