/* eslint-disable */
import { Component, OnInit } from '@angular/core';
import { faArrowLeft, faArrowRight, faFilePdf } from '@fortawesome/free-solid-svg-icons';
import { PostService } from '../services/post.service';
import { IPost } from '../model/post.model';
import { IPageable } from '../model/pageable.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  faArrowLeft = faArrowLeft;
  faArrowRight = faArrowRight;
  faFilePdf = faFilePdf;
  newestPosts?: IPageable<IPost>;

  constructor(private postService: PostService) { }

  ngOnInit(): void {
   this.postService.getPosts(1).subscribe(p => this.newestPosts = p); 
  }
  nextPageButton(): void {
    const currentPage = this.newestPosts!.currentPage;
    if(currentPage === this.newestPosts!.pageCount) {
      return;
    }
    let nextPage = currentPage + 1;
    this.postService.getPosts(nextPage).subscribe(p => this.newestPosts = p)
  }
  previousPageButton(): void {
    const currentPage = this.newestPosts!.currentPage;
    if(currentPage === 1) {
      return;
    }
    let nextPage = currentPage - 1;
    this.postService.getPosts(nextPage).subscribe(p => this.newestPosts = p)
  }
  viewStudentDocument(): void {
    // const { documentId, documentExtension } = student;
    // this.studentsService.getStudentDocument(documentId, documentExtension).subscribe((r: Blob) => {
    //   window.open(window.URL.createObjectURL(r), '_blank');
    // });
  }
}
