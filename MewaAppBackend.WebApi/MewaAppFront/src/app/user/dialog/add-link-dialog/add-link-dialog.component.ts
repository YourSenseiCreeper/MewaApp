import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips/chip-input';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { map, Observable, startWith } from 'rxjs';
import { MewaAppService } from 'src/app/shared/mewa-app.service';
import { AddLink, TagDto } from 'src/app/shared/models';
import { NotificationService } from 'src/app/shared/notification.service';
import {COMMA, ENTER} from '@angular/cdk/keycodes';

@Component({
  selector: 'app-add-link-dialog',
  templateUrl: './add-link-dialog.component.html',
  styleUrls: ['./add-link-dialog.component.scss'],
  providers: [MewaAppService]
})
export class AddLinkDialogComponent implements OnInit {
  
  url = new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(6)]);
  name = new FormControl('', [Validators.maxLength(300)]);
  description = new FormControl('', [Validators.maxLength(300)]);
  tags: TagDto[] = [];
  allTags: TagDto[] = [];
  filteredTags: Observable<TagDto[]>;

  constructor(
    private notification: NotificationService,
    public mewaService: MewaAppService,
    public dialogRef: MatDialogRef<AddLinkDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.filteredTags = this.tagControl.valueChanges.pipe(
      startWith(null),
      map((tag: string | null) => (tag ? this._filter(tag) : this.allTags.slice())),
    );
   }
  ngOnInit(): void {
    this.mewaService.getAllTags().subscribe(data => this.allTags = data);
  }

   submit() {
     let values = {
       url: this.url.value,
       name: this.name.value,
       description: this.description.value,
       expiryDate: new Date(2023, 1, 1),
       // ownerId is assigned on backend based on JWT token claim
       tags: [],
       groups: []
     } as AddLink;
     this.mewaService.addLink(values).subscribe(r => {
       if (r.success) {
        this.notification.showSuccess("Link dodany");
        this.close();
       } else {
        this.notification.showError(r.message as string);
       }
     })
   }

   close() {
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

    return this.allTags.filter(t => t.name.toLowerCase().includes(filterValue));
  }
} 