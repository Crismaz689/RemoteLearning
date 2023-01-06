import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  url: string = 'https://localhost:7271/rl/grades';

  constructor(private http: HttpClient) { }

}
