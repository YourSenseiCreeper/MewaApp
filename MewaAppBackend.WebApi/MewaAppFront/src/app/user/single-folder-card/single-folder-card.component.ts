import { Component, Input } from '@angular/core';
import { GroupDto } from 'src/app/shared/models';

@Component({
  selector: 'app-single-folder-card',
  templateUrl: './single-folder-card.component.html',
  styleUrls: ['./single-folder-card.component.scss']
})
export class SingleFolderCardComponent {
  
  @Input() url: string = "";
  @Input() group: GroupDto = { id: 0, name: 'Folder', description: '', isFolder: true };

  constructor() { }

  onEdit():void {

  }

  onDelete():void {

  }

  onShare():void {

  }
}
