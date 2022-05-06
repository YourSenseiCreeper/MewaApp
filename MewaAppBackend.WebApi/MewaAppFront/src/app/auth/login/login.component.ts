import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginCommand } from 'src/app/shared/models';
import { AuthService } from 'src/app/shared/services/auth.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  hide: boolean = true;
  loginForm!: FormGroup;
  submitDisabled: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private service: AuthService,
    private notification: NotificationService,
    private authService: AuthService) {
    this.loginForm = fb.group(
      {
        login: this.fb.control('', [Validators.required, Validators.email]),
        password: this.fb.control('', [Validators.required])
      }
    )
  }

  login(): void {
    let rawForm = this.loginForm.getRawValue();
    this.submitDisabled = true;
    let command = {
      email: rawForm.login,
      password: rawForm.password
    } as LoginCommand;
    this.service.login(command).subscribe(r => {
      if (r.success) {
        this.authService.setUserToken(r.token);
        this.router.navigate(['/user/dashboard']);
      } else {
        this.notification.showError(r.message);
        this.submitDisabled = false;
      }
    });
  }
}
