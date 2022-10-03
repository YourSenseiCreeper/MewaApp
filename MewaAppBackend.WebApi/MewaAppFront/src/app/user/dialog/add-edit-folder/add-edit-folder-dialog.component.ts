import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips/chip-input';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { catchError, EMPTY, map, Observable, startWith } from 'rxjs';
import { AddGroup, TagDto } from 'src/app/shared/models';
import { GroupService } from 'src/app/shared/services/group.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-add-edit-folder-dialog',
  templateUrl: './add-edit-folder-dialog.component.html',
  styleUrls: ['./add-edit-folder-dialog.component.scss']
})
export class AddEditFolderDialogComponent implements OnInit {

  @ViewChild('tagInput') tagInput: ElementRef<HTMLInputElement> | undefined;

  addEditFolder: FormGroup = new FormGroup({
    url: new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(6)]),
    name: new FormControl('', [Validators.maxLength(300)]),
    description: new FormControl('', [Validators.maxLength(300)]),
  });
  tags: TagDto[] = [];
  allTags: TagDto[] = [];
  filteredTags: Observable<TagDto[]>;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  tagControl = new FormControl();

  get urlForm() {
    return this.addEditFolder.get("url");
  }

  get nameForm() {
    return this.addEditFolder.get("name");
  }

  get descriptionForm() {
    return this.addEditFolder.get("description");
  }

  constructor(
    private notification: NotificationService,
    public service: GroupService,
    public dialogRef: MatDialogRef<AddEditFolderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    
      this.filteredTags = this.tagControl.valueChanges.pipe(
      startWith(null),
      map((tag: string | null) => (tag ? this._filter(tag) : this.allTags.slice())),
    );
   }

  ngOnInit(): void {
  }

  submit() {
    // Insted of 1 here shoud be Group id
    this.service.AddGroupToGroup(this.nameForm?.value, 1)
    .pipe(catchError((err, caught) => {
      this.notification.showError(err as string);
      this.close();
      return EMPTY;
    }))
    .subscribe(r => {
      this.notification.showSuccess("Folder dodany");
      this.close();
    })
  }

  close() {
    this.dialogRef.close();
  }

  add(event: MatChipInputEvent): void {
    const value: string = (event.value?.trim() || '');
    let tag: TagDto = this.allTags.filter(t => t.name == value)[0];

    if (value && tag !== undefined) {
      this.tags.push(tag);
    }

    event.chipInput!.clear();
    this.tagControl.setValue(null);
  }

  remove(tag: TagDto): void {
    const index = this.tags.indexOf(tag);

    if (index >= 0) {
      this.tags.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    let tag = this.allTags.filter(t => t.name == event.option.viewValue)[0];
    this.tags.push(tag);
    this.tagInput!.nativeElement.value = '';
    this.tagControl.setValue(null);
  }

  private _filter(value: string): TagDto[] {
    const filterValue = value.toLowerCase();

    return this.allTags
      .filter(t => t.name.toLowerCase()
      .includes(filterValue));
  }
} 