import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { RegisterCommand } from 'src/app/shared/models';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  loginForm!: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private service: MewaAppService,
    private notification: NotificationService,
    private router: Router
  ) {
    this.loginForm = fb.group(
      {
        name: new FormControl('', null),
        email: new FormControl('', null),
        password: new FormControl('', null),
        repeatPassword: new FormControl('', null)
      }
    )
  }

  submit() {
    let rawForm = this.loginForm.getRawValue();

    if (rawForm.password !== rawForm.repeatPassword) {
      // powiadomienie na formularzu że hasła się nie zgadzają
    }

    // sprawdzenie czy taki użytkownik istnieje?
    let command = {
      userName: rawForm.name,
      email: rawForm.email,
      password: rawForm.password
    } as RegisterCommand
    this.service.register(command).subscribe(r => {
      if (r.success) {
        this.notification.showSuccess("Pomyślnie zarejestrowano");
        this.router.navigate(['../']);
      } else {
        this.notification.showError("Coś poszło nie tak");
      }
    })
  }
}
