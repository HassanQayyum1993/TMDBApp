import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { share } from 'rxjs/operators';
import { MovieComment } from './movie-comments.model';
import * as moment from 'moment';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from 'app/shared-module/login/login.component';
import { CommentService } from 'app/services/comments.service';
import { notification } from 'app/general-services/notification.model';
import { NotificationService } from 'app/general-services/notification.service';

@Component({
  selector: 'app-movie-comments',
  templateUrl: './movie-comments.component.html',
  styleUrls: ['./movie-comments.component.scss']
})
export class MovieCommentsComponent implements OnInit {

  moment: any = moment;
  form: FormGroup;
  comment: MovieComment;
  commentsList: any;
  movieId: number;
  displayedColumns = ['Value', 'Action'];
  //registeredUser: string;
  //token: string;
  isEdit = false;
  editedId = 0;

  @Input() isLoggedIn: any;
  @Input() registeredUser: any;
  @Output() commentLoginEvent = new EventEmitter<any>();

  constructor(private _formBuilder: FormBuilder,
    private _commentService: CommentService,
    private _notificationService: NotificationService,
    private route: ActivatedRoute,
    private _matDialog: MatDialog) {
  }

  ngOnInit(): void {
    //this.registeredUser = window.sessionStorage.getItem('user-name');
    //this.token = window.sessionStorage.getItem('auth-token')
    this.comment = new MovieComment([]);
    this.movieId = +this.route.snapshot.params.movieId;
    this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data.comments; },
    (err) => {
      debugger;
      let notificationObj: notification = {
        message: err.message,
        type: "warning",
      };
      this._notificationService.open(notificationObj);
    });


    this.form = this._formBuilder.group({
      Id: this.comment.Id,
      MovieId: this.movieId,
      Value: this.comment.Value,
      CreatedBy: this.comment.CreatedBy,
      CreatedOn: this.comment.CreatedOn,
      UpdatedBy: this.comment.UpdatedBy,
      UpdatedOn: this.comment.UpdatedOn
    })

  }

  goToLoginPage() {
    this.form.controls["Value"].enable();
    if (!this.isLoggedIn) {
      let dialogRef;
      dialogRef = this._matDialog.open(LoginComponent, {
        width: '30%',
        panelClass: 'login-form-dialog',
      });

      dialogRef.afterClosed().subscribe((response) => {
        debugger;
        if (response) {
          if (response.status == "Success") {
            let notificationObj: notification = {
              message: response.message,
              type: "success"
            };
            this._notificationService.open(notificationObj);
            this.isLoggedIn = true;
            this.registeredUser = window.sessionStorage.getItem('user-name');
            this.commentLoginEvent.emit({ login: this.isLoggedIn, username: this.registeredUser });
          }
        }
        else {
          document.getElementById("myAnchor").blur();
        }
      });
    }
  }

  addComment(el) {

    this._commentService.postComment(this.form.getRawValue()).subscribe((res) => {
      debugger;
      if (res.status == "Success") {
        let notificationObj: notification = {
          message: res.message,
          type: "success",
        };
        this._notificationService.open(notificationObj);
        this.form.patchValue({ 'Value': null });
        this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data.comments; });
        el.scrollIntoView({ behavior: 'smooth', block: 'start' });
      }
    },
      (err) => {
        let notificationObj: notification = {
          message: err.message,
          type: "warning",
        };
        this._notificationService.open(notificationObj);
      })

  }

  editComment(id) {
    this.editedId = id;
    this.isEdit = true;
  }

  updateComment(commentId, comment) {
    this._commentService.putComment(commentId, comment).subscribe((res) => {
      if (res.status == 'Success') {
        let notificationObj: notification = {
          message: res.message,
          type: "success",
        };
        this._notificationService.open(notificationObj);
        this.isEdit = false;
        this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data.comments; });
      }
    },
      (err) => {
        let notificationObj: notification = {
          message: err.message,
          type: "warning",
        };
        this._notificationService.open(notificationObj);
      })
  }

  deleteComment(commentId) {
    this._commentService.deleteComment(commentId).subscribe((res) => {
      if (res.status == "Success") {
        let notificationObj: notification = {
          message: res.message,
          type: "success",
        };

        this._notificationService.open(notificationObj);
        this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data.comments; });
      }
    },
      (err) => {
        let notificationObj: notification = {
          message: err.messager,
          type: "warning",
        };
        this._notificationService.open(notificationObj);
      })
  }

}
