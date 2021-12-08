import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IKnwolegeArea } from '../model/knowledge-area.model';

@Injectable({
  providedIn: 'root'
})
export class KnowledgeAreaService {

  constructor(private httpClient: HttpClient) { }
  apiUrl = "api/knowledgeAreas"
  // create a method that get knowledgeAreas from the server
  getKnowledgeAreas(): Observable<IKnwolegeArea[]> {
    return this.httpClient.get<IKnwolegeArea[]>(this.apiUrl);
  }
}
