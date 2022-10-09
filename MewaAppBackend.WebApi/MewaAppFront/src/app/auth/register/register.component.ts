import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import { RegisterCommand } from 'src/app/shared/models';
import { AuthService } from 'src/app/shared/services/auth.service';
import { EmailService } from 'src/app/shared/services/email.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['../form.scss']
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
    private router: Router,
    private emailService: EmailService
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

  ngOnInit(): void {
    if (this.emailService.getMessage()) {
      this.registerForm.controls['email'].setValue(this.emailService.getMessage());
      this.registerForm.controls['email'].markAsTouched();
    }
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
    }, error => {
      this.notification.showError("Problem z połączeniem: " + error.message);
      this.submitDisabled = false;
    });
  }

  getErrorMessage(control: string): string {
    const required: string = 'To pole jest wymagane';
    
    if (control === 'email') {
      if (this.registerForm.controls[control].hasError('required')) {
        return required;
      }
      return this.registerForm.controls[control].hasError('email') ? 'Niepoprawny format email' : '';
    }
    else if (control === 'name') {
      return this.registerForm.controls[control].hasError('required') ? required : '';
    }
    else if (control === 'password') {
      return this.registerForm.controls[control].hasError('required') ? required : '';
    }
    else if (control === 'repeatPassword') {
      if (this.registerForm.controls[control].hasError('required')) {
        return required;
      }
      return this.registerForm.controls[control].hasError('notEqual') ? 'Hasła są różne' : '';
    }
    return '';
  }
}
