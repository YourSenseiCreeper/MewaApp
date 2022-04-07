import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link } from 'src/app/shared/models';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  userName: string = "Test";
  folder: string = '';
  links: Link[] = [];

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