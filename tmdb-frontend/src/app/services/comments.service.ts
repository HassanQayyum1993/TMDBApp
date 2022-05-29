import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class CommentService {
    url = 'https://localhost:44355/api/Comment';


    constructor(private http: HttpClient) { }

    getCommentsByMovieId(movieId: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetCommentsByMovieId?movieId=' + movieId)
            .pipe(
                catchError(this.handleError)
            );
    }



    getCommentById(pageNumber: number): Observable<any> {
        return this.http.get<any>(this.url + '/GetCommentById?id=' + pageNumber)
            .pipe(
                catchError(this.handleError)
            );
    }

    postComment(sourceObj: any): Observable<any> {
        return this.http.post<any>(this.url + `/PostComment`, JSON.stringify(sourceObj))
            .pipe(
                catchError(this.handleError)
            );
    }

    putComment(commentId: number, sourceObj: any): Observable<any> {
        return this.http.put<any>(this.url + `/PutComment?id=` + commentId, JSON.stringify(sourceObj))
            .pipe(
                catchError(this.handleError)
            );
    }

    updateComment(sourceObj: any): Observable<any> {
        return this.http.put<any>(this.url + `/PutComment`, JSON.stringify(sourceObj))
            .pipe(
                catchError(this.handleError)
            );
    }

    deleteComment(commentId: number): Observable<any> {
        return this.http.delete<any>(this.url + '/DeleteComment?id=' + commentId)
            .pipe(
                catchError(this.handleError)
            );
    }

    private handleError(error: HttpErrorResponse) {

        if (error.error instanceof ErrorEvent) {
            debugger;
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
            return throwError(error.error);

        } else {
            debugger;
            let status = 0;
            let message = '';
            if (error.error.message!=undefined) {
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
                return throwError(error);
            }
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong.

        }
        // Return an observable with a user-facing error message.
    }
}