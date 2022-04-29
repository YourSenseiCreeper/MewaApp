import { Component, OnInit } from '@angular/core';
import { Link } from 'src/app/shared/models';
import { LinkService } from 'src/app/shared/services/link.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  links: Link[] = [];
  simpleLinks: boolean = false;

  constructor(private service: LinkService) { }

  ngOnInit(): void {
    this.service.getUserLinks().subscribe(data => this.links = data);
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
} 