import { Component } from '@angular/core';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Angular-Mewa';

  constructor(private notificationService: NotificationService) {}

  onClickAcction() {
    this.notificationService.showTestMessage();
  }
} 
