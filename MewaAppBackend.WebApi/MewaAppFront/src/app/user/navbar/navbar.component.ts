import { Component, HostListener, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  navbarFixed: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute) { }

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

  redirectToFolder() {
    this.router.navigate(['./', '123qwe'], { relativeTo: this.route });
  }

  logout() {
    localStorage.removeItem('access_token');
    this.router.navigate(['/']);
  }

}
