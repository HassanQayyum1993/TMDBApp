import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MovieService } from 'app/services/movie.service';
import { notification } from 'app/general-services/notification.model';
import { NotificationService } from 'app/general-services/notification.service';

@Component({
  selector: 'app-search-movies',
  templateUrl: './search-movies.component.html',
  styleUrls: ['./search-movies.component.scss']
})
export class SearchMoviesComponent implements OnInit {

  moviesList: any;
  genreId: any = 0;
  genreList: any;
  displayedColumns = ['PosterImage', 'Title', 'Rating', 'ReleaseDate'];
  searchKeyWord: string = null;
  pageNumber: number = 1;
  input: boolean = true;

  constructor(private _movieService: MovieService,
    private _notificationService: NotificationService,
    private router: Router) { }

  ngOnInit(): void {
    this._movieService.GetMoviesGenreList().subscribe((response) => { this.genreList = response.genreList.genres }, (err) => {
      let notificationObj: notification = {
        message: err.message,
        type: "warning",
      };
      this._notificationService.open(notificationObj);
    });
  }

  refreshList() {

    this.moviesList = null;

    if (this.searchKeyWord != null && this.searchKeyWord != "") {
      this.input = false;
      this._movieService.GetPaginatedMoviesListWithSearch(this.searchKeyWord, this.genreId, this.pageNumber).subscribe((response) => {
        this.moviesList = response.movieList;
        this.input = true;
      }, (err) => {
        this.input = true;
        let notificationObj: notification = {
          message: err.message,
          type: "warning",
        };
        this._notificationService.open(notificationObj);
      })
    }
    else {
      if (this.genreId != 0 && this.genreId != null) {
        this.input = false;
        this._movieService.GetPaginatedMoviesListByGenre(this.genreId, this.pageNumber).subscribe((response) => {
          this.moviesList = response.movieList;
          this.input = true;
        }, (err) => {
          this.input = true;
          let notificationObj: notification = {
            message: err.message,
            type: "warning",
          };
          this._notificationService.open(notificationObj);
        })
      }
    }
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this.refreshList();
  }

  setGenreId(event) {
    this.genreId = event.value;
    this.refreshList();
    if (this.moviesList && (this.genreId == 0 || this.genreId == null)) {
      this.moviesList.total_results = 0;
      this.moviesList.results = [];
    }
  }

  goToMovieDetails(Id) {
    this.router.navigateByUrl(`movie/movieDetails/${Id}`)
  }
}
