import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'app/services/movie.service';

@Component({
  selector: 'app-search-movies',
  templateUrl: './search-movies.component.html',
  styleUrls: ['./search-movies.component.css']
})
export class SearchMoviesComponent implements OnInit {

  moviesList: any;
  genreId: any = 0;
  genreList: any;
  displayedColumns = ['PosterImage', 'Title', 'Rating', 'ReleaseDate'];
  searchKeyWord: string = null;
  pageNumber: number = 1;
  isSearched: boolean = false;
  constructor(private _movieService: MovieService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this._movieService.GetMoviesGenreList().subscribe((response) => { this.genreList = response.genreList.genres });
  }

  refreshList() {
    this.isSearched = true;

    if (this.searchKeyWord != null && this.searchKeyWord != "") {
      this._movieService.GetPaginatedMoviesListWithSearch(this.searchKeyWord, this.genreId, this.pageNumber).subscribe((response) => {
        this.moviesList = response.movieList;
      })
    }
    else {
      this._movieService.GetPaginatedMoviesListByGenre(this.genreId, this.pageNumber).subscribe((response) => {
        this.moviesList = response.movieList;
      })
    }
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this.refreshList();
  }

  setGenreId(event) {
    this.genreId = event.value;
    if (this.genreId != 0 && this.genreId != null) {
      this.refreshList();
    }
    if (this.moviesList && (this.genreId == 0 || this.genreId == null)) {
      this.moviesList.total_results = 0;
      this.moviesList.results = [];
    }
  }

  goToMovieDetails(Id) {
    this.router.navigateByUrl(`movie/movieDetails/${Id}`)
  }
}
