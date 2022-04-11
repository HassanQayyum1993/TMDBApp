import { Component, OnInit } from '@angular/core';
import { MovieService } from './movie-list.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  selectedTabIndex: number;
  topMoviesList: any;
  constructor(private _movieService: MovieService) { }

  ngOnInit(): void {
    this._movieService.getPaginatedTopMoviesList(1).subscribe((response) => {
      debugger;
      this.topMoviesList = response;
    });
  }

}
