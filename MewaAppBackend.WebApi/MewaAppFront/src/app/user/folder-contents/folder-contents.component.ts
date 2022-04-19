import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Link } from 'src/app/shared/models';

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
      thumbnailId: null, 
      userId: null,
      thumbnailContent: null,
    },
    {
      id: 2,
      name: 'Link 2',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null,
    },
    {
      id: 3,
      name: 'Link 3',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null,
    },
    {
      id: 4,
      name: 'Link 4',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null,
    },
    {
      id: 5,
      name: 'Link 5',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null,
      thumbnailContent: null,
    }
  ];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.folderId = paramMap.get('id') ? paramMap.get('id') as string : '';
    });
  }

}
