import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStudent } from '../model/students.model';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  studentsUrl = 'api/students'
  constructor(
    private httpClient: HttpClient,
    private helperService: HelperService
  ) { }
  getStudentsReview(): Observable<IStudent[]> {
    return this.httpClient.get<IStudent[]>(`${this.studentsUrl}/review`);
  }
  getStudentDocument(documentId: string, documentExtension: string): Observable<Blob> {
    let headers = new HttpHeaders();
    const type = this.helperService.getFileTypeByExtension(documentExtension);
    headers = headers.set('Accept', type);
    return this.httpClient.get(`${this.studentsUrl}/document/${documentId}`, {
      headers,
      responseType: 'blob'
    });
  }
  approveStudent(studentId: string): Observable<boolean> {
    return this.httpClient.post<boolean>(`${this.studentsUrl}/review/${studentId}`, { observe: 'body' });
  }
}
