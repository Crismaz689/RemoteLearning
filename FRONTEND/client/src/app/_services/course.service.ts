import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICourse } from '../courses/models/course';
import { ICourseAllData } from '../courses/models/course-all-data';
import { ICourseCreate } from '../courses/models/course-create';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  url: string = 'https://localhost:7271/rl/courses';

  constructor(private http: HttpClient) { }

  public create(course: ICourseCreate): Observable<ICourse> {
    return this.http.post<ICourse>(this.url + '/', course);
  }

  public getCourse(id: number): Observable<ICourseAllData> {
    return this.http.get<ICourseAllData>(this.url + '/' + id);
  }

  public deleteCourse(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }

  public updateCourse(id: number, course: ICourse): Observable<ICourse> {
    return this.http.put<ICourse>(this.url + '/' + id, course);
  }

  public getMyCourses(): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(this.url + '/my-courses');
  }

  public getAssignedCourses(): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(this.url + '/assigned-courses');
  }

  public getAllCourses(): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(this.url + '/');
  }
}
