import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-single-folder-card',
  templateUrl: './single-folder-card.component.html',
  styleUrls: ['./single-folder-card.component.scss']
})
export class SingleFolderCardComponent implements OnInit {
  name: string = 'Folder 1';
  @Input() url: string = "#";

  constructor() { }

  ngOnInit(): void {
  }

}
