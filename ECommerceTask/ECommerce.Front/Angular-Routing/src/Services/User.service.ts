import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthModel } from '../Models/AuthModel';
import { LoginComponent } from 'src/app/login/login.component';
import { LoginUserCommand } from 'src/Models/LoginUserModel';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private _isLoggedIn = new BehaviorSubject<boolean>(
        localStorage.getItem("token") != null
    );
    isLoggedIn = this._isLoggedIn.asObservable();

    private apiUrl = 'https://localhost:7259/api';
    private authStateSubject = new BehaviorSubject<AuthModel | null>(null);

    constructor(private http: HttpClient) { }

    get authState$(): Observable<AuthModel | null> {
        return this.authStateSubject.asObservable();
    }

    register(user: any): Observable<AuthModel> {
        return this.http.post<AuthModel>(`${this.apiUrl}/register`, user)
            .pipe(
                tap((authModel) => this.handleAuthState(authModel))
            );
    }

    login(credentials: LoginUserCommand): Observable<AuthModel> {
        return this.http.post<AuthModel>(`${this.apiUrl}/login`, credentials)
            .pipe(
                tap((authModel) => this.handleAuthState(authModel))
            );
    }

    refresh(model: any): Observable<AuthModel> {
        return this.http.post<AuthModel>(`${this.apiUrl}/refresh`, model)
            .pipe(
                tap((authModel) => this.handleAuthState(authModel))
            );
    }

    private handleAuthState(authModel: AuthModel): void {
        // Save tokens and expiration dates to local storage
        localStorage.setItem('token', authModel.token);
        localStorage.setItem('refreshToken', authModel.refreshToken);
        localStorage.setItem('tokenExpiration', authModel.refreshTokenExpiration.toString());

        // Update the auth state subject
        this.authStateSubject.next(authModel);
    }
}
