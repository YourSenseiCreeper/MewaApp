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
}