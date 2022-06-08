import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AppConstants } from 'app/app.constants';

@Injectable({
    providedIn: 'root'
})

export class CommentService {

    constructor(private http: HttpClient, private constants: AppConstants) { }

    getCommentsByMovieId(movieId: number): Observable<any> {
        return this.http.get<any>(this.constants.URL + 'Comment/CommentsByMovieId?movieId=' + movieId)
            .pipe(
                catchError(this.handleError)
            );
    }



    getCommentById(pageNumber: number): Observable<any> {
        return this.http.get<any>(this.constants.URL + 'Comment/CommentById?id=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );
    }

    postComment(sourceObj: any): Observable<any> {
        return this.http.post<any>(this.constants.URL + `Comment/PostComment`, JSON.stringify(sourceObj))
            .pipe(
                catchError(this.handleError)
            );
    }

    updateComment(commentId: number, sourceObj: any): Observable<any> {
        return this.http.put<any>(this.constants.URL + `Comment/UpdateComment?id=` + commentId, JSON.stringify(sourceObj))
            .pipe(
                catchError(this.handleError)
            );
    }

    deleteComment(commentId: number): Observable<any> {
        return this.http.delete<any>(this.constants.URL + 'Comment/DeleteComment?id=' + commentId)
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