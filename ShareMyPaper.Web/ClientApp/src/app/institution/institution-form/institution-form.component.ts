import { Component, ElementRef, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Alert, Severity } from 'src/app/alert/alert.model';
import { ToastService } from 'src/app/alert/toast.service';
import { IInstitution } from 'src/app/model/institution.model';
import { InstitutionService } from 'src/app/services/institution.service';

@Component({
  selector: 'app-institution-form',
  templateUrl: './institution-form.component.html',
  styleUrls: ['./institution-form.component.css']
})
export class InstitutionFormComponent implements OnChanges {

  constructor(
    private institutionService: InstitutionService,
    private toastService: ToastService
  ) { }
  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['firstChange']) {
      if (this.selectedInstitution) {
        this.institutionForm.setValue({
          description: this.selectedInstitution.description,
          country: this.selectedInstitution.country,
          state: this.selectedInstitution.state,
          city: this.selectedInstitution.city
        });
      } else {
        this.institutionForm = new FormGroup({
          'description': new FormControl('', [Validators.required]),
          'country': new FormControl('', [Validators.required]),
          'state': new FormControl('', [Validators.required]),
          'city': new FormControl('', [Validators.required])
        });      }
    }
  }
  @Input() selectedInstitution?: IInstitution;
  @Output() reloadParent = new EventEmitter();
  @ViewChild('dismiss') closeButton?: ElementRef<HTMLElement>;

  institutionForm = new FormGroup({
    'description': new FormControl('', [Validators.required]),
    'country': new FormControl('', [Validators.required]),
    'state': new FormControl('', [Validators.required]),
    'city': new FormControl('', [Validators.required])
  });
  closeAndRefresh(): void {
    this.reloadParent.emit();
  }
  onSubmit(): void {
    const description: string = this.institutionForm.get('description')?.value;
    const country: string = this.institutionForm.get('country')?.value;
    const state: string = this.institutionForm.get('state')?.value;
    const city: string = this.institutionForm.get('city')?.value;
    const institution: IInstitution = { description, country, state, city };
    if (this.selectedInstitution) {
      institution.id = this.selectedInstitution.id;
      this.institutionService.putInstitution(institution).subscribe({
        next: () => {
          const alert: Alert = { severity: Severity.success, message: "Institution updated successfully!" };
          this.toastService.showToast(alert);
          this.closeButton?.nativeElement.click();
          
        },
        error: () => {
          const alert: Alert = { severity: Severity.danger, message: "An error ocurred while updating the institution" };
          this.toastService.showToast(alert);
        }
      });
    } else {
      this.institutionService.postInstitution(institution).subscribe({
        next: () => {
          const alert: Alert = { severity: Severity.success, message: "Institution created successfully!" };
          this.toastService.showToast(alert);
          this.closeButton?.nativeElement.click();
        },
        error: () => {
          const alert: Alert = { severity: Severity.danger, message: "An error ocurred while creating the institution" };
          this.toastService.showToast(alert);
        }
      });
    }
  }
}
