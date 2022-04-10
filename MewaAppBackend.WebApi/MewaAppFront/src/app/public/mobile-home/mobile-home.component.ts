import { Component } from '@angular/core';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-mobile-home',
  templateUrl: './mobile-home.component.html',
  styleUrls: ['./mobile-home.component.scss']
})
export class MobileHomeComponent {
  constructor(private notificationService: NotificationService) {}

  onClickAcction() {
    this.notificationService.showTestMessage();
  }
} 