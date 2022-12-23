import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICourse } from '../courses/models/course';
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
