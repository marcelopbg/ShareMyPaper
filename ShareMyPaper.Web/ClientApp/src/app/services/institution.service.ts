import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInstitution } from '../model/institution.model';

@Injectable({
  providedIn: 'root'
})
export class InstitutionService {

  constructor(private httpClient: HttpClient) { }
  apiUrl = "api/institutions"
  // create a method that get knowledgeAreas from the server
  getInstitutions(): Observable<IInstitution[]> {
    return this.httpClient.get<IInstitution[]>(this.apiUrl);
  }
  postInstitution(institution: IInstitution): Observable<IInstitution> {
    return this.httpClient.post<IInstitution>(this.apiUrl, institution);
  }
  putInstitution(institution: IInstitution): Observable<IInstitution> {
    return this.httpClient.put<IInstitution>(`${this.apiUrl}/${institution.id!}`, institution);
  }
  deleteInstitution(institution: IInstitution): Observable<IInstitution> {
    return this.httpClient.delete<IInstitution>(`${this.apiUrl}/${institution.id!}`);
  }
}
