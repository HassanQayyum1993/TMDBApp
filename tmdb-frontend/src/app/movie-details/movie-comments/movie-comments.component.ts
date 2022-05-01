import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { share } from 'rxjs/operators';
import { MovieComment } from './movie-comments.model';
import { CommentService } from './movie-comments.service';
import * as moment from 'moment';

@Component({
  selector: 'app-movie-comments',
  templateUrl: './movie-comments.component.html',
  styleUrls: ['./movie-comments.component.css']
})
export class MovieCommentsComponent implements OnInit {

  moment: any = moment;
  form: FormGroup;
  comment: MovieComment;
  commentsList: any;
  movieId: number;
  displayedColumns = ['Value', 'Action'];
  registeredUser: string;
  token: string;
  isEdit= false;
  editedId=0;

  constructor(private _formBuilder: FormBuilder, private _commentService: CommentService, private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    debugger;
    this.registeredUser = localStorage.getItem('User');
    this.token = localStorage.getItem('TokenInfo')
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

  goToLoginPage() {
    if (!localStorage.getItem('TokenInfo')) {
      this.router.navigateByUrl(`/login/fromMovieComments/${this.movieId}`);
    }
  }

  addComment() {
    this._commentService.postComment(this.form.getRawValue()).subscribe((res) => {
      this.form.patchValue( {'Value':null} );
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
    })
  }

  editComment(id)
  {
    debugger;
    this.editedId = id;
    this.isEdit = true;
  }

  updateComment(commentId, comment)
  {
    this._commentService.putComment(commentId, comment).subscribe((res) => {
      this.isEdit = false;
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
    })
  }

  deleteComment(commentId)
  {
    this._commentService.deleteComment(commentId).subscribe((res) => {
      this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { this.commentsList = data; });
    })
  }
}
