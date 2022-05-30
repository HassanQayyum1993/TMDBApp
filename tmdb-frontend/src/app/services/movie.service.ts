import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class MovieService {
    url = 'https://localhost:44355/api/Movie';

    constructor(private http: HttpClient) { }

    getMovieDetails(movieId: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetMovieDetails?movieId=' + movieId)
            .pipe(
                catchError(this.handleError)
            );
    }

    getPaginatedTopMoviesList(pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedTopMoviesList?pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );
    }

    GetPaginatedMoviesListWithSearch(searchKeyWord: string, genreId: number, pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedMoviesListWithSearch?searchKeyWord=' + searchKeyWord + '&genreId=' + genreId + '&pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );
    }

    GetPaginatedMoviesListByGenre(genreId: number, pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetPaginatedMoviesListByGenre?genreId=' + genreId + '&pageNumber=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );
    }

    GetMoviesGenreList(): Observable<any> {
        return this.http.get<any>(this.url + '/GetMoviesGenreList')
            .pipe(
                catchError(this.handleError)
            );
    }

    private handleError(error: HttpErrorResponse) {

        let status = 0;
        let message = '';

        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            message = error.error.message;
            console.error('An error occurred:', message);
            return throwError(error.error);

        } else {
            if (error.error.message != undefined) {
                status = error.status;
                message = error.error.message;
                console.error(
                    `Backend returned code ${status}, ` +
                    `body was: ${message}`);
                return throwError(error.error);
            }
            else {
                status = error.status;
                message = error.message;
                console.error(
                    `Backend returned code ${status}, ` +
                    `body was: ${message}`);
                return throwError({message:'An error occured while performing the request. Please try again.'});
            }
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong.

        }
        // Return an observable with a user-facing error message.
    }
}