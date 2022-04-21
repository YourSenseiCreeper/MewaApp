import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from "@angular/material/snack-bar";
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { ConfirmationDialogComponent } from '../dialog/confirmation/confirmation-dialog.component';

@Component({
  selector: 'app-inline-link-card',
  templateUrl: './inline-link-card.component.html',
  styleUrls: ['./inline-link-card.component.scss']
})
export class InlineLinkCardComponent implements OnInit {
  @Input()
  link!: Link;

  imageUrl = "/assets/images/asp-net-core-identity-with-patterns-1.png";

  constructor(
    private snackBar: MatSnackBar,
    private service: MewaAppService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    // this.convertThumbnailBase64ToImage(this.link.thumbnailContent);
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
      navigator.clipboard.writeText(this.link.url);
      this.snackBar.open("Link was copied", 'Ok', {
        duration: 2000
      });
    }catch (e) {
      console.log(e);
    }
  }

  onEdit(): void {

  }

  onDelete(): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '50%',
      data: {title: 'Czy jesteś pewien?', text: "Czy rzeczywiście chcesz usunąć ten link?"},
    });
    dialogRef.componentInstance.onDecide.subscribe(result => {
      if (result) {
        this.service.deleteLink(this.link.id).subscribe(response => {
          console.log('Link został usunięty');
        });
      }
    });
  }

  onShare(): void {

  }

  redirect(): void {
    window.open(this.link.url, '_blank')?.focus();
  }

}
