import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class MovieService {
    url = 'https://localhost:7167/api/Movie';

    constructor(private http: HttpClient) { }

    getMovieDetails(movieId: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetMovieDetails/' + movieId)
            .pipe(
                catchError(this.handleError)
            );;
    }

    getPaginatedTopMoviesList(pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedTopMoviesList?pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );;
    }

    GetPaginatedMoviesListWithSearch(searchKeyWord: string, genreId: number, pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedMoviesListWithSearch?searchKeyWord='+ searchKeyWord + '&genreId=' +  genreId + '&pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );;
    }

    GetPaginatedMoviesListByGenre(genre: string, pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedMoviesListByGenre?genre=' + genre + '&pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );;
    }

    GetMoviesGenreList(): Observable<any> {
        return this.http.get<any>(this.url + '/GetMoviesGenreList')
            .pipe(
                catchError(this.handleError)
            );;
    }

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong.
            console.error(
                `Backend returned code ${error.status}, ` +
                `body was: ${error.error}`);
        }
        // Return an observable with a user-facing error message.
        return throwError('An error occured while performing this operation. Please try again.');
    }
}