import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'app/movie/movie.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movieId: number = 0;
  genres: any;
  title: any;
  imageUrls: any;
  names: any;
  posterPath: any;

  constructor(private _movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.movieId = +this.route.snapshot.params.movieId;
    localStorage.setItem('MovieId', this.movieId.toString());
    this._movieService.getMovieDetails(this.movieId).subscribe((response) => {
      this.names = response.movieCast.cast.map(function(item) {
        return item['name'];
      }).join(', ');

      this.title = response.movieDetails.title;
      this.posterPath = response.movieDetails.poster_path;
      this.genres = response.movieDetails.genres.map(function(item) {
        return item['name'];
      }).join(', ');

      this.imageUrls = response.movieImageUrls;
    })
  }
}