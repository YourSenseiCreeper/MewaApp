import { Component } from '@angular/core';
import { NotificationService } from "src/app/shared/notification.service";
import { ThumbnailService } from 'src/app/shared/thumbnail.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  constructor(private notificationService: NotificationService) {
  }

  onClickAcction() {
  }
} 