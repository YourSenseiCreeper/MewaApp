import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { EmailService } from 'src/app/shared/services/email.service';

@Component({
  selector: 'app-slide-one',
  templateUrl: './slide-one.component.html',
  styleUrls: [
    './slide-one.component.scss',
    '../page-content.component.scss'
  ]
})
export class SlideOneComponent implements OnInit {

  constructor(private router: Router, private emailService: EmailService) { }

  sendEmail: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email])
  });

  get emailForm() {
    return this.sendEmail.get('email');
  }

  ngOnInit(): void {
  }

  submit(): void {
    if (this.emailForm?.valid) {
/*       this.router.navigate(
        ['/auth/register'],
        { queryParams: { email: this.emailForm?.value }
      }); */
      this.emailService.setMessage(this.emailForm?.value);
      this.router.navigate(['/auth/register']);
    }
  }

}
