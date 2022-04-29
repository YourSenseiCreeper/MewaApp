import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatMenuModule } from "@angular/material/menu";
import { RouterModule } from '@angular/router';
import { CustomslicePipe } from "../shared/usefulTools/customslice.pipe";
import { FooterComponent } from './home/footer/footer.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './home/nav/nav.component';
import { PageContentComponent } from './home/page-content/page-content.component';
import { SlideOneComponent } from './home/page-content/slide-one/slide-one.component';
import { SlideThreeComponent } from './home/page-content/slide-three/slide-three.component';
import { SlideTwoComponent } from './home/page-content/slide-two/slide-two.component';
import { PublicRoutingModule } from './public-routing.module';

@NgModule({
    declarations: [
        HomeComponent,
        CustomslicePipe,
        FooterComponent,
        NavComponent,
        PageContentComponent,
        SlideOneComponent,
        SlideTwoComponent,
        SlideThreeComponent
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
