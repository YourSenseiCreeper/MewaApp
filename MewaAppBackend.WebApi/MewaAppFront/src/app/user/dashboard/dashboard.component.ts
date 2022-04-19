import { Component, OnInit } from '@angular/core';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [MewaAppService]
})
export class DashboardComponent implements OnInit {
  links: Link[] = [];

  constructor(public mewaService: MewaAppService) { }

  ngOnInit(): void {
    this.mewaService.getAllLinks().subscribe(data => this.links = data);
  }
} 