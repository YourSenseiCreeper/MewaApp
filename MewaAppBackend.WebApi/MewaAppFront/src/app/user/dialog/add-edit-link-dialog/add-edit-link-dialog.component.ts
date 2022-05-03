import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips/chip-input';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { map, Observable, startWith, Subject } from 'rxjs';
import { Link, TagDto } from 'src/app/shared/models';
import { LinkService } from 'src/app/shared/services/link.service';
import { TagService } from 'src/app/shared/services/tag.service';

export interface AddEditLinkDialogData {
  link?: Link;
  title: string;
  icon: string;
}

@Component({
  selector: 'app-add-edit-link-dialog',
  templateUrl: './add-edit-link-dialog.component.html',
  styleUrls: ['./add-edit-link-dialog.component.scss']
})
export class AddEditLinkDialogComponent implements OnInit {
  
  @Output() public onSave!: Observable<any>;

  addEditLink: FormGroup = new FormGroup({
    url: new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(6)]),
    name: new FormControl('', [Validators.maxLength(300)]),
    description: new FormControl('', [Validators.maxLength(300)]),
    isPublic: new FormControl(false, null)
  });
  onSave$ = new Subject();
  tags: TagDto[] = [];
  allTags: TagDto[] = [];
  filteredTags: Observable<TagDto[]>;
  autocomplete = false;

  get urlForm() {
    return this.addEditLink.get('url');
  }

  get nameForm() {
    return this.addEditLink.get('name');
  }

  get descriptionForm() {
    return this.addEditLink.get('description');
  }

  get isPublicForm() {
    return this.addEditLink.get('isPublic');
  }

  constructor(
    public tagService: TagService,
    public linkService: LinkService,
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
    this.tagService.getAllTags().subscribe(d => { 
      this.allTags = d;
      if (this.data.link?.tags) {
        let tagIds = this.data.link.tags.map(t => t.id);
        this.tags = this.allTags.filter(t => tagIds.includes(t.id));
      }
    });
    this.urlForm?.valueChanges.subscribe((v: string) => {
      if (this.autocomplete && !this.nameForm?.value) {
        let lastUrlSection = v.slice(v.lastIndexOf('/'), v.length);
        lastUrlSection = lastUrlSection.replace(/-/g, ' '); // replace hypens
        lastUrlSection = lastUrlSection.replace(/\//g, ''); // replace slash

        let name = v;
        name = name.replace(/(?:http:\/\/|https:\/\/)/g, '');
        name = name.replace(/-/g, ' '); // replace hypens
        name = name.replace(/(?:\?.*)/g, ''); // replace query details
        name = name.replace(/\//g, ''); // replace last slash
        name = name.replace(/www./g, '');
        if (lastUrlSection.length == 0) {
          this.nameForm?.setValue(name);
        } else {
          this.nameForm?.setValue(lastUrlSection);
        }

        // autotag
        let domain = name.slice(0, name.lastIndexOf('.'));
        let tag = {id: 0, name: domain, description: '' } as TagDto;
        this.tags.push(tag);
      }
    });
  }

  private loadFormFromLink(): void {
    this.urlForm?.setValue(this.data.link?.url);
    this.nameForm?.setValue(this.data.link?.name);
    this.descriptionForm?.setValue(this.data.link?.description);
    this.isPublicForm?.setValue(this.data.link?.isPublic);
  }

  toggleAutocomplete() {
    this.autocomplete = !this.autocomplete;
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
      url: this.urlForm?.value,
      name: this.nameForm?.value,
      description: this.descriptionForm?.value,
      expiryDate: new Date(2023, 1, 1),
      isPublic: this.isPublicForm?.value,
      tags: this.tags.map(t => t.id),
      groups: []
    };
    this.onSave$.next(value);
  }

  submitModifiedLink(): void {
    let value = {
      id: this.data.link?.id,
      url: this.urlForm?.value,
      name: this.nameForm?.value,
      description: this.descriptionForm?.value,
      expiryDate: this.data.link?.expiryDate,
      isPublic: this.isPublicForm?.value,
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
    if (value && tag !== undefined) {
      this.tags.push(tag);
      this.removeTagFromPossibleToChoose(tag);
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