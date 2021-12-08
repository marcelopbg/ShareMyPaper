import { Component, OnInit } from '@angular/core';
import { SafeResourceUrl } from '@angular/platform-browser';
import { faCheck, faFilePdf } from '@fortawesome/free-solid-svg-icons';
import { Alert, Severity } from '../alert/alert.model';
import { ToastService } from '../alert/toast.service';
import { IStudent } from '../model/students.model';
import { StudentsService } from '../services/students.service';

@Component({
  selector: 'app-students-review',
  templateUrl: './students-review.component.html',
  styleUrls: ['./students-review.component.css']
})
export class StudentsReviewComponent implements OnInit {

  faFilePdf = faFilePdf;
  faCheck = faCheck;
  students: IStudent[] = []
  currentDocument?: { link: SafeResourceUrl, type: string };
  constructor(
    private studentsService: StudentsService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.loadAll();
  }
  loadAll(): void {
    this.studentsService.getStudentsReview().subscribe(r => this.students = r)
  }
  viewStudentDocument(student: IStudent): void {
    const { documentId, documentExtension } = student;
    this.studentsService.getStudentDocument(documentId, documentExtension).subscribe((r: Blob) => {
      window.open(window.URL.createObjectURL(r), '_blank');
    });
  }
  approveStudent(student: IStudent): void {
    this.studentsService.approveStudent(student.id).subscribe(() => {
      const alert: Alert = { severity: Severity.success, message: "Student approved successfully!" };
      this.toastService.showToast(alert);
      this.loadAll();
    });
  }
}
