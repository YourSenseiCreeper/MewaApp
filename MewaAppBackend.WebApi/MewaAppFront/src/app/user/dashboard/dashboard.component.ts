import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [MewaAppService]
})
export class DashboardComponent implements OnInit {
  userName: string = "Test";
  folder: string = '';
  links: Link[] = [
    {
      id: 1,
      name: 'Link 1',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null
    },
    {
      id: 2,
      name: 'Link 2',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null
    },
    {
      id: 3,
      name: 'Link 3',
      description: "To jest pierwsza karta oraz jej jakis tam tekst, który musi zostać sformatowany. Powinny być zazwyczaj dwa wiersze tekstu.",
      url: "https://bardzoDobryLink.org/link2",
      expiryDate: null,
      thumbnailId: null,
      userId: null
    }
  ];

  constructor(private notificationService: NotificationService,
    private route: ActivatedRoute,
    private router: Router,
    public mewaService: MewaAppService) {
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.userName = paramMap.get('userName') ? paramMap.get('userName') as string : 'null';
      this.folder = paramMap.get('folder') ? paramMap.get('folder') as string : '';
      if (!!this.folder){
        // tutaj pobieramy listę linków i folderów dla podanego folderu
      }
    });
    // CORS not working :(
    this.mewaService.getAllLinks().subscribe(data => this.links = data);
  }

  onClickAcction() {
    this.notificationService.showWarning('Przykładowy warning');
  }

  onClickAcction1() {
    this.notificationService.showInfo('Przykładowy info');
  }

  onClickAcction2() {
    this.notificationService.showSuccess('Przykładowy success');
  }

  redirect(url: string) {
    window.open(url, "_blank");
  }
} 