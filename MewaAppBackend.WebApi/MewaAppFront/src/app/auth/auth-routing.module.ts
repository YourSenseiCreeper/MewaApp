import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  imports: [
      RouterModule.forChild([
        { path: '', component: LoginComponent, data: { title: "Logowanie"} },
        { path: 'register', component: RegisterComponent, data: { title: "Rejestracja"}  },
        //   {
        //       path: '',
        //       component: AuthComponent,
        //       children: [
        //           { path: 'login', component: LoginComponent, data: { title: "Logowanie"} },
        //           { path: 'register', component: RegisterComponent, data: { title: "Rejestracja"}  },
        //         //   { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
        //       ]
        //   },
        //   {path: '**', redirectTo: ''}
      ])
  ],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
