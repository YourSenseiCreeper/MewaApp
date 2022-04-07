import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';

@NgModule({
  imports: [
      RouterModule.forChild([
          {
              path: '',
              component: UserComponent,
            //   children: [
                //   { path: 'register', component: RegisterComponent, canActivate: [AppRouteGuard], data: { title: "Rejestracja"}  },
                //   { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
            //   ]
          },
          { path: ':userName', component: DashboardComponent },
          { path: ':userName/:folder', component: DashboardComponent },

          // {path: '**', redirectTo: ''}
      ])
  ],
  exports: [RouterModule]
})
export class UserRoutingModule { }
