import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { GroupDto } from 'src/app/shared/models';
import { AddEditFolderDialogComponent } from '../dialog/add-edit-folder/add-edit-folder-dialog.component';

@Component({
  selector: 'app-folders',
  templateUrl: './folders.component.html',
  styleUrls: ['./folders.component.scss']
})
export class FoldersComponent implements OnInit {

  groups: GroupDto[] = [];

  constructor(
    private service: MewaAppService,
    private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.service.getAllGroups().subscribe(r => this.groups = r);
  }

  addGroup(): void {
    this.dialog.open(AddEditFolderDialogComponent, { width: '50%' });
  }

}
