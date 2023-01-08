import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGrade } from '../courses/models/grades/grade';
import { IGradeCreate } from '../courses/models/grades/grade-create';
import { IUserGrade } from '../courses/models/grades/grade-user';
import { IUserGradeDetailed } from '../courses/models/grades/grade-user-detailed';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  url: string = 'https://localhost:7271/rl/grades';

  constructor(private http: HttpClient) { }

  deleteGrade(gradeId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + gradeId);
  }

  getCurrentUserGrades(): Observable<IUserGrade[]> {
    return this.http.get<IUserGrade[]>(this.url + '/');
  }

  createGrade(grade: IGradeCreate): Observable<IGrade> {
    return this.http.post<IGrade>(this.url + '/', grade);
  }

  getAllGrades(): Observable<IUserGradeDetailed[]> {
    return this.http.get<IUserGradeDetailed[]>(this.url + '/admin-get-all');
  }

  updateGrade(grade: IGradeCreate, gradeId: number): Observable<IGrade> {
    return this.http.put<IGrade>(this.url + '/' + gradeId, grade);
  }

}
