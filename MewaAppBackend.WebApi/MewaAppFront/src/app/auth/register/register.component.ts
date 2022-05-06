import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import { RegisterCommand } from 'src/app/shared/models';
import { AuthService } from 'src/app/shared/services/auth.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  hide: boolean = true;
  hide2: boolean = true;
  registerForm!: FormGroup;
  submitDisabled: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private service: AuthService,
    private notification: NotificationService,
    private router: Router
  ) {
    this.registerForm = fb.group(
      {
        name: new FormControl('', [Validators.required]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required]),
        repeatPassword: new FormControl('', [Validators.required])
      }
    )
  }

  submit() {
    let rawForm = this.registerForm.getRawValue();
    this.submitDisabled = true;

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
        this.submitDisabled = false;
      }
    })
  }
}
