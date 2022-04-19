import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth-service';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { LoginCommand } from 'src/app/shared/models';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  hide: boolean = true;
  loginForm!: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private service: MewaAppService,
    private notification: NotificationService,
    private authService: AuthService) {
    this.loginForm = fb.group(
      {
        login: this.fb.control('', null),
        password: this.fb.control('', null)
      }
    )
  }

  login(): void {
    let rawForm = this.loginForm.getRawValue();
    let command = {
      email: rawForm.login,
      password: rawForm.password
    } as LoginCommand;
    this.service.login(command).subscribe(r => {
      if (r.success) {
        this.authService.setUserToken(r.token);
        this.router.navigate(['/user/dashboard'])
      } else {
        this.notification.showError(r.message);
      }
    });
  }
}
