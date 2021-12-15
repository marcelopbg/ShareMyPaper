import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Alert, Severity } from 'src/app/alert/alert.model';
import { ToastService } from 'src/app/alert/toast.service';
import { IKnwolegeArea } from 'src/app/model/knowledge-area.model';
import { KnowledgeAreaService } from 'src/app/services/knowledge-area.service';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  constructor(
    private knowledgeAreaService: KnowledgeAreaService,
    private postService: PostService,
    private toastService: ToastService
    ) { }

  postForm = new FormGroup({
    title: new FormControl("", [Validators.required]),
    text: new FormControl("", [Validators.required]),
    isPublic: new FormControl("", [Validators.required]),
    uploadedFile: new FormControl("", [Validators.required]),
    knowledgeAreaId: new FormControl("", Validators.required)
  })

  selectedKnowledgeArea?: number;
  knowledgeAreas: IKnwolegeArea[] = []
  
  ngOnInit(): void {
    this.knowledgeAreaService.getKnowledgeAreas().subscribe(r => this.knowledgeAreas = r);

  }
  onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files!.length > 0) {
      const file = input.files![0];
      this.postForm.patchValue({
        uploadedFile: file
      });
    }
  }

  submit(): void {
    const formData = new FormData();
    formData.append('title', this.postForm.get('title')!.value);
    formData.append('text', this.postForm.get('text')!.value);
    formData.append('uploadedFile', this.postForm.get('uploadedFile')!.value);
    formData.append('isPublic', this.postForm.get('isPublic')!.value);
    formData.append('knowledgeAreaId', this.postForm.get('knowledgeAreaId')!.value);

    this.postService.registerPost(formData).subscribe({
      next: r => {
        console.log(r);
        const alert: Alert = { severity: Severity.success, message: "Post Registration Succeeded, the post must be reviewed by an institution moderator" };
        this.toastService.showToast(alert);
      },
      error: err => {
        const error: { errors: { errorMessage?: string, description?: string }[] } = err;
        if (error.errors && error.errors.length > 0) {
          const message = error.errors.map(v => v.errorMessage ?? v.description).join("\n");
          const alert: Alert = { severity: Severity.danger, message: message };
          this.toastService.showToast(alert);
          return;
        }

        const alert: Alert = { severity: Severity.danger, message: "Unexpected error ocurred registering post" };
        this.toastService.showToast(alert);
      }
    });
  }
}
