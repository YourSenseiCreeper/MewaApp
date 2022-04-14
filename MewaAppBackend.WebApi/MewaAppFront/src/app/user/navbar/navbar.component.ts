import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  navbarFixed: boolean = false;

  constructor() { }

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

}
