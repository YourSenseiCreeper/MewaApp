import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from "src/app/shared/notification.service";

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private notificationService: NotificationService, private route: ActivatedRoute) {}

  onClickAcction() {
    this.notificationService.showMessage("Użytkownik test", "Close");
  }
} 