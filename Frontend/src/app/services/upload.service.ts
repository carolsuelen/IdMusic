import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable()
export class UploadService {

 /**
   * Serviço de requisições via HTTP.
   * @var http
   */
  private http : HttpClient;
    url ='http://localhost:64483/api/upload';
  /**
   * constructor
   * @param _http 
   */
  constructor
  (
    _http: HttpClient
  ) 
  {
      this.http = _http;
  }


   /**
  * Upload
  */
 public uploadImage(uploadedFile: FileParameter): Observable<any> 
 {
   const contentFile = new FormData();
   contentFile.append("file", uploadedFile.data, uploadedFile.fileName ? uploadedFile.fileName : "uploadedFile");

   return this.http.post<any>(`${this.url}`, contentFile, {});
 }
}

export interface FileParameter {
  data: any;
  fileName: string;
}

