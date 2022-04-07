import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { PublicRoutingModule } from './public-routing.module';
import {MatChipsModule} from '@angular/material/chips';
import { SingleFolderCardComponent } from './home/single-folder-card/single-folder-card.component';
import { MatCardModule } from "@angular/material/card";

@NgModule({
    declarations: [
        HomeComponent,
        SingleFolderCardComponent
    ],
    exports: [
        SingleFolderCardComponent
    ],
  imports: [
    CommonModule,
    RouterModule,
    PublicRoutingModule,
    MatChipsModule,
    MatCardModule
  ]
})
export class PublicModule { }
