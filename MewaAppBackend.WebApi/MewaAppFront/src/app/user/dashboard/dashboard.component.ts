import { Component, OnInit } from '@angular/core';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { ThumbnailService } from 'src/app/shared/thumbnail.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [MewaAppService, ThumbnailService]
})
export class DashboardComponent implements OnInit {
  links: Link[] = [
    {
      id: 1,
      name: 'Link 1',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null
    },
    {
      id: 2,
      name: 'Link 2',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null
    },
    {
      id: 3,
      name: 'Link 3',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null
    },
    {
      id: 4,
      name: 'Link 4',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null
    },
    {
      id: 5,
      name: 'Link 5',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null
    }
  ];

  constructor(public mewaService: MewaAppService) { }

  ngOnInit(): void {
    this.mewaService.getAllLinks().subscribe(data => {

      this.links = data;

    });
  }

  onClick(url: string) {}
} 