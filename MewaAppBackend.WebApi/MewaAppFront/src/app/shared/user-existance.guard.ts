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
        let userName = route.params['userName'];
        if (!!userName) {
            let result = await this.userService.exists(userName).toPromise();
            if (!result)
                this._router.navigate(['/']);
            return result ?? false;
        }
        else
            this._router.navigate(['/']);

        return false;
    }

    async canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        return await this.canActivate(route, state);
    }
}