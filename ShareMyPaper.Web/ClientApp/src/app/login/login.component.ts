import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Alert, Severity } from '../alert/alert.model';
import { ToastService } from '../alert/toast.service';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required])
  });

  constructor(
    private authService: AuthService,
    private toastService: ToastService,
    private router: Router
  ) { }

  submit(): void {
    console.log(this.loginForm);
    const { email, password } = this.loginForm.value;
    this.authService.login(email, password).subscribe({
      next: r => {
        console.log(r);
        console.log(this.authService.getUser());
        void this.router.navigate(['/']);
        const alert: Alert = { severity: Severity.success, message: "Login Succeeded" };
        this.toastService.showToast(alert);
      },
      error: () => {
        const alert: Alert = { severity: Severity.danger, message: "Login failed, check you're credentials and try again" };
        this.toastService.showToast(alert);
      }
    });
  }

}
