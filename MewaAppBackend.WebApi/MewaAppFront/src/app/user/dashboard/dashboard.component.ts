import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  userName: string = "Test";

  constructor(private notificationService: NotificationService, private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      this.userName = paramMap.get('userName') ? paramMap.get('userName') as string : 'null';
    });
  }

  onClickAcction() {
    this.notificationService.showMessage("Użytkownik test", "Close");
  }
} 