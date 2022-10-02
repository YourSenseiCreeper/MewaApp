import { Component, Inject, Input, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subject } from 'rxjs';

export interface DialogData {
    title: string,
    text: string,
    isCancelVisible: boolean
}

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent {
    text = 'Tekst';
    title = 'Tytuł';
    isCancelVisible = true;

    @Output()
    public onDecide = new Subject<boolean>();

    constructor(
        public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) { }

    closeOrCancel() {
        this.onDecide.next(false);
        this.closeDialogAndComplete();
    }

    accept() {
        this.onDecide.next(true);
        this.closeDialogAndComplete();
    }

    closeDialogAndComplete() {
        // Here we can just put value -> this.dialogRef.close(false); and recive it on dialogRef.afterClosed().supscribe()
        this.dialogRef.close();
        this.onDecide.complete();
    }
}
