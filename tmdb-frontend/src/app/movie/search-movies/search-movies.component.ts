import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from '../movie.service';

@Component({
  selector: 'app-search-movies',
  templateUrl: './search-movies.component.html',
  styleUrls: ['./search-movies.component.css']
})
export class SearchMoviesComponent implements OnInit {

  moviesList: any;
  genreId: any = 0;
  genreList: any;
  displayedColumns = ['PosterImage', 'Title', 'ReleaseDate'];
  searchKeyWord: string;
  pageNumber: number = 1;
  constructor(private _movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this._movieService.GetMoviesGenreList().subscribe((response) => { this.genreList = response.genreList.genres });
  }

  refreshList() {
    this._movieService.GetPaginatedMoviesListWithSearch(this.searchKeyWord, this.genreId, this.pageNumber).subscribe((response) => {
      this.moviesList = response.moviesList;
    });
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this._movieService.GetPaginatedMoviesListWithSearch(this.searchKeyWord, this.genreId, this.pageNumber).subscribe((response) => {
      this.moviesList = response.moviesList;
    });
  }

  setGenreId(event)
  {
    this.genreId = event.value
  }

  goToMovieDetails(Id) {
    this.router.navigateByUrl(`/movieDetails/${Id}`)
  }
}
