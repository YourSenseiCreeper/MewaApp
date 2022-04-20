import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from "@angular/forms";

@Component({
  selector: 'app-slide-one',
  templateUrl: './slide-one.component.html',
  styleUrls: [
    './slide-one.component.scss',
    '../page-content.component.scss'
  ]
})
export class SlideOneComponent implements OnInit {

  constructor() { }

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  ngOnInit(): void {
  }

}
