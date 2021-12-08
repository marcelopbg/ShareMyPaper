import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { IUser } from '../auth/model/user.model';
import { faUniversity } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

    user: IUser | null = null;
    faUniversity = faUniversity;

  constructor(
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.loadUser();
  }
  loadUser(): void {
    this.authService.currentUser.subscribe({
      next: r => this.user = r
    });
  }
  logout(): void {
    this.authService.logout();
    this.loadUser();
  }
  bindActive(url: string): boolean {
    return this.router.url === url;
  }
}
