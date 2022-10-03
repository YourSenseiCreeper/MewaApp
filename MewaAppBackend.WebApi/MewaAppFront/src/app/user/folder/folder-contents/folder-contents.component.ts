import { Component, OnInit } from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute } from '@angular/router';
import { catchError, EMPTY } from 'rxjs';
import { Link } from 'src/app/shared/models';
import { LinkService } from 'src/app/shared/services/link.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { AddEditLinkDialogComponent } from '../../dialog/add-edit-link-dialog/add-edit-link-dialog.component';

@Component({
  selector: 'app-folder-contents',
  templateUrl: './folder-contents.component.html',
  styleUrls: ['./folder-contents.component.scss']
})
export class FolderContentsComponent implements OnInit {

  folderId: string = '';
  links: Link[] | null = null;
  simpleLinks: boolean = false;

  constructor(
    private route: ActivatedRoute,
    public service: LinkService,
    private dialog: MatDialog,
    private notification: NotificationService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => 
      this.folderId = paramMap.get('id') ? paramMap.get('id') as string : ''
    );
  }

  addLink(): void {
    let dialog = this.dialog.open(AddEditLinkDialogComponent,
      {
        data: { title: 'Dodaj nowy link', icon: 'add' },
        width: '50%'
      });
      
    dialog.afterClosed().subscribe(v => {
      this.service.addLink(v)
        .pipe(catchError((err, caught) => {
          this.notification.showError(err as string);
          return EMPTY;
        }))
        .subscribe(r => {
          this.notification.showSuccess("Link dodany");
          dialog.componentInstance.close();
        })
    });
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
}
