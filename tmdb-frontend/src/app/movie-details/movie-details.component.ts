import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'app/services/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit {

  movieId: number = 0;
  genres: any;
  title: any;
  imageUrls: any;
  names: any;
  posterPath: any;
  userName: string
  isLoggedIn = false;
  token: string
  rating: any;

  constructor(private _movieService: MovieService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (window.sessionStorage.getItem('auth-token')) {
      this.isLoggedIn = true;
    }
    if (window.sessionStorage.getItem('user-name')) {
      this.userName = window.sessionStorage.getItem('user-name');
    }

    this.movieId = +this.route.snapshot.params.movieId;
    localStorage.setItem('MovieId', this.movieId.toString());
    this._movieService.getMovieDetails(this.movieId).subscribe((response) => {
      this.names = response.movieCast.cast.map(function (item) {
        return item['name'];
      }).join(', ');

      this.title = response.movieDetails.title;
      this.posterPath = response.movieDetails.poster_path;
      this.rating = response.movieDetails.vote_average;
      this.genres = response.movieDetails.genres.map(function (item) {
        return item['name'];
      }).join(', ');

      this.imageUrls = response.movieImageUrls;
    })
  }

  checkLoginStatus(): void {
    if (window.sessionStorage.getItem('auth-token')) {
      this.isLoggedIn = true;
    }
    else {
      this.isLoggedIn = false;
    }
    if (window.sessionStorage.getItem('user-name')) {
      this.userName = window.sessionStorage.getItem('user-name');
    }
    else {
      this.isLoggedIn = false;
    }
  }

  onCommentLoginEvent(event): void {
    this.isLoggedIn = false;
    this.isLoggedIn = event.login;
    this.userName = event.username;
  }
}