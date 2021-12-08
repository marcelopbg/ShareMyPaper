import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Alert, Severity } from 'src/app/alert/alert.model';
import { ToastService } from 'src/app/alert/toast.service';
import { IInstitution } from 'src/app/model/institution.model';
import { InstitutionService } from 'src/app/services/institution.service';

@Component({
  selector: 'app-delete-popup',
  templateUrl: './delete-popup.component.html',
  styleUrls: ['./delete-popup.component.css']
})
export class DeletePopupComponent implements OnInit {

  @Input() selectedInstitution?: IInstitution;
  @Output() reloadParent = new EventEmitter();
  @ViewChild('dismiss') closeButton?: ElementRef<HTMLElement>;

  constructor(
    private institutionService: InstitutionService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
  }
  deleteInstitution(): void {
    this.institutionService.deleteInstitution(this.selectedInstitution!).subscribe(() => {
      this.reloadParent.emit()
      const alert: Alert = { severity: Severity.success, message: "Institution deleted successfully!" };
      this.toastService.showToast(alert);
      this.closeButton!.nativeElement.click();
    });
  }
}
