import { HttpEvent, HttpHandler, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthenticationInterceptor {
    constructor() { }
    intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        let token = localStorage.getItem('token');
        req = req.clone({
            setHeaders: {
                Authorization: `Bearer ${token}`
            }
        }
        )
        return next.handle(req);
    }
}
