import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

@NgModule({
  imports: [
      RouterModule.forChild([
          {
              path: '',
              component: HomeComponent,
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
