import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { IUser } from './model/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authUrl = 'api/auth';
  private currentUserSubject: BehaviorSubject<IUser | null>;
  public currentUser: Observable<IUser | null>;


  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<IUser | null>(this.getUser());
    this.currentUser = this.currentUserSubject.asObservable();
  }

  login(email: string, password: string): Observable<IUser> {
    return this.http.post<IUser>(`${this.authUrl}/login`, { email, password })
      .pipe(
        tap((r) => {
          this.storeUser(r);
          this.currentUserSubject.next(this.getUser());
        })
      )
  }

  storeUser(user: IUser): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUser(): IUser | null {
    const userString = localStorage.getItem('user');
    if (userString) {
      const user: IUser = JSON.parse(userString);
      return user;
    }
    return null;
  }

  logout(): void {
    localStorage.removeItem('user');
    this.currentUserSubject.next(null);
  }
}
