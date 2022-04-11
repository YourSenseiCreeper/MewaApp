import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { PublicRoutingModule } from './public-routing.module';
import {MatChipsModule} from '@angular/material/chips';
import { SingleFolderCardComponent } from './home/single-folder-card/single-folder-card.component';
import { MatCardModule } from "@angular/material/card";
import { SingleLinkCardComponent } from './home/single-link-card/single-link-card.component';
import {MatIconModule} from "@angular/material/icon";
import {CustomslicePipe} from "../shared/usefulTools/customslice.pipe";

@NgModule({
    declarations: [
        HomeComponent,
        SingleFolderCardComponent,
        SingleLinkCardComponent,
        CustomslicePipe
    ],
  exports: [
    SingleFolderCardComponent,
    SingleLinkCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    PublicRoutingModule,
    MatChipsModule,
    MatCardModule,
    MatIconModule,
  ]
})
export class PublicModule { }
