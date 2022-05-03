import { MediaMatcher } from '@angular/cdk/layout';
import { Component } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  isMobile = false;

  constructor(private matcher: MediaMatcher) {
    let matcherResult = matcher.matchMedia("(max-width: 800px)");
    this.isMobile = matcherResult.matches;
  }
} 