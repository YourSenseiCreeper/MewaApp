import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private route: ActivatedRoute,
    private service: LinkService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      let userName = paramMap.get('userName') ? paramMap.get('userName') as string : '';
      console.log(userName);
    });
    this.service.getUserLinks().subscribe(data => this.links = data);
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
} 