import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { NotificationService } from 'src/app/shared/notification.service';
import { AddEditLinkDialogComponent } from '../dialog/add-edit-link-dialog/add-edit-link-dialog.component';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [MewaAppService]
})
export class DashboardComponent implements OnInit {
  links: Link[] = [];
  simpleLinks: boolean = false;

  constructor(
    public mewaService: MewaAppService,
    private notification: NotificationService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.mewaService.getAllLinks().subscribe(data => this.links = data);
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
} 