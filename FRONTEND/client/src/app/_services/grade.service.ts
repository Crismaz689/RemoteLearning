import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGrade } from '../courses/models/grades/grade';
import { IGradeCreate } from '../courses/models/grades/grade-create';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  url: string = 'https://localhost:7271/rl/grades';

  constructor(private http: HttpClient) { }

  deleteGrade(gradeId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + gradeId);
  }

  createGrade(grade: IGradeCreate): Observable<IGrade> {
    return this.http.post<IGrade>(this.url + '/', grade);
  }

  updateGrade(grade: IGradeCreate, gradeId: number): Observable<IGrade> {
    return this.http.put<IGrade>(this.url + '/' + gradeId, grade);
  }

}
