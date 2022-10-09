import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { catchError, EMPTY } from 'rxjs';
import { AddLinkToGroup, GroupDto, MicroLink } from 'src/app/shared/models';
import { GroupService } from 'src/app/shared/services/group.service';
import { LinkService } from 'src/app/shared/services/link.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { AddEditLinkDialogComponent } from '../dialog/add-edit-link-dialog/add-edit-link-dialog.component';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  data: GroupDto | null = null;
  simpleLinks: boolean = false;

  constructor(private route: ActivatedRoute,
    private service: LinkService,
    private groupService: GroupService,
    private dialog: MatDialog,
    private notification: NotificationService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((paramMap : ParamMap) => 
      this.groupService.getUserDashboard().subscribe((data: GroupDto) => this.data = data)
    );
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }

  addLink(): void {
    const dialog = this.dialog.open(AddEditLinkDialogComponent,
      {
        data: { title: 'Dodaj nowy link', icon: 'add', groupId: this.data?.id },
        width: '50%'
      });

    dialog.afterClosed()
      .subscribe((link: AddLinkToGroup | null) => {
        if(!!link) {
          this.service.addLink(link as AddLinkToGroup)
          .pipe(catchError((err, caught) => {
            this.notification.showError(err.message as string);
            return EMPTY;
          }))
          .subscribe((newLink: MicroLink) => {
            this.notification.showSuccess("Link dodany");
            this.data?.links.push(newLink);
          })
        }
      });
  }
} 