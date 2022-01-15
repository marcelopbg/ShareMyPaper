import { Component, OnInit } from '@angular/core';
import { IPost } from 'src/app/model/post.model';
import { PostService } from 'src/app/services/post.service';
import { faFilePdf, faCheck } from '@fortawesome/free-solid-svg-icons'
import { StudentsService } from 'src/app/services/students.service';
import { Alert, Severity } from 'src/app/alert/alert.model';
import { ToastService } from 'src/app/alert/toast.service';

@Component({
  selector: 'app-review-posts',
  templateUrl: './review-posts.component.html',
  styleUrls: ['./review-posts.component.css']
})
export class ReviewPostsComponent implements OnInit {

  constructor(private postService: PostService, private studentsService: StudentsService, private toastService: ToastService) { }
  posts: IPost[] = []

  faFilePdf = faFilePdf;
  faCheck = faCheck;

  ngOnInit(): void {
    this.loadPosts();
  }

  loadPosts(): void {
    this.postService.getPostsPendingReview().subscribe(p => this.posts = p);
  }

  approvePost(postId: number): void {
    this.postService.approvePost(postId).subscribe({
      next: () => {
        const alert: Alert = { severity: Severity.success, message: "Post Approved successfully. The Post will now be visible for other students" };
        this.toastService.showToast(alert);
        this.loadPosts();
      },
      error: () => {
        const alert: Alert = { severity: Severity.danger, message: "An error ocurred on the post review. Try again Later." };
        this.toastService.showToast(alert);
        this.loadPosts();
        return;
      }
    });
  }
  viewPostDocument(post: IPost): void {
    const { documentId, documentExtension } = post;
    this.studentsService.getStudentDocument(documentId, documentExtension).subscribe((r: Blob) => {
      window.open(window.URL.createObjectURL(r), '_blank');
    });
  }
}
