import { Component, Input } from '@angular/core';
import { GroupDto, MicroGroup } from 'src/app/shared/models';

@Component({
  selector: 'app-folder-card',
  templateUrl: './folder-card.component.html',
  styleUrls: ['./folder-card.component.scss']
})
export class FolderCardComponent {
  @Input() group: MicroGroup | null = null;

  constructor() { }

  onEdit():void {

  }

  onDelete():void {

  }

  onShare():void {

  }
}
