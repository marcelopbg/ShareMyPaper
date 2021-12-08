import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private httpClient: HttpClient) { }
  studentRegisterUrl = "api/Auth/student/register"
  // create a method that get knowledgeAreas from the server
  registerStudent(formData: FormData): Observable<any> {
    return this.httpClient.post(this.studentRegisterUrl, formData, { observe: 'body' });
  }

  registerInstitutionModerator(email: string, password: string, institutionId?: number): Observable<any> {
    return this.httpClient.post("api/Auth/institution-moderator/register", { email, password, institutionId }, { observe: 'body' });
  }

}
