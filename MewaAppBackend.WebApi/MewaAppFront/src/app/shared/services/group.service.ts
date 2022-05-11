import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { AddGroup, GroupDto, SuccessResult } from "../models";
import { MewaHttpService } from "./mewa-http.service";

@Injectable({providedIn: 'any'})
export class GroupService {
    private service: MewaHttpService;

    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
    }

    addGroup(newGroup: AddGroup): Observable<SuccessResult> {
        return this.service.post('/group', newGroup);
    }
    
    getAllGroups(): Observable<GroupDto[]> {
        return this.service.get('/group/getall');
    }
}