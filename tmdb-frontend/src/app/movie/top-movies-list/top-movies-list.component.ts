import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'app/services/movie.service';

@Component({
  selector: 'app-top-movies-list',
  templateUrl: './top-movies-list.component.html',
  styleUrls: ['./top-movies-list.component.scss']
})
export class TopMoviesListComponent implements OnInit {

  pageNumber: number = 1;
  topMoviesList: any;
  displayedColumns = ['PosterImage', 'Title', 'Rating', 'ReleaseDate'];
  constructor(private _movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.movieList;
    });
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.movieList;
    });
  }

  goToMovieDetails(Id) {
    this.router.navigateByUrl(`movie/movieDetails/${Id}`)
  }
}
