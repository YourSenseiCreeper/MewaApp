import {Component, Input, OnInit} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import { Link } from 'src/app/shared/models';

@Component({
  selector: 'app-single-link-card',
  templateUrl: './single-link-card.component.html',
  styleUrls: [
    './single-link-card.component.scss'
  ]
})
export class SingleLinkCardComponent implements OnInit {
  @Input() link: Link = {
    id: 1,
    name: 'Link 1',
    description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
    url: "https://bardzoDobryLink.org/link2",
    expiryDate: null,
    thumbnailId: null,
    userId: null,
    thumbnailContent: null
  };

  imageUrl = "/assets/images/asp-net-core-identity-with-patterns-1.png";


  constructor(private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.convertThumbnailBase64ToImage(this.link.thumbnailContent);
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

  dataURItoBlob(dataURI: string) {
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

  }

  onShare(): void {

  }

}
