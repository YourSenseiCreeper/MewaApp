import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips/chip-input';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { map, Observable, startWith, Subject } from 'rxjs';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { Link, TagDto } from 'src/app/shared/models';

export interface AddEditLinkDialogData {
  link?: Link;
  title: string;
}

@Component({
  selector: 'app-add-edit-link-dialog',
  templateUrl: './add-edit-link-dialog.component.html',
  styleUrls: ['./add-edit-link-dialog.component.scss'],
  providers: [MewaAppService]
})
export class AddEditLinkDialogComponent implements OnInit {
  
  @Output() public onSave!: Observable<any>;

  onSave$ = new Subject();
  url = new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(6)]);
  name = new FormControl('', [Validators.maxLength(300)]);
  description = new FormControl('', [Validators.maxLength(300)]);
  tags: TagDto[] = [];
  allTags: TagDto[] = [];
  filteredTags: Observable<TagDto[]>;

  constructor(
    public mewaService: MewaAppService,
    public dialogRef: MatDialogRef<AddEditLinkDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddEditLinkDialogData) {
      this.onSave = this.onSave$.asObservable();
      this.filteredTags = this.tagControl.valueChanges.pipe(
        startWith(null),
        map((tag: string | null) => (tag ? this._filter(tag) : this.allTags.slice())),
      );
   }

  ngOnInit(): void {
    if (this.data.link) {
      this.loadFormFromLink();
    }
    this.mewaService.getAllTags().subscribe(d => { 
      this.allTags = d;
      if (this.data.link?.tags) {
        let tagIds = this.data.link.tags.map(t => t.id);
        this.tags = this.allTags.filter(t => tagIds.includes(t.id));
      }
    });
  }

  private loadFormFromLink(): void {
    this.url.setValue(this.data.link?.url);
    this.name.setValue(this.data.link?.name);
    this.description.setValue(this.data.link?.description);
  }

  submit(): void {
    if (this.data.link) {
      this.submitModifiedLink();
    } else {
      this.submitNewLink();
    }
  }

  submitNewLink(): void {
    let value = {
      url: this.url.value,
      name: this.name.value,
      description: this.description.value,
      expiryDate: new Date(2023, 1, 1),
      // ownerId is assigned on backend based on JWT token claim
      tags: this.tags.map(t => t.id),
      groups: []
    };
    this.onSave$.next(value);
  }

  submitModifiedLink(): void {
    let value = {
      id: this.data.link?.id,
      url: this.url.value,
      name: this.name.value,
      description: this.description.value,
      expiryDate: this.data.link?.expiryDate,
      ownerId: this.data.link?.ownerId,
      tags: this.tags.map(t => t.id),
      groups: []
    };
    this.onSave$.next(value);
  }

  close(): void {
    this.dialogRef.close();
  }

  separatorKeysCodes: number[] = [ENTER, COMMA];
  tagControl = new FormControl();

  @ViewChild('tagInput') tagInput: ElementRef<HTMLInputElement> | undefined;

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    let tag = this.allTags.filter(t => t.name == value)[0];

    if (value) {
      this.tags.push(tag);
    }

    event.chipInput!.clear();
    this.tagControl.setValue(null);
  }

  remove(tag: TagDto): void {
    const index = this.tags.indexOf(tag);

    if (index >= 0) {
      this.allTags.push(tag);
      this.tags.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    let tag = this.allTags.filter(t => t.name == event.option.viewValue)[0];
    this.tags.push(tag);
    
    this.removeTagFromPossibleToChoose(tag);

    this.tagInput!.nativeElement.value = '';
    this.tagControl.setValue(null);
  }

  private removeTagFromPossibleToChoose(tag: TagDto): void {
    const index = this.allTags.indexOf(tag);
    this.allTags.splice(index, 1);
  }

  private _filter(value: any): TagDto[] {
    if (!value || !!value.name) {
      return [];
    }
    const filterValue = value.toLowerCase();

    return this.allTags.filter(t => t.name.toLowerCase().includes(filterValue));
  }
} 