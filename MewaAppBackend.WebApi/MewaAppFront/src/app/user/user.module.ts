import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { RouterModule } from '@angular/router';
import { UserRoutingModule } from './user-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatGridListModule } from '@angular/material/grid-list';
import { PublicModule } from '../public/public.module';
import { FoldersComponent } from './folders/folders.component';
import { FolderContentsComponent } from './folder-contents/folder-contents.component';

@NgModule({
  declarations: [
    UserComponent,
    DashboardComponent,
    NavbarComponent,
    FoldersComponent,
    FolderContentsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    UserRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatTooltipModule,
    MatGridListModule,
    PublicModule
  ]
})
export class UserModule { }
