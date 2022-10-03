import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, Inject, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips/chip-input';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { debounceTime, distinctUntilChanged, map, Observable, of, startWith, Subject, switchMap } from 'rxjs';
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
  @ViewChild('tagInput') tagInput: ElementRef<HTMLInputElement> | undefined;

  addEditLink: FormGroup = new FormGroup({
    url: new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(6)]),
    name: new FormControl('', [Validators.maxLength(300)]),
    description: new FormControl('', [Validators.maxLength(300)]),
    isPublic: new FormControl(false, null)
  });
  onSave$ = new Subject();
  tags: TagDto[] = [];
  filteredTags$: Observable<TagDto[]>;
  filteredTags: TagDto[] = [];
  autocomplete = false;

  separatorKeysCodes: number[] = [ENTER, COMMA];
  tagControl = new FormControl();

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
      this.filteredTags$ = this.tagControl.valueChanges.pipe(
        startWith(null),
        debounceTime(300),
        distinctUntilChanged(),
        switchMap((tag: string | null) => this._filter(tag)),
      );
      this.filteredTags$.subscribe(v => this.filteredTags = v);
   }

  ngOnInit(): void {
    if (this.data.link) {
      this.loadFormFromLink();
    }

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

    this.addEditLink.get('tag')
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
    this.data.link ? this.submitModifiedLink() : this.submitNewLink();
  }

  submitNewLink(): void {
    // Const here
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
    // Const here
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

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    // Const here
    let tag = this.filteredTags.filter(t => t.name == value)[0];
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
    // Const here
    let tag = this.filteredTags.filter(t => t.name == event.option.viewValue)[0];
    if (!this.tags.find(t => t.name == event.option.viewValue))
      this.tags.push(tag);

    this.tagInput!.nativeElement.value = '';
    this.tagControl.setValue(null);
  }

  private _filter(value: any): Observable<TagDto[]> {
    return !value || !!value.name ? 
      of([]) : 
      this.tagService.getAllTags(value.toLowerCase(), 10);
  }
} 