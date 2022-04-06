import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { PublicRoutingModule } from './public-routing.module';
import {MatChipsModule} from '@angular/material/chips';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    PublicRoutingModule,
    MatChipsModule
  ]
})
export class PublicModule { }
