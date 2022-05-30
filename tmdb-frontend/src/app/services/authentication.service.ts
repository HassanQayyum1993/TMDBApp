import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    login(username: string, password: string) {
        return this.http.post<any>('https://localhost:44355/api/Authenticate/login', { username, password })
            .pipe(map(response => {
                // login successful if there's a jwt token in the response
                if (response && response.token) {
                    // store user details and jwt token in session storage
                    window.sessionStorage.setItem('user-name', username);
                    window.sessionStorage.setItem('auth-token', response.token);
                    window.sessionStorage.setItem('auth-token-expiry', response.expiration);
                }
                return response;
            }),
                catchError(this.handleError)
            );
    }

    logout() {
        // remove user from session storage to log user out
        window.sessionStorage.removeItem('user-name');
        window.sessionStorage.removeItem('auth-token');
        window.sessionStorage.removeItem('auth-token-expiry');
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
                return throwError('An error occured while performing the request. Please try again.');
            }
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong.

        }
        // Return an observable with a user-facing error message.
    }
}