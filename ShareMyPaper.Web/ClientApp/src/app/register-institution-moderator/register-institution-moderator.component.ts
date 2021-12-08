import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Alert, Severity } from '../alert/alert.model';
import { ToastService } from '../alert/toast.service';
import { AuthService } from '../auth/auth.service';
import { IUser } from '../auth/model/user.model';
import { IInstitution } from '../model/institution.model';
import { InstitutionService } from '../services/institution.service';
import { SignupService } from '../services/signup.service';

@Component({
  selector: 'app-register-institution-moderator',
  templateUrl: './register-institution-moderator.component.html',
  styleUrls: ['./register-institution-moderator.component.css']
})
export class RegisterInstitutionModeratorComponent implements OnInit {

  signupForm?: FormGroup;

  selectedKnowledgeAreas: number[] = [];
  institutions: IInstitution[] = [];
  selectedInstitution?: number;
  currentUser!: IUser;

  constructor(
    private institutionService: InstitutionService,
    private signupService: SignupService,
    private toastService: ToastService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.authService.currentUser.subscribe(r => {
      this.currentUser = r!;
      if(this.currentUser.role === 'admin'){
        this.signupForm = new FormGroup({
          email: new FormControl("", [Validators.required, Validators.email]),
          password: new FormControl("", [Validators.required]),
          institutionId: new FormControl("", [Validators.required]),
        });
      } else {
        this.signupForm = new FormGroup({
          email: new FormControl("", [Validators.required, Validators.email]),
          password: new FormControl("", [Validators.required]),
        });
      }
    });
    this.institutionService.getInstitutions().subscribe(r => this.institutions = r);
  }

  submit(): void {
    
    const email = this.signupForm!.get('email')!.value;
    const password = this.signupForm!.get('password')!.value;
    let institutionId;
    if(this.currentUser.role === 'institution moderator'){
      institutionId = undefined;
    } else institutionId = this.signupForm!.get('institutionId')!.value;
    this.signupService.registerInstitutionModerator(email, password, institutionId).subscribe({
      next: r => {
        console.log(r);
        const alert: Alert = { severity: Severity.success, message: "Registration Succeeded" };
        this.toastService.showToast(alert);
      },
      error: err => {
        const error: { errors: { errorMessage?: string, description?: string }[] } = err;
        if (error.errors && error.errors.length > 0) {
          const message = error.errors.map(v => v.errorMessage ?? v.description).join("\n");
          const alert: Alert = { severity: Severity.danger, message: message };
          this.toastService.showToast(alert);
          return;
        }

        const alert: Alert = { severity: Severity.danger, message: "Unexpected error ocurred registering institution moderator" };
        this.toastService.showToast(alert);
      }
    });
  }
}
