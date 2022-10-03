import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from "@angular/material/snack-bar";
import { catchError, EMPTY } from 'rxjs';
import { MicroLink } from 'src/app/shared/models';
import { LinkService } from 'src/app/shared/services/link.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { AddEditLinkDialogComponent } from '../../dialog/add-edit-link-dialog/add-edit-link-dialog.component';
import { ConfirmationDialogComponent } from '../../dialog/confirmation/confirmation-dialog.component';

@Component({
  selector: 'app-link-card',
  templateUrl: './link-card.component.html',
  styleUrls: [ './link-card.component.scss' ]
})
export class LinkCardComponent implements OnInit {
  @Input() link: MicroLink | null = null;

  imageUrl = "/assets/images/asp-net-core-identity-with-patterns-1.png";

  constructor(
    private snackBar: MatSnackBar,
    private service: LinkService,
    private notification: NotificationService,
    private dialog: MatDialog) { }

  ngOnInit(): void {

  }

  convertThumbnailBase64ToImage(base64: string | null): string {
    let result = '';
    const imageName = 'name.png';
    if (base64 === null) {
      return this.imageUrl;
    }
    const imageBlob = this.dataURItoBlob(base64);
    const imageFile = new File([imageBlob], imageName, { type: 'image/png' });

    var reader = new FileReader();

    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };

    reader.onerror = (event: any) => {
      console.log("File could not be read: " + event.target.error.code);
    };

    reader.readAsDataURL(imageFile);
    return result;
  }

  dataURItoBlob(dataURI: string): Blob {
    const byteString = window.atob(dataURI);
    const arrayBuffer = new ArrayBuffer(byteString.length);
    const int8Array = new Uint8Array(arrayBuffer);
    for (let i = 0; i < byteString.length; i++) {
      int8Array[i] = byteString.charCodeAt(i);
    }
    const blob = new Blob([int8Array], { type: 'image/png' });    
    return blob;
 }

  onCopy(): void {
    try {
      navigator.clipboard.writeText(this.link!.url);
      this.snackBar.open("Link was copied", 'Ok', {
        duration: 2000
      });
    }catch (e) {
      console.log(e);
    }
  }

  onEdit(): void {
    let dialog = this.dialog.open(AddEditLinkDialogComponent,
    {
      data: {
        link: this.link,
        title: 'Edycja linku'
      },
      width: '75%'
    });

    dialog.afterClosed()
      .pipe(catchError((err, caught) => {
        this.notification.showError(err as string);
        return EMPTY;
      }))
      .subscribe(v => {
        this.service.editLink(v).subscribe(r => {
          this.notification.showSuccess("Link zmieniony");
          dialog.componentInstance.close();
        })
      });
  }

  onDelete(): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '50%',
      data: {title: 'Usuwanie linku', text: "Czy na pewno chcesz usunąć ten link?"},
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.service 
          .deleteLink(this.link!.id)
          .subscribe(response => console.log('Link został usunięty'));
      }
    });
  }

}
