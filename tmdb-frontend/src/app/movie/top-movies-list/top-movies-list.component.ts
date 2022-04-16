import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from '../movie.service';

@Component({
  selector: 'app-top-movies-list',
  templateUrl: './top-movies-list.component.html',
  styleUrls: ['./top-movies-list.component.css']
})
export class TopMoviesListComponent implements OnInit {

  pageNumber: number = 1;
  topMoviesList: any;
  displayedColumns = ['PosterImage', 'Title', 'ReleaseDate'];
  constructor(private _movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.topMoviesList;
    });
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.topMoviesList;
    });
  }

  goToMovieDetails() {
    //this.router.navigateByUrl(`/movieDetails`)
    this.router.navigate(['../movieDetails'])
  }
}
