import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mobile-navbar',
  templateUrl: './mobile-navbar.component.html',
  styleUrls: ['./mobile-navbar.component.scss']
})
export class MobileNavbarComponent implements OnInit {

  navbarFixed: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  @HostListener('window:scroll') onScroll() {
    this.navbarFixed = window.scrollY > 0 ;
  }

  logout() {
    localStorage.removeItem('access_token');
    this.router.navigate(['/']);
  }

}
