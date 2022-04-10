import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  loginForm!: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder
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
}
