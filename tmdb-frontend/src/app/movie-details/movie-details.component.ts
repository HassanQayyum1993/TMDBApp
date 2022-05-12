import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'app/services/authentication.service';
import { MovieService } from 'app/services/movie.service';
import { LoginComponent } from 'app/shared-module/login/login.component';

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

  constructor(private authenticationService: AuthenticationService,
    private _movieService: MovieService,
    private route: ActivatedRoute,
    private _matDialog: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('TokenInfo')) {
      this.isLoggedIn = true;
    }
    if (localStorage.getItem('User')) {
      this.userName = localStorage.getItem('User');
    }

    this.movieId = +this.route.snapshot.params.movieId;
    localStorage.setItem('MovieId', this.movieId.toString());
    this._movieService.getMovieDetails(this.movieId).subscribe((response) => {
      this.names = response.movieCast.cast.map(function (item) {
        return item['name'];
      }).join(', ');

      this.title = response.movieDetails.title;
      this.posterPath = response.movieDetails.poster_path;
      this.genres = response.movieDetails.genres.map(function (item) {
        return item['name'];
      }).join(', ');

      this.imageUrls = response.movieImageUrls;
    })
  }
 
  checkLoginStatus(): void
  {
    debugger;
    if (localStorage.getItem('TokenInfo')) {
      this.isLoggedIn = true;
    }
    else
    {
      this.isLoggedIn = false;
    }
    if (localStorage.getItem('User')) {
      this.userName = localStorage.getItem('User');
    }
    else
    {
      this.isLoggedIn = false;
    }
  }
}