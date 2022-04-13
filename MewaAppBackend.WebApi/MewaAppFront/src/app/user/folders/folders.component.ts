import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-folders',
  templateUrl: './folders.component.html',
  styleUrls: ['./folders.component.scss']
})
export class FoldersComponent implements OnInit {

  folderId: string;

  constructor() {
    this.folderId = 'fbx245shd';
  }

  ngOnInit(): void {
  }

}
