import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class UploadService {
  private apiUrl = environment.apiUrl+"/Employee";

  constructor(private http: HttpClient) {}

  uploadFile(file: File) {
    debugger;
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(this.apiUrl+"/Upload", formData);
  }
}
