import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { PublicModule } from '../public/public.module';
import { GroupService } from '../shared/services/group.service';
import { LinkService } from '../shared/services/link.service';
import { NotificationService } from '../shared/services/notification.service';
import { TagService } from '../shared/services/tag.service';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddEditFolderDialogComponent } from './dialog/add-edit-folder/add-edit-folder-dialog.component';
import { AddEditLinkDialogComponent } from './dialog/add-edit-link-dialog/add-edit-link-dialog.component';
import { ConfirmationDialogComponent } from './dialog/confirmation/confirmation-dialog.component';
import { FolderContentsComponent } from './folder/folder-contents/folder-contents.component';
import { FolderContainerComponent } from './folder/folder-container/folder-container.component';
import { InlineLinkCardComponent } from './link/inline-link-card/inline-link-card.component';
import { LinkCardComponent } from './link/link-card/link-card.component';
import { NavbarComponent } from './navbar/navbar.component';
import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user/user.component';
import { FolderCardComponent } from './folder/folder-card/folder-card.component';
import { MatCardModule } from '@angular/material/card';
import { MobileNavbarComponent } from './navbar/mobile-navbar/mobile-navbar.component';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
  declarations: [
    UserComponent,
    DashboardComponent,
    NavbarComponent,
    FolderContainerComponent,
    FolderContentsComponent,
    FolderCardComponent,
    ConfirmationDialogComponent,
    AddEditLinkDialogComponent,
    InlineLinkCardComponent,
    LinkCardComponent,
    AddEditFolderDialogComponent,
    MobileNavbarComponent
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
    MatSlideToggleModule,
    HttpClientModule,
    MatSnackBarModule,
    MatCardModule,
    MatCheckboxModule,
  ],
  providers: [
    LinkService,
    GroupService,
    TagService,
    NotificationService,
  ]
})
export class UserModule { }
