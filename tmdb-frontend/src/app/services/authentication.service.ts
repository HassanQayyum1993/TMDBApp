import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    login(username: string, password: string) {
        return this.http.post<any>('https://localhost:44355/api/Authenticate/login', { username, password })
            .pipe(map(user => {
                debugger;
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in session storage
                    window.sessionStorage.setItem('user-name',username);
                    window.sessionStorage.setItem('token-info', JSON.stringify(user));
                }

                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        window.sessionStorage.removeItem('token-info');
        window.sessionStorage.removeItem('user-name');
    }
}