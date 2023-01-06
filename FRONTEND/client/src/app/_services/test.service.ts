import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITest } from '../courses/models/tests/test';
import { ITestCreate } from '../courses/models/tests/test-create';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  url: string = 'https://localhost:7271/rl/tests';

  constructor(private http: HttpClient) { }

  public deleteTest(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }

  public createTest(test: ITestCreate): Observable<ITest> {
    return this.http.post<ITest>(this.url + '/', test);
  }

  public updateTest(test: ITestCreate, testId: number): Observable<ITest> {
    return this.http.put<ITest>(this.url + '/' + testId, test);
  }
}
