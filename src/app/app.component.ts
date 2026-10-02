import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { UploadService } from './upload.service';

@Component({
  selector: 'app-root',
  imports: [NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  selectedFile: File | null = null;
  message = '';

  constructor(private uploadService: UploadService) {}

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    this.selectedFile = input.files?.[0] ?? null;
  }

  onUpload() {
    if (!this.selectedFile) return;
    this.uploadService.uploadFile(this.selectedFile).subscribe({
      next: () => this.message = 'File uploaded successfully!',
      error: () => this.message = 'Upload failed.'
    });
  }
}
