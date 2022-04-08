import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  hide = true;
  loginForm!: FormGroup;

  constructor(private route: ActivatedRoute, private fb: FormBuilder) {
    this.loginForm = fb.group(
      {
        login: new FormControl('', null),
        password: new FormControl('', null)
      }
    )
  }

  login() {
    // request
  }
}
