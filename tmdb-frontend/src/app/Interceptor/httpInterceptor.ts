import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class httpInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, newRequest: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header to request

        //Get Token data from session storage
        debugger;
        let token = window.sessionStorage.getItem('auth-token');
        if (token) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`,
                    'Content-Type': 'application/json;charset=utf-8'
                }
            });
        }

        return newRequest.handle(request);
    }
}