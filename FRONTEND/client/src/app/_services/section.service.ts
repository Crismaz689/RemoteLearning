import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  url: string = 'https://localhost:7271/rl/sections';

  constructor(private http: HttpClient) { }

  public deleteSection(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }
}
