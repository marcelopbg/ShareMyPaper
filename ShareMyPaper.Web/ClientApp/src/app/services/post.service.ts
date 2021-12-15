import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  constructor(
    private httpClient: HttpClient
  ) { }
  registerPost(formData: FormData): Observable<any> {
    return this.httpClient.post('api/post', formData, { observe: 'body' });
  }
}
