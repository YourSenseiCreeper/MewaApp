import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { map } from "rxjs/internal/operators/map";
import { TagDto } from "../models";
import { MewaHttpService } from "./mewa-http.service";

@Injectable({providedIn: 'any'})
export class TagService {
    private service: MewaHttpService;

    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
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