import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPageable } from '../model/pageable.model';
import { IPost } from '../model/post.model';

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
  getPosts(currentPage: number, pageSize = 4): Observable<IPageable<IPost>> {
    return this.httpClient.get<IPageable<IPost>>(`api/post?pageSize=${pageSize}&currentPage=${currentPage}`);
  }
  getPostsPendingReview(): Observable<IPost[]> {
    return this.httpClient.get<IPost[]>(`api/post/review`);
  }
  approvePost(postId: number): Observable<any> {
    return this.httpClient.put(`api/post/review/${postId}`, { observe: 'body' });
  }
}
