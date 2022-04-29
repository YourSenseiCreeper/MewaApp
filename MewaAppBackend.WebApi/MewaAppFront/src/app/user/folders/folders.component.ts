import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GroupDto } from 'src/app/shared/models';
import { AddEditFolderDialogComponent } from '../dialog/add-edit-folder/add-edit-folder-dialog.component';
import { GroupService } from 'src/app/shared/services/group.service';

@Component({
  selector: 'app-folders',
  templateUrl: './folders.component.html',
  styleUrls: ['./folders.component.scss']
})
export class FoldersComponent implements OnInit {

  groups: GroupDto[] = [];
  simpleLinks: boolean = false;

  constructor(
    private service: GroupService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.service.getAllGroups().subscribe(r => this.groups = r);
  }

  toggleChange(): void {
    this.simpleLinks = !this.simpleLinks;
  }
  addGroup(): void {
    this.dialog.open(AddEditFolderDialogComponent, { width: '50%' });
  }

}
