import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';

@NgModule({
  imports: [
      RouterModule.forChild([
          {
              path: '',
              component: UserComponent,
              // children: [
              //     { path: 'dashboard', component: LoginComponent, canActivate: [AppRouteGuard], data: { title: "Logowanie"} },
              //     { path: 'register', component: RegisterComponent, canActivate: [AppRouteGuard], data: { title: "Rejestracja"}  },
              //     { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
              // ]
          },
          // {path: '**', redirectTo: ''}
      ])
  ],
  exports: [RouterModule]
})
export class UserRoutingModule { }
