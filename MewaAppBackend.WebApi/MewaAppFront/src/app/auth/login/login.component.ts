import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { LoginCommand } from 'src/app/shared/models';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  hide = true;
  loginForm!: FormGroup;

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private service: MewaAppService,
    private notification: NotificationService) {
    this.loginForm = fb.group(
      {
        login: new FormControl('', null),
        password: new FormControl('', null)
      }
    )
  }

  login() {
    let rawForm = this.loginForm.getRawValue();
    let command = {
      email: rawForm.login,
      password: rawForm.password
    } as LoginCommand;
    this.service.login(command).subscribe(r => {
      if (r.success) {
        // zapis tokenu do przeglądarki
        this.notification.showSuccess('Pomyślnie zalogowano!');
        // redirect
      } else {
        this.notification.showError(r.message);
      }
    });
  }
}
