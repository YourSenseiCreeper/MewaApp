import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

@Injectable({providedIn: 'any'})
export class NotificationService {

  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';

  constructor(private _snackBar: MatSnackBar) { }

  showMessage(text: string, action: string, panelClass: string): void {
    this._snackBar.open(text, action, {
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
      panelClass: panelClass,
      duration: 5000
    })
  }

  showError(error: string): void {
    this.showMessage(error, 'Close', 'snackbar-error');
  }

  showWarning(message: string): void {
    this.showMessage(message, 'Close', 'snackbar-warning');
  }

  showSuccess(message: string): void {
    this.showMessage(message, 'Close', 'snackbar-success');
  }

  showInfo(message: string): void {
    this.showMessage(message, 'Close', 'snackbar-info');
  }
}
