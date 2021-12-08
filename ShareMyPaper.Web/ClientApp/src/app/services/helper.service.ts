import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  constructor() { }

  getFileTypeByExtension(extension: string): string {
    switch (extension) {
      case '.pdf':
        return 'application/pdf';
      case '.jpg':
      case '.jpeg':
        return 'image/jpg';
      case '.png':
        return 'image/png';
      default:
        return '';
    }
  }
}
