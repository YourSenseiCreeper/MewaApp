import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Link } from 'src/app/shared/models';
import { LinkService } from 'src/app/shared/services/link.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { AddEditLinkDialogComponent } from '../dialog/add-edit-link-dialog/add-edit-link-dialog.component';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  links: Link[] = [];
  simpleLinks: boolean = false;

  constructor(private route: ActivatedRoute,
    private service: LinkService,
    private dialog: MatDialog,
    private notification: NotificationService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      let userName = paramMap.get('userName') ? paramMap.get('userName') as string : '';
      this.service.getUserLinks(userName).subscribe(data => this.links = data);
    });
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }

  addLink(): void {
    let dialog = this.dialog.open(AddEditLinkDialogComponent,
      {
        data: { title: 'Dodaj nowy link', icon: 'add' },
        width: '50%'
      });
      dialog.componentInstance.onSave.subscribe(v => {
        this.service.addLink(v).subscribe(r => {
          if (r.success) {
           this.notification.showSuccess("Link dodany");
           dialog.componentInstance.close();
          } else {
           this.notification.showError(r.message as string);
          }
        })
      });
  }
} 