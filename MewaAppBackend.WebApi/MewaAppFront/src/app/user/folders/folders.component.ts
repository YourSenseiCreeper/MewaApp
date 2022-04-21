import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-folders',
  templateUrl: './folders.component.html',
  styleUrls: ['./folders.component.scss']
})
export class FoldersComponent implements OnInit {

  folderId: string;
  simpleLinks: boolean = false;

  constructor() {
    this.folderId = 'fbx245shd';
  }

  ngOnInit(): void {
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
}
