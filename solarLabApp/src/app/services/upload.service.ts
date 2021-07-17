import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  private uploadUrl = environment.apiUrl+"service/upload";
  constructor(private http:HttpClient) { }

  upload(file:any) {
    if(!file || file.length === 0)
    return;

    let fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    return this.http.post<any>(this.uploadUrl, formData);
  }
}
