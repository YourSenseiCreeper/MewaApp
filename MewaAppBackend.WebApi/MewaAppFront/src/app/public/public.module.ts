import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { PublicRoutingModule } from './public-routing.module';
import { MatChipsModule } from '@angular/material/chips';
import { SingleFolderCardComponent } from '../user/single-folder-card/single-folder-card.component';
import { MatCardModule } from "@angular/material/card";
import { SingleLinkCardComponent } from '../user/single-link-card/single-link-card.component';
import { MatIconModule } from "@angular/material/icon";
import { CustomslicePipe } from "../shared/usefulTools/customslice.pipe";
import { MatMenuModule } from "@angular/material/menu";
import { FooterComponent } from './home/footer/footer.component';
import { NavComponent } from './home/nav/nav.component';
import { PageContentComponent } from './home/page-content/page-content.component';
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { ReactiveFormsModule } from "@angular/forms";
import { SlideOneComponent } from './home/page-content/slide-one/slide-one.component';
import { SlideTwoComponent } from './home/page-content/slide-two/slide-two.component';
import { SlideThreeComponent } from './home/page-content/slide-three/slide-three.component';

@NgModule({
    declarations: [
        HomeComponent,
        SingleFolderCardComponent,
        SingleLinkCardComponent,
        CustomslicePipe,
        FooterComponent,
        NavComponent,
        PageContentComponent,
        SlideOneComponent,
        SlideTwoComponent,
        SlideThreeComponent
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
    MatMenuModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule
  ]
})
export class PublicModule { }
