import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseAssignmentService {

  url: string = 'https://localhost:7271/rl/course-assignments';

  constructor(private http: HttpClient) { }

  assignToCourse(courseId: number): Observable<number> {
    return this.http.post<number>(this.url + '/', { courseId: courseId });
  }

  unassignFromCourse(courseId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + courseId);
  }
  
}