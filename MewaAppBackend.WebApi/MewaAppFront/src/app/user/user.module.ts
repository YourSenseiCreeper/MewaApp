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
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from './dialog/confirmation/confirmation-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddLinkDialogComponent } from './dialog/add-link-dialog/add-link-dialog.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { InlineLinkCardComponent } from './inline-link-card/inline-link-card.component';
import { MatChipsModule } from '@angular/material/chips';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
@NgModule({
  declarations: [
    UserComponent,
    DashboardComponent,
    NavbarComponent,
    FoldersComponent,
    FolderContentsComponent,
    ConfirmationDialogComponent,
    AddLinkDialogComponent,
    InlineLinkCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    UserRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatTooltipModule,
    MatGridListModule,
    PublicModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    MatAutocompleteModule,
    MatSlideToggleModule
  ]
})
export class UserModule { }
