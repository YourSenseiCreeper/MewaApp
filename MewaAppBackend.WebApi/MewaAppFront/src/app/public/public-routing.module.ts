import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MobileHomeComponent } from './mobile-home/mobile-home.component';

let isMobile = window.matchMedia("(max-width: 800px)")

@NgModule({
  imports: [
      RouterModule.forChild([
          {
              path: '',
              component: isMobile.matches ? MobileHomeComponent : HomeComponent,
              // children: [
              //     { path: 'public-links', component: LinksComponent, canActivate: [AppRouteGuard], data: { title: "Linki"} },
              //     { path: 'red', component: RedirectComponent, canActivate: [AppRouteGuard], data: { title: "Redirect"}  },
              //     { path: 'about-us', component: AboutUsComponent, canActivate: [AppRouteGuard], data: { title: "O nas"}  }
              // ]
          },
          // {path: '**', redirectTo: ''}
      ])
  ],
  exports: [RouterModule]
})
export class PublicRoutingModule { }
