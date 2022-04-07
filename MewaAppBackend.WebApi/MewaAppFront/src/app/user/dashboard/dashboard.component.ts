import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from "src/app/shared/notification.service";

export interface Link {
  name: string,
  url: string,
  description: string;
}

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  userName: string = "Test";
  folder: string = '';
  links: Link[] = [
    {name: 'Link do YouTube', url: 'https://youtube.com', description: ''},
    {name: 'Link do przepisów na obiad', url: 'https://kwestiasmaku.pl', description: ''},
    {name: 'Link do materiałów na PK', url: 'https://youtube.com', description: ''}
  ];

  constructor(private notificationService: NotificationService,
    private route: ActivatedRoute,
    private router: Router) {
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.userName = paramMap.get('userName') ? paramMap.get('userName') as string : 'null';
      this.folder = paramMap.get('folder') ? paramMap.get('folder') as string : '';
      if (!!this.folder){
        // tutaj pobieramy listę linków i folderów dla podanego folderu
      }
    });
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