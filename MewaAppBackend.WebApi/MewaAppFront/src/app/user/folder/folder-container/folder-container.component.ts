import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GroupDto } from 'src/app/shared/models';
import { AddEditFolderDialogComponent } from '../../dialog/add-edit-folder/add-edit-folder-dialog.component';
import { GroupService } from 'src/app/shared/services/group.service';

@Component({
  selector: 'app-folder-container',
  templateUrl: './folder-container.component.html',
  styleUrls: ['./folder-container.component.scss']
})
export class FolderContainerComponent implements OnInit {

  groups: GroupDto[] = [];
  simpleLinks: boolean = false;

  constructor(
    private service: GroupService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    // this.service.getAllGroups().subscribe(r => this.groups = r);
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
  addGroup(): void {
    this.dialog.open(AddEditFolderDialogComponent, { width: '50%' });
  }

}
