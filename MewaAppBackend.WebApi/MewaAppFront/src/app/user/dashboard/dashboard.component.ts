import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { AddLinkDialogComponent } from '../dialog/add-link-dialog/add-link-dialog.component';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [MewaAppService]
})
export class DashboardComponent implements OnInit {
  links: Link[] = [];
  simpleLinks = false;

  constructor(public mewaService: MewaAppService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.mewaService.getAllLinks().subscribe(data => this.links = data);
  }

  addLink() {
    this.dialog.open(AddLinkDialogComponent, { width: '50%' });
  }

  toggleChange() {
    this.simpleLinks = !this.simpleLinks;
  }
} 