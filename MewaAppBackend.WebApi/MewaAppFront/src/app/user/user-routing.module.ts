import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FoldersComponent } from './folders/folders.component';
import { UserComponent } from './user/user.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: '',
        component: UserComponent,
        children: [
          { path: 'dashboard', component: DashboardComponent, data: { title: "Dashboard" } },
          { path: 'folders', component: FoldersComponent, data: { title: "Foldery" } }
          // { path: 'register', component: RegisterComponent, canActivate: [AppRouteGuard], data: { title: "Rejestracja"}  },
          // { path: 'change-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard], data: { title: "Zmiana hasła"}  }
        ]
      },
      // { path: ':userName', component: DashboardComponent },
      // { path: ':userName/:folder', component: DashboardComponent },

      // {path: '**', redirectTo: ''}
    ])
  ],
  exports: [RouterModule]
})
export class UserRoutingModule { }
