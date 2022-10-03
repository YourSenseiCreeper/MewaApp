import { Injectable } from '@angular/core';

import {
    CanActivate, Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,
    CanActivateChild
} from '@angular/router';
import { UserService } from './services/user.service';

@Injectable({ providedIn: 'any' })
export class UserExistanceGuard implements CanActivate, CanActivateChild {

    constructor(
        private userService: UserService,
        private _router: Router) { }

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        return true;
    }

    async canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        return await this.canActivate(route, state);
    }
}