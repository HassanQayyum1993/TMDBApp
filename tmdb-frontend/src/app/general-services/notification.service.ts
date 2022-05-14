import { Injectable } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarConfig,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';
import { notification } from "./notification.model";

@Injectable({
    providedIn: "root",
})
export class NotificationService {
    constructor(public snackBar: MatSnackBar) {}

    open(notification: notification) {
      const {message, type} = notification;
        let config = new MatSnackBarConfig();
        config.verticalPosition = "bottom";
        config.horizontalPosition = "right";
        config.duration = 5000;
        config.panelClass = `${type}-snackbar`;
        this.snackBar.open(
          message,
          "",
          config
        );
    }
}
