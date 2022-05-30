//import { Component, OnInit } from '@angular/core';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { AuthenticationService } from 'app/services/authentication.service';
import { NotificationService } from 'app/general-services/notification.service';
import { notification } from 'app/general-services/notification.model';
@Component({
  selector: 'main-toolbar',
  templateUrl: './main-toolbar.component.html',
  styleUrls: ['./main-toolbar.component.scss']
})

export class MainToolbarComponent implements OnInit, OnChanges {

  loginForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error = '';
  movieId: number;
  isFromMovieList = false;
  isLoading = false;

  @Input() userName: string;
  @Input() isLoggedIn: boolean;
  @Input() isFromDetail: boolean;
  @Output() loginEvent = new EventEmitter<any>();

  constructor(
    private router: Router,
    private _matDialog: MatDialog,
    private _notificationService: NotificationService,
    private authenticationService: AuthenticationService,) { }

  ngOnChanges(): void {
    this.ngOnInit();
  }

  ngOnInit() {
    if (window.sessionStorage.getItem('auth-token')) {
      this.isLoggedIn = true;
    }
    if (window.sessionStorage.getItem('user-name')) {
      this.userName = window.sessionStorage.getItem('user-name');
    }
  }

  // convenience getter for easy access to form fields
  goToLogInPage() {
    if (!window.sessionStorage.getItem('auth-token')) {
      //this.router.navigateByUrl(`/login/fromMovieList`);
      let dialogRef;
      dialogRef = this._matDialog.open(LoginComponent, {
        width: '30%',
        panelClass: 'login-form-dialog',
        // data: {
        //   action: 'new'
        // },
      });

      dialogRef.afterClosed().subscribe((response) => {
        if (response) {
          if (response.status == "Success") {
            let notificationObj: notification = {
              message: response.message,
              type: "success"
            };
            this._notificationService.open(notificationObj);
            this.ngOnInit();
            this.loginEvent.emit();
          }
        }
      });
    }
  }

  logOut() {
    this.authenticationService.logout();
    this.isLoggedIn = false;
    this.userName = '';
    this.loginEvent.emit();
  }

  goToMovieList() {
    this.router.navigateByUrl(`/movie`);
  }
}
