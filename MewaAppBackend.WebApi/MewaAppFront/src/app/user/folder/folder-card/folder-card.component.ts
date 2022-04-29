import { Component, Input } from '@angular/core';
import { GroupDto } from 'src/app/shared/models';

@Component({
  selector: 'app-folder-card',
  templateUrl: './folder-card.component.html',
  styleUrls: ['./folder-card.component.scss']
})
export class FolderCardComponent {
  
  @Input() url: string = "";
  @Input() group: GroupDto = { id: 0, name: 'Folder', description: '', isFolder: true };

  constructor() { }
}
