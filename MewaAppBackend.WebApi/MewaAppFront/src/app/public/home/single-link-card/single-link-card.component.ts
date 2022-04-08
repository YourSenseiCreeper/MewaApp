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
    userId: null
  };

  imageUrl = "/assets/images/asp-net-core-identity-with-patterns-1.png";


  constructor(private snackBar: MatSnackBar) { }

  ngOnInit(): void {

  }

  Copy() {

    try {
      navigator.clipboard.writeText(this.link.url);
      this.snackBar.open("Link was copied", 'Ok', {
        duration: 2000
      });

  }catch (e) {
      console.log(e);
    }
  }
}
