import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-content',
  templateUrl: './page-content.component.html',
  styleUrls: ['./page-content.component.scss']
})
export class PageContentComponent implements OnInit {

  public numberOfSlides: number = 3;
  public selectedSlide: number = 1;

  onLeftArrowClick(): void {
    if (this.selectedSlide > 1)
    {
      this.selectedSlide--;
    }
  }

  onRightArrowClick(): void {
    if (this.numberOfSlides > this.selectedSlide)
    {
      this.selectedSlide++;
    }
  }

  ngOnInit(): void {
  }
}
