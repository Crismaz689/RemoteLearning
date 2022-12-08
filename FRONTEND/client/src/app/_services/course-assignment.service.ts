import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseAssignmentService {

  url: string = 'https://localhost:7271/rl/course-assignments';

  constructor(private http: HttpClient) { }
  
  }