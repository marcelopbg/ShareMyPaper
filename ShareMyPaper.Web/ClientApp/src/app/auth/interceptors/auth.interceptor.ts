
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, ObservableInput, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../auth.service';
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const user = this.authService.getUser();

    if (user?.token) {
      const authReq = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${user.token}`)
      });
      return next.handle(authReq).pipe(
        catchError(error => {
          return this.logoutUserIfUnauthorizedOrUnauthenticated(error)
        })
      );
    }

    return next.handle(req)
      .pipe(
        catchError(error => {
          return this.logoutUserIfUnauthorizedOrUnauthenticated(error)
        })
      );
  }
  private logoutUserIfUnauthorizedOrUnauthenticated(resp: HttpErrorResponse): ObservableInput<never> {

    if (resp instanceof HttpErrorResponse) {
      if ([401, 403].includes(resp.status)) {
        this.authService.logout();
        void this.router.navigate(['/login']);
      }
    }
    throw resp.error;
  }
}