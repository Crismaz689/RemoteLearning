import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISection } from '../courses/models/sections/section';
import { ISectionCreate } from '../courses/models/sections/section-create';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  url: string = 'https://localhost:7271/rl/sections';

  constructor(private http: HttpClient) { }

  public deleteSection(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }

  public createSection(section: ISectionCreate): Observable<ISection> {
    return this.http.post<ISection>(this.url + '/', section);
  }

  public updateSection(section: ISectionCreate, sectionId: number): Observable<ISection> {
    return this.http.put<ISection>(this.url + '/' + sectionId, section);
  }
}
