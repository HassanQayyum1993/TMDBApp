import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'app/movie/movie.service';
import { share } from 'rxjs/operators';
import { MovieComment } from './movie-comments.model';
import { CommentService } from './movie-comments.service';

@Component({
  selector: 'app-movie-comments',
  templateUrl: './movie-comments.component.html',
  styleUrls: ['./movie-comments.component.css']
})
export class MovieCommentsComponent implements OnInit {

  form: FormGroup;
  comment: MovieComment;
  commentsList: any;
  movieId: number;
  displayedColumns = ['Value', 'Action'];

  constructor(private _formBuilder: FormBuilder, private _commentService: CommentService, private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    this.comment = new MovieComment([]);
    this.movieId = +this.route.snapshot.params.movieId;
    this._commentService.getCommentsByMovieId(this.movieId).subscribe((data) => { debugger; this.commentsList = data; });


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
      this.router.navigateByUrl(`/login/${this.movieId}`);
    }
  }

  addComment() {
    this._commentService.postComment(this.form.getRawValue()).subscribe((res) => {
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
