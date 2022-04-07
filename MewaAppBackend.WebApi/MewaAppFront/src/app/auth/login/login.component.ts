import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private notificationService: NotificationService, private route: ActivatedRoute) {}

  onClickAcction() {
    this.notificationService.showMessage("Użytkownik test", "Close");
  }
} 