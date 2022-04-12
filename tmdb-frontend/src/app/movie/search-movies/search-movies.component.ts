import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie.service';

@Component({
  selector: 'app-search-movies',
  templateUrl: './search-movies.component.html',
  styleUrls: ['./search-movies.component.css']
})
export class SearchMoviesComponent implements OnInit {

  moviesList: any;
  genreId: any;
  genreList: any;
  displayedColumns = [ 'PosterImage', 'Title', 'ReleaseDate'];
  searchKeyWord: string;
  pageNumber: number =1;
  constructor(private _movieService: MovieService) { }

  ngOnInit(): void {
      this._movieService.GetMoviesGenreList().subscribe((response) =>{debugger; this.genreList = response.genreList.genres});
  }

  refreshList()
  {
    // this._movieService.GetPaginatedMoviesListWithSearch(this.searchKeyWord,this.pageNumber).subscribe((response) => {
    //   this.moviesList = response.moviesList;
    // });

    this._movieService.GetPaginatedMoviesListByGenre('Action',this.pageNumber).subscribe((response) => {
      debugger;
      this.moviesList = response.moviesList;
    });
  }

  handlePage(event)
  {
    debugger;
    this.pageNumber = event.pageIndex+1;
    this._movieService.GetPaginatedMoviesListByGenre('Action',this.pageNumber).subscribe((response) => {
      this.moviesList = response.moviesList;
    });
  }

}
