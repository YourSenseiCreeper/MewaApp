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
  links: Link[] = [
    {
      id: 1,
      name: 'Link 1',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      isPublic: true,
      thumbnailId: null,
      ownerId: null,
      thumbnailContent: null,
      tags: [],
      groups: []
    },
    {
      id: 2,
      name: 'Link 2',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      isPublic: true,
      thumbnailId: null,
      ownerId: null,
      thumbnailContent: null,
      tags: [],
      groups: []
    },
    {
      id: 3,
      name: 'Link 3',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      isPublic: true,
      ownerId: null,
      thumbnailContent: null,
      tags: [],
      groups: []
    },
    {
      id: 4,
      name: 'Link 4',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      isPublic: true,
      ownerId: null,
      thumbnailContent: null,
      tags: [],
      groups: []
    },
    {
      id: 5,
      name: 'Link 5',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      isPublic: true,
      ownerId: null,
      thumbnailContent: null,
      tags: [],
      groups: []
    }
  ];
  simpleLinks: boolean = false;

  constructor(
    private route: ActivatedRoute,
    public service: LinkService,
    private dialog: MatDialog,
    private notification: NotificationService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.folderId = paramMap.get('id') ? paramMap.get('id') as string : '';
    });
  }

  addLink(): void {
    let dialog = this.dialog.open(AddEditLinkDialogComponent,
      {
        data: { title: 'Dodaj nowy link', icon: 'add' },
        width: '50%'
      });
      dialog.componentInstance.onSave.subscribe(v => {
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
