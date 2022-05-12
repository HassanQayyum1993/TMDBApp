import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { share } from 'rxjs/operators';
import { MovieComment } from './movie-comments.model';
import * as moment from 'moment';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from 'app/shared-module/login/login.component';
import { CommentService } from 'app/services/comments.service';

@Component({
  selector: 'app-movie-comments',
  templateUrl: './movie-comments.component.html',
  styleUrls: ['./movie-comments.component.scss']
})
export class MovieCommentsComponent implements OnInit, OnChanges {

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

  @Input() isLoggedIn:any;
  @Input() registeredUser: any;

  constructor(private _formBuilder: FormBuilder,
     private _commentService: CommentService,
      private route: ActivatedRoute,
    private router: Router,
    private _matDialog: MatDialog) {
  }

  ngOnInit(): void {
    //this.registeredUser = localStorage.getItem('User');
    //this.token = localStorage.getItem('TokenInfo')
    this.comment = new MovieComment([]);
    this.movieId = +this.route.snapshot.params.movieId;
    this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });


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

  ngOnChanges()
  {
    debugger;
  }

  goToLoginPage() {
    if (!this.isLoggedIn) {
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
         if (response == "success") {
           this.ngOnInit();
         }

      });
    }
  }

  addComment(el) {
    
    this._commentService.postComment(this.form.getRawValue()).subscribe((res) => {
      this.form.patchValue({ 'Value': null });
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
      el.scrollIntoView({ behavior: 'smooth', block: 'start'});
    })

  }

  editComment(id) {
    this.editedId = id;
    this.isEdit = true;
  }

  updateComment(commentId, comment) {
    this._commentService.putComment(commentId, comment).subscribe((res) => {
      this.isEdit = false;
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
    })
  }

  deleteComment(commentId) {
    this._commentService.deleteComment(commentId).subscribe((res) => {
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
    })
  }
  
}
