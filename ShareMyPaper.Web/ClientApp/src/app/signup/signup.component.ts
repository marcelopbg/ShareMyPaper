import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Alert, Severity } from '../alert/alert.model';
import { ToastService } from '../alert/toast.service';
import { IInstitution } from '../model/institution.model';
import { IKnwolegeArea } from '../model/knowledge-area.model';
import { InstitutionService } from '../services/institution.service';
import { KnowledgeAreaService } from '../services/knowledge-area.service';
import { SignupService } from '../services/signup.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  signupForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required]),
    uploadedFile: new FormControl("", [Validators.required]),
    institutionId: new FormControl("", [Validators.required]),
    preferredKnowledgeAreas: new FormControl("", [])
  });

  selectedKnowledgeAreas: number[] = [];
  knowledgeAreas: IKnwolegeArea[] = []
  institutions: IInstitution[] = [];
  selectedInstitution?: number;

  constructor(
    private knowledgeAreaService: KnowledgeAreaService,
    private institutionService: InstitutionService,
    private signupService: SignupService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.knowledgeAreaService.getKnowledgeAreas().subscribe(r => this.knowledgeAreas = r);
    this.institutionService.getInstitutions().subscribe(r => this.institutions = r);
  }

  onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files!.length > 0) {
      const file = input.files![0];
      this.signupForm.patchValue({
        uploadedFile: file
      });
    }
  }

  submit(): void {
    const formData = new FormData();
    formData.append('uploadedFile', this.signupForm.get('uploadedFile')!.value);
    formData.append('email', this.signupForm.get('email')!.value);
    formData.append('password', this.signupForm.get('password')!.value);
    formData.append('institutionId', this.signupForm.get('institutionId')!.value);
    const preferredKnowledgeAreas: number[] = this.signupForm.get('preferredKnowledgeAreas')?.value;
    if(preferredKnowledgeAreas && preferredKnowledgeAreas.length > 0)
    preferredKnowledgeAreas.forEach(v => {
      formData.append('preferredKnowledgeAreas', ""+v);
    })
    
    this.signupService.registerStudent(formData).subscribe({
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

        const alert: Alert = { severity: Severity.danger, message: "Unexpected error ocurred registering student" };
        this.toastService.showToast(alert);
      }
    });
  }
}
