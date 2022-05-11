import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FolderContentsComponent } from './folder/folder-contents/folder-contents.component';
import { FolderContainerComponent } from './folder/folder-container/folder-container.component';
import { UserComponent } from './user/user.component';
import { UserExistanceGuard } from '../shared/user-existance.guard';

@NgModule({
  imports: [
    RouterModule.forChild([
      // { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: '',
        component: UserComponent,
        children: [
          { path: ':userName', component: DashboardComponent, data: { title: "Dashboard" }, canActivate: [UserExistanceGuard] },
          { path: 'folders', component: FolderContainerComponent, data: { title: "Foldery" } },
          { path: 'folder/:id', component: FolderContentsComponent, data: { title: "Folder Contents" } }
        ]
      },
      // {path: '**', redirectTo: ''}
    ])
  ],
  exports: [RouterModule]
})
export class UserRoutingModule { }
