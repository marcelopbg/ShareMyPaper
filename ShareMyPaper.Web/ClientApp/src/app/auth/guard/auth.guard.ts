import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../auth.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authService: AuthService
    ) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        const currentUser = this.authService.getUser();
        if (currentUser) {
            const roles = route.data["roles"] as Array<string>;
            if (!roles.includes(currentUser.role)) {
                void this.router.navigate(['/']);
                return false;
            }
            return true;
        }

        void this.router.navigate(['/']);
        return false;
    }
}