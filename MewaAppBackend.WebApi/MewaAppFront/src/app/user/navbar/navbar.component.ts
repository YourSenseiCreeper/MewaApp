import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  navbarFixed: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  @HostListener('window:scroll') onScroll() {
    if(window.scrollY > 0) {
      this.navbarFixed = true;
    }
    else {
      this.navbarFixed = false;
    }
  }

  logout() {
    localStorage.removeItem('access_token');
    this.router.navigate(['/']);
  }

}
