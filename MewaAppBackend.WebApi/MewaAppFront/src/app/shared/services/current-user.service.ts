import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'any' })
export class CurrentUserService {
    constructor() {}

    public setCurrentUser(username: string) {
        localStorage.setItem('current_user', username);
    }

    public removeCurrentUser() {
        localStorage.removeItem('current_user');
    }
}