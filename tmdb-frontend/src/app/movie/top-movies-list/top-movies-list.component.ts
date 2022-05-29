import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'app/general-services/notification.service';
import { MovieService } from 'app/services/movie.service';
import { notification } from 'app/general-services/notification.model';

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
    private router: Router,
    private _notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.movieList;
    },(err) => {
      debugger;
      let notificationObj: notification = {
        message: err.message,
        type: "warning",
      };
      this._notificationService.open(notificationObj);
    });
  }

  handlePage(event) {
    this.pageNumber = event.pageIndex + 1;
    this._movieService.getPaginatedTopMoviesList(this.pageNumber).subscribe((response) => {
      this.topMoviesList = response.movieList;
    },(err) => {
      debugger;
      let notificationObj: notification = {
        message: err.message,
        type: "warning",
      };
      this._notificationService.open(notificationObj);
    });
  }

  goToMovieDetails(Id) {
    this.router.navigateByUrl(`movie/movieDetails/${Id}`)
  }
}
