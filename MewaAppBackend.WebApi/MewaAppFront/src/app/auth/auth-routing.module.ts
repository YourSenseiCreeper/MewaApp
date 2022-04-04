import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';

@NgModule({
  imports: [
      RouterModule.forChild([
          {
              path: '',
              component: AuthComponent,
              // children: [
              //     { path: 'login', component: LoginComponent, canActivate: [AppRouteGuard], data: { title: "Logowanie"} },
              //     { path: 'register', component: RegisterComponent, canActivate: [AppRouteGuard], data: { title: "Rejestracja"}  },
              //     { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
              // ]
          },
          {path: '**', redirectTo: ''}
      ])
  ],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
