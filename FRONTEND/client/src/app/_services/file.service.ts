import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFileDownload } from '../courses/models/files/file-download';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  url: string = 'https://localhost:7271/rl/files';

  constructor(private http: HttpClient) { }

  public createFile(data: FormData): Observable<string> {
    return this.http.post<string>(this.url + '/', data);
  }

  public getFile(fileId: number): Observable<IFileDownload> {
    return this.http.get<IFileDownload>(this.url + '/' + fileId);
  }

  public deleteFile(fileId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + fileId);
  }

}
