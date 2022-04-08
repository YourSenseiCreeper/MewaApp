import {Component, Input, OnInit} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-single-link-card',
  templateUrl: './single-link-card.component.html',
  styleUrls: [
    './single-link-card.component.scss'
  ]
})
export class SingleLinkCardComponent implements OnInit {
  @Input() linkCard: {
    id: number,
    title: string,
    imageURL: string,
    description: string,
    link: string
  } = {
    id: 1,
    title: 'Link 1',
    imageURL: "/assets/images/asp-net-core-identity-with-patterns-1.png",
    description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
    link: "bardzoDobryLink.org/link2"
  };


  constructor(private snackBar: MatSnackBar) { }

  ngOnInit(): void {

  }

  Copy() {

    try {
      navigator.clipboard.writeText('https://' + this.linkCard.link);
      this.snackBar.open("Link was copied", 'Ok', {
        duration: 2000
      });

  }catch (e) {
      console.log(e);
    }
  }
}
