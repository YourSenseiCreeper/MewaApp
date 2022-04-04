import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./public/public.module').then(m => m.PublicModule), // Lazy load account module
    data: { preload: true }
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule), // Lazy load account module
    data: { preload: false }
  },
  {
    path: 'user',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule), // Lazy load account module
    data: { preload: false }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
