import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-page-content',
  templateUrl: './page-content.component.html',
  styleUrls: ['./page-content.component.scss']
})


export class PageContentComponent implements OnInit {

  public numberOfSlides: number = 3;
  public selectedSlide: number = 1;

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  onLeftArrowClick() {
    if (this.selectedSlide > 1)
    {
      this.selectedSlide--;
    }
    console.log(this.selectedSlide)
  }

  onRightArrowClick() {
    if (this.numberOfSlides > this.selectedSlide)
    {
      this.selectedSlide++;
      console.log('Click')
    }
    console.log(this.selectedSlide)
  }


  ngOnInit(): void {
  }
}
