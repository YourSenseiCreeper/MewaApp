import { Component } from '@angular/core';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  constructor(private notificationService: NotificationService) {}

  onClickAcction() {
    this.notificationService.showMessage("Użytkownik test", "Close");
  }
} 