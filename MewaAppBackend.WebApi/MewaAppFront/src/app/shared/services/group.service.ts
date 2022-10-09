import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { GroupDto, MewaElementDto, MicroGroup } from "../models";
import { MewaHttpService } from "./mewa-http.service";

@Injectable({providedIn: 'any'})
export class GroupService {
    private service: MewaHttpService;

    constructor(@Inject(MewaHttpService) service: MewaHttpService) {
        this.service = service;
    }

    AddGroupToGroup(name: string, parentGroupId: number ): Observable<MewaElementDto> {
        return this.service.post('/group/AddGroupToGroup', {
            name: name,
            parentGroupId: parentGroupId
        });
    }
    
    getUserDashboard(): Observable<GroupDto> {
        return this.service.get('/group/GetUserGroup');
    }

    getGroupById(id: number): Observable<GroupDto> {
        return this.service.get(`/group/getGroup?Id=${id}`);
    }
}